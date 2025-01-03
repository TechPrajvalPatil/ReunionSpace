using Core;
using Infra.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositories.Interfaces
{
    public interface IManageFeedRepo
    {
        List<Feeds> GetPendingFeeds();
        List<Feeds> GetAcceptedFeeds();
        List<Feeds> GetRejectedFeeds();
        void AcceptedFeed(long id);
        void RejectedFeed(long id);   

        FeedsDetailsVM GetFeedDetailsById(long id);
    }
}
