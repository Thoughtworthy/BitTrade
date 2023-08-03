using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BitTrade.DAL;
using BitTrade.Common.Models;

namespace BitTrade.BLL
{
    public class UserService
    {
        public static List<UserModels> GetUsers()
        {
            var User = UserRepository.GetUsers();

            var result = User.Select(p => new UserModels
            {
                ID = p.ID,
                FirstName = p.FirstName,
                Email = p.Email,
            }).ToList();
            return result;
        }
    }
}
