using Core;
using Core.Enums;
using Infra.Repositories.Interfaces;
using Infra.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositories.Classes
{
    public class PollRepo : GenericRepo<Poll>, IPollRepo
    {
        Context cntx;
        public PollRepo(Context cntx) : base(cntx)
        {
            this.cntx = cntx;
        }

        public List<PollVM> GetNewOpenPolls(long memberId)
        {
            var res = this.cntx.Polls.
                 Include(p => p.PollResponses).
                 Where(p => p.PollStatus == PollStatusEnum.Open && !p.PollResponses.Any(r => r.MemberId == memberId)).
                 OrderByDescending(p=>p.PollDate).
                 Select(o => new PollVM
                 {
                     PollId = o.PollId,
                     PollDate = o.PollDate,
                     PollQuestion = o.PollQuestion,
                     IsResponded = false

                 });

            return res.ToList();

        }

        public List<ResponsePollVM> GetPollsOptions(long id)
        {
            var res = from p in this.cntx.Polls
                      where p.PollId == id
                      join o in this.cntx.PollsOptions on p.PollId equals o.PollId
                      select new ResponsePollVM
                      {
                          PollQuestion = p.PollQuestion,
                          PollOptionId = o.PollOptionId,
                          Option = o.Option
                      };

            return res.ToList();

        }

        public void SavePollResponse(long memberId, long pollId, long pollOptionId)
        {
            var pr = new PollResponse
            {
                MemberId = memberId,
                PollId = pollId,
                PollResponseDate = DateTime.Now,

            };

            this.cntx.PollsResponses.Add(pr);

            var popt = new PollResponseOption
            {
                PollResponseID = pr.PollResponseId,
                PollOptionId = pollOptionId,
            };

            pr.PollResponseOptions.Add(popt);

            this.cntx.PollsResponses.Add(pr);
            this.cntx.SaveChanges();
        }


        public List<PollVM> GetRespondedPolls(long memberId)
        {
            var res = this.cntx.Polls.
                    Include(p => p.PollResponses).
                    Where(p => p.PollResponses.Any(p => p.MemberId == memberId)).
                    Select(r => new PollVM
                    {
                        PollId = r.PollId,
                        PollDate = r.PollDate,
                        PollQuestion = r.PollQuestion,
                        IsResponded = true
                    });

            return res.ToList();
        }

        public PollResponseVM GetPollDetails(long pollId, long memberId)
        {
            var res = this.cntx.Polls
                    .Include(p => p.PollOptions)
                    .Include(p => p.PollResponses.Where(r => r.MemberId == memberId))
                    .FirstOrDefault(p => p.PollId == pollId);

            if (res == null)
                return null;

            var selOpt = res.PollResponses.FirstOrDefault()?.PollResponseOptions.Select(o => o.PollOptionId).FirstOrDefault();


            return new PollResponseVM
            {
                PollQuestion = res.PollQuestion,
                PollOptions = res.PollOptions.Select(o => new PollOptionVM
                {
                    PollOptionId = o.PollOptionId,
                    Option = o.Option,
                    IsSelected = o.PollOptionId == selOpt
                }).ToList()
            };
        }

        public void UpdatePollResponse(long memberId, long pollId, long pollOptionId)
        {
            var pr = this.cntx.PollsResponses
                     .Include(r => r.PollResponseOptions)
                     .FirstOrDefault(r => r.MemberId == memberId && r.PollId == pollId);

            if (pr != null)
            {
                var opt = pr.PollResponseOptions.FirstOrDefault();

                if (opt == null)
                {
                    var newResponseOption = new PollResponseOption
                    {
                        PollResponseID = pr.PollResponseId,
                        PollOptionId = pollOptionId
                    };
                    pr.PollResponseOptions.Add(newResponseOption);
                }
                else
                {
                    opt.PollOptionId = pollOptionId;
                }

                this.cntx.SaveChanges();
            }
        }

        public List<PollListCountVM> GetPollListCount()
        {
            var res = this.cntx.Polls
                        .Include(p => p.PollResponses)
                        .OrderByDescending(p=>p.PollDate)
                        .Select(p => new PollListCountVM
                        {
                            PollId = p.PollId,
                            PollDate = p.PollDate,
                            PollStatus = p.PollStatus,
                            PollQuestion = p.PollQuestion,
                            ResponseCount = p.PollResponses.Count
                        });


            return res.ToList();

        }

        public List<MemberPollResponseVM> GetMemberResponse(long pollId)
        {
            var res = this.cntx.Polls
                     .Include(p=>p.PollResponses)
                     .ThenInclude(p=>p.Member)
                     .Include(p=>p.PollResponses)
                     .ThenInclude(p=>p.PollResponseOptions)
                     .ThenInclude(p=>p.PollOption)
                     .FirstOrDefault(p=>p.PollId == pollId);
                     
                     
            if(res == null)
                return null;

            var poldet = res.PollResponses.Select(p => new MemberPollResponseVM
            {
                PollId = p.PollId,
                PollQuestion = res.PollQuestion,
                MemberName = p.Member.FullName,
                PollResponseDate= p.PollResponseDate,
                Response = p.PollResponseOptions.FirstOrDefault()?.PollOption.Option
            });

            return poldet.ToList();
        }


        public void DeletePollWithDependencies(long pollId)
        {
            var res = this.cntx.Polls
                        .Include(p => p.PollOptions)
                        .Include(p => p.PollResponses)
                        .ThenInclude(pr => pr.PollResponseOptions)
                        .FirstOrDefault(p => p.PollId == pollId);

            if (res == null)
                throw new Exception("Poll not found.");

            foreach (var temp in res.PollResponses)
            {
                this.cntx.PollsResponsesOptions.RemoveRange(temp.PollResponseOptions);
            }

            this.cntx.PollsResponses.RemoveRange(res.PollResponses);

            this.cntx.PollsOptions.RemoveRange(res.PollOptions);

            this.cntx.Polls.Remove(res);

            this.cntx.SaveChanges();
        }

    }
}
