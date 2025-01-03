using Core;
using Infra.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositories.Interfaces
{
    public interface IFeedRepo:IGenericRepo<Feeds>
    {
        void CreateFeed(FeedsPhotoVideoVM rec,long memberId);
        List<Feeds> GetFeedListByMember(long memberId);
        EditFeedPhotoVideoVM GetFeedViewModelById(long memberId);
        void UpdateFeed(EditFeedPhotoVideoVM rec, long memberId);
        void DeleteFeed(long id);
        List<ShowFeedsVM> DisplayAllFeeds(long memberId);
        MemberFeedsVM GetMemberFeedById(long memberId);
    }
}
