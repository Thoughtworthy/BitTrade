using BitTrade.Common.Models;
using System;
using System.Web;
using System.Web.Security;

namespace BitTrade.BLL.Services
{
    public interface IAccountService
    {
        bool LogIn(LoginModel model);
        void SignOut();
        void Register(EnrollModel model);
    }
}
