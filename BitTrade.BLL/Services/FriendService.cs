using BitTrade.BLL.Extensions;
using BitTrade.Common.Helpers;
using BitTrade.Common.Models;
using BitTrade.DAL;
using BitTrade.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace BitTrade.BLL.Services
{
    public class FriendService : IFriendService
    {

        private readonly IUnitOfWork _unitOfWork;

        public FriendService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Common.Models.FriendModel GetFriendByID(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<FriendShipModel> GetUsersContains(string term)
        {
            //var friends = _unitOfWork.FriendRepository.Get(u => u.ToUser.FirstName.Contains(term) )

            return null;
        }

        public void Update(Common.Models.FriendModel model)
        {
            throw new NotImplementedException();
        }
    }
}
