using BitTrade.Common.Models;
using System;
using System.Web;
using System.Web.Security;

namespace BitTrade.BLL.Services
{
    public interface IAccountService
    {
        LoginResultModel LogIn(LoginModel model);
        void SignOut();
        RegisterResultModel Register(RegisterModel model);
    }
}
