using BitTrade.BLL.Extensions;
using BitTrade.Common.Helpers;
using BitTrade.Common.Models;
using BitTrade.DAL;
using BitTrade.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Claims;

namespace BitTrade.BLL.Services
{
    public class UserService : IUserService
    {
        readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public UserModel GetUserByID(int id)
        {
            var user = _unitOfWork.UserRepository.GetByID(id);

            return user.MapTo<UserModel>();

        }

        public IEnumerable<FriendShipModel> GetUsersContains(string term)
        {
            var users = _unitOfWork.UserRepository.Get(u => u.FirstName.Contains(term) || u.LastName.Contains(term) && u.ID != ClaimHelper.ID);
            var userModels = new List<FriendShipModel>();

            foreach (var user in users)
            {
                var friendRecord = _unitOfWork.FriendRepository
                                   .Get(u => u.FromUserID == user.ID || u.ToUserID == user.ID)
                                   .FirstOrDefault();

                bool? isFriend = friendRecord?.IsAccepted;
                var userModel = new FriendShipModel
                {
                    Id = user.ID,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    IsFriend = isFriend

                };
                userModels.Add(userModel);
            }

            return userModels;
        }

        public void Update(UserModel model)
        {

            var user = _unitOfWork.UserRepository.GetByID(model.ID);

            var claimID = ClaimHelper.ID;
            if (user == null || claimID != user.ID)
            {
                throw new Exception("You do not have permiton.");
            }

            if (model.Email != user.Email && _unitOfWork.UserRepository.Any(u => u.Email == model.Email))
            {
                throw new Exception("Email is already in use.");
            }


            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Email = model.Email;
            user.Gender = model.Gender;
            user.DateOfBirth = model.DateOfBirth;
            user.ImageURL = model.ImageURL;

            _unitOfWork.UserRepository.Update(user);
            _unitOfWork.Commit();
        }
    }
}
