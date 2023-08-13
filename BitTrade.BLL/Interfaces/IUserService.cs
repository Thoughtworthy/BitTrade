using BitTrade.Common.Models;
using BitTrade.DAL;
using BitTrade.DAL.Interfaces;
using BitTrade.DAL.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace BitTrade.BLL.Services
{
    public interface IUserService
    {
        UserModel GetUserByID(int id);
        void Update(UserModel model);
    }
}
