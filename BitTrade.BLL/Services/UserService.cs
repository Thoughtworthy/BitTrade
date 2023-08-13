using BitTrade.BLL.Extensions;
using BitTrade.Common.Helpers;
using BitTrade.Common.Models;
using BitTrade.DAL;
using BitTrade.DAL.Interfaces;
using System;

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
