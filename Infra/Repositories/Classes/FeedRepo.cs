using Core.Enums;
using Core;
using Infra.Repositories.Interfaces;
using Infra.ViewModels;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories.Classes
{
    public class FeedRepo:GenericRepo<Feeds>, IFeedRepo
    {
        
        Context cntx;
        public FeedRepo(Context cntx):base(cntx)
        {
            this.cntx = cntx;
        }

        public void CreateFeed(FeedsPhotoVideoVM rec, long memberId)
        {
            var feed = new Feeds
            {
                FeedsDate = DateTime.Now, 
                FeedsTitle = rec.FeedTitle,
                FeedType = rec.FeedType,
                FeedsDescription = rec.FeedsDescription,
                FeedStatus = FeedStatusEnum.Pending, 
                MemberId = memberId
            };

            if (rec.FeedType == FeedTypeEnum.Photo && !string.IsNullOrEmpty(rec.PhotoPathFile))
            {
                feed.FeedsPhotos.Add(new FeedsPhoto
                {
                    PhotoPathFile = rec.PhotoPathFile
                });
            }
           
            else if (rec.FeedType == FeedTypeEnum.Video && !string.IsNullOrEmpty(rec.VideoUrl))
            {
                feed.FeedsVideos.Add(new FeedsVideo
                {
                    VideoUrl = rec.VideoUrl
                });
            }

            this.cntx.Feeds.Add(feed);
            this.cntx.SaveChanges(); 
        }


        public List<Feeds> GetFeedListByMember(long memberId)
        {
            var res = this.cntx.Feeds.Where(p => p.MemberId == memberId && 
                        p.FeedStatus == FeedStatusEnum.Accepted).ToList();

            return res;
        }


        public EditFeedPhotoVideoVM GetFeedViewModelById(long id)
        {
            var fd= this.cntx.Feeds.
                Include(f => f.FeedsPhotos)
               .Include(f => f.FeedsVideos)
               .FirstOrDefault(f => f.FeedsId == id);

            return new EditFeedPhotoVideoVM
            {
                FeedsId = fd.FeedsId,
                FeedTitle = fd.FeedsTitle,
                FeedsDescription = fd.FeedsDescription,
                FeedType = fd.FeedType,
                PhotoPathFile = fd.FeedsPhotos.FirstOrDefault()?.PhotoPathFile, 
                VideoUrl = fd.FeedsVideos.FirstOrDefault()?.VideoUrl 
            };
        }

        public void UpdateFeed(EditFeedPhotoVideoVM rec, long memberId)
        {
            var existingFeed = this.cntx.Feeds
                .Include(f => f.FeedsPhotos)
                .Include(f => f.FeedsVideos)
                .FirstOrDefault(f => f.FeedsId == rec.FeedsId);

            if (existingFeed != null)
            {
                existingFeed.FeedsTitle = rec.FeedTitle;
                existingFeed.FeedsDescription = rec.FeedsDescription;

                if (rec.FeedType == FeedTypeEnum.Photo)
                {
                    if (!string.IsNullOrEmpty(rec.PhotoPathFile))
                    {
                        if (existingFeed.FeedsPhotos.Any())
                        {
                            var existingPhoto = existingFeed.FeedsPhotos.First();
                            existingPhoto.PhotoPathFile = rec.PhotoPathFile; 
                        }
                        else 
                        {
                            existingFeed.FeedsPhotos.Add(new FeedsPhoto
                            {
                                PhotoPathFile = rec.PhotoPathFile
                            });
                        }
                    }
                }
             
                else if (rec.FeedType == FeedTypeEnum.Video)
                {
                    if (!string.IsNullOrEmpty(rec.VideoUrl)) 
                    {
                       
                        if (existingFeed.FeedsVideos.Any())
                        {
                            var existingVideo = existingFeed.FeedsVideos.First();
                            existingVideo.VideoUrl = rec.VideoUrl; 
                        }
                        else 
                        {
                            existingFeed.FeedsVideos.Add(new FeedsVideo
                            {
                                VideoUrl = rec.VideoUrl
                            });
                        }
                    }
                }

                
                this.cntx.SaveChanges();
            }
        }


        public void DeleteFeed(long id)
        {
            var fd = this.cntx.Feeds
                    .Include(f => f.FeedsPhotos)
                    .Include(f => f.FeedsVideos)
                    .FirstOrDefault(f => f.FeedsId == id);

            if (fd != null)
            {
                
                if (fd.FeedsPhotos != null)
                {
                    this.cntx.FeedsPhotos.RemoveRange(fd.FeedsPhotos);
                }

                
                if (fd.FeedsVideos != null)
                {
                    this.cntx.FeedsVideos.RemoveRange(fd.FeedsVideos);
                }

                
                this.cntx.Feeds.Remove(fd);
                this.cntx.SaveChanges();
            }
        }

        public List<ShowFeedsVM> DisplayAllFeeds(long memberId)
        {
            var fd = this.cntx.Feeds.
                   Include(p => p.Member).
                   Include(p => p.FeedsPhotos).
                   Include(p => p.FeedsVideos).
                   Where(p => p.FeedStatus == FeedStatusEnum.Accepted).
                   OrderByDescending(p => p.FeedsDate).
                   Select(p => new ShowFeedsVM
                   {
                       FeedsId = p.FeedsId,
                       FeedsTitle = p.FeedsTitle,
                       FeedsDescription = p.FeedsDescription,
                       FeedsDate = p.FeedsDate,
                       MemberName = (p.MemberId == memberId) ? "You" : p.Member.FullName,
                       FeedType = p.FeedType,
                       PhotoPathFile = p.FeedsPhotos.Select(p=>p.PhotoPathFile).ToList(),
                       VideoUrl = p.FeedsVideos.Select(p=>p.VideoUrl).ToList(),
                   });

            return fd.ToList();
        }

        public MemberFeedsVM GetMemberFeedById(long memberId)
        {
            var mb = this.cntx.Members
                    .Where(m => m.MemberId == memberId)
                    .Select(m => new MemberFeedsVM
                    {
                        MemberId = m.MemberId,
                        FullName = m.FullName,
                        EmailId = m.EmailId,
                        ProfilePicture= m.ProfilePicture,
                        Gender = m.Gender,
                        Address = m.Address,
                        City = m.City.CityName
                        
                    }).FirstOrDefault();


            mb.MemberFeeds = this.cntx.Feeds
                            .Include(p => p.FeedsPhotos)
                            .Include(p => p.FeedsVideos)
                            .Where(p => p.MemberId == memberId && p.FeedStatus == FeedStatusEnum.Accepted)
                            .OrderByDescending(p => p.FeedsDate)
                            .Select(p => new ShowFeedsVM
                            {
                                FeedsId = p.FeedsId,
                                FeedsTitle = p.FeedsTitle,
                                FeedsDescription = p.FeedsDescription,
                                FeedsDate = p.FeedsDate,
                                PhotoPathFile = p.FeedsPhotos.Select(fp => fp.PhotoPathFile).ToList(),
                                VideoUrl = p.FeedsVideos.Select(fv=>fv.VideoUrl).ToList(),
                                FeedType= p.FeedType
                            }).ToList();

            return mb;

        }
    }
}
