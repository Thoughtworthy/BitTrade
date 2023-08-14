using BitTrade.Common.Helpers;
using BitTrade.Common.Models;
using BitTrade.DAL.Interfaces;
using BitTrade.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BitTrade.DAL.Repositories
{
    public class FriendRepository : Repository<Friend>, IFriendRepository
    {
        public FriendRepository(TradeEntities context) : base(context) { }

    }
}
