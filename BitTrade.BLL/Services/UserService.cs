using BitTrade.Common.Models;
using BitTrade.DAL;
using BitTrade.DAL.Interfaces;
using BitTrade.DAL.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace BitTrade.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public List<UserModels> GetUsers()
        {
            var User = _unitOfWork._userRepository.Get();

            // _unitOfWork.Commit();

            var result = User.Select(p => new UserModels
            {
                ID = p.ID,
                FirstName = p.FirstName,
                Email = p.Email,
                DateOfBirth = p.DateOfBirth,
            }).ToList();
            return result;
        }
    }
}
