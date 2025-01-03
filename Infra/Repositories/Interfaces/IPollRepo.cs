using Core;
using Infra.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositories.Interfaces
{
    public interface IPollRepo:IGenericRepo<Poll>
    {
        List<PollListCountVM> GetPollListCount();
        List<PollVM> GetNewOpenPolls(long memberId);
        List<ResponsePollVM> GetPollsOptions(long id);
        void SavePollResponse(long memberId, long pollId, long pollOptionId);
        List<PollVM> GetRespondedPolls(long memberId);
        PollResponseVM GetPollDetails(long pollId, long memberId);
        void UpdatePollResponse(long memberId, long pollId, long pollOptionId);
        List<MemberPollResponseVM> GetMemberResponse(Int64 pollId);
        void DeletePollWithDependencies(long pollId);


    }
}
