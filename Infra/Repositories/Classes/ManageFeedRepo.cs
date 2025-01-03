using Core;
using Core.Enums;
using Infra.Repositories.Interfaces;
using Infra.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositories.Classes
{
    public class ManageFeedRepo:IManageFeedRepo
    {
        Context cntx;
        public ManageFeedRepo(Context cntx)
        {
            this.cntx = cntx;
        }

        public List<Feeds> GetPendingFeeds()
        {
           var res = this.cntx.Feeds
                .Where(p=>p.FeedStatus==FeedStatusEnum.Pending)
                .OrderByDescending(p => p.FeedsDate);
            return res.ToList();
        }

        public List<Feeds> GetAcceptedFeeds()
        {
            var res = this.cntx.Feeds
                    .Where(p => p.FeedStatus == FeedStatusEnum.Accepted)
                    .OrderByDescending(p=>p.FeedsDate);
            return res.ToList();
        }

        public List<Feeds> GetRejectedFeeds()
        {
            var res = this.cntx.Feeds
                        .Where(p => p.FeedStatus == FeedStatusEnum.Rejected)
                        .OrderByDescending(p => p.FeedsDate);
            return res.ToList();
        }

        public void AcceptedFeed(long id)
        {
            var rec = this.cntx.Feeds.Find(id);
            if(rec != null)
            {
                rec.FeedStatus = FeedStatusEnum.Accepted;
                this.cntx.Update(rec);
                this.cntx.SaveChanges();
            }
        }


        public void RejectedFeed(long id)
        {
            var rec = this.cntx.Feeds.Find(id);
            if (rec != null)
            {
                rec.FeedStatus = FeedStatusEnum.Rejected;
                this.cntx.Update(rec);
                this.cntx.SaveChanges();
            }
        }

        public FeedsDetailsVM GetFeedDetailsById(long id)
        {
            var fd= this.cntx.Feeds.
                  Include(p=>p.FeedsPhotos).
                  Include(p=>p.FeedsVideos).
                  FirstOrDefault(p=>p.FeedsId == id);

            var res = new FeedsDetailsVM
            {
                FeedsId = fd.FeedsId,
                FeedsTitle = fd.FeedsTitle,
                FeedsDate = fd.FeedsDate,
                FeedsDescription = fd.FeedsDescription,
                FeedType = fd.FeedType.ToString(),
                FeedStatus = fd.FeedStatus.ToString(),
                PhotoPathFile = fd.FeedsPhotos.Select(p=>p.PhotoPathFile).ToList(),
                VideoUrl = fd.FeedsVideos.Select(v => v.VideoUrl).ToList()
            };

            return res; 
        }
    }
}
