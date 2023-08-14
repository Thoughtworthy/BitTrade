using BitTrade.Common.Models;
using System.Collections.Generic;

namespace BitTrade.BLL.Services
{
    public interface IFriendService
    {
        FriendModel GetFriendByID(int id);
        IEnumerable<FriendShipModel> GetUsersContains(string term);
        void Update(FriendModel model);
    }
}
