using BitTrade.Common.Models;
using BitTrade.DAL;
using BitTrade.DAL.Interfaces;
using BitTrade.DAL.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace BitTrade.BLL.Services
{
    public interface ISecurityService
    {
        string GetRandomString();

        string GetSHA256(string content);
        bool ValidatePassword(string inputPassword, string userPassword, string salt);
    }
}
