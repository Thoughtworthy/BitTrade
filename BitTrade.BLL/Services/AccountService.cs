using BitTrade.Common.Models;
using BitTrade.DAL.Interfaces;
using System;
using System.Web;
using System.Web.Security;

namespace BitTrade.BLL.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork _unitOfWork;
        public AccountService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public bool LogIn(LoginModel model)
        {
            if (model.Email == "davit.torosyan.2014@mai.ru" && model.Password == "test")
            {

                //FormsAuthentication.SetAuthCookie("davit.torosyan.2014@mai.ru", true);
                var authTicket = new FormsAuthenticationTicket(1, "davit.torosyan.2014@mai.ru", DateTime.Now, DateTime.Now.AddMinutes(10080), model.RememberMe, "Moderator:Admin");
                var encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);

                HttpContext.Current.Response.Cookies.Add(authCookie);

                return true;
            }

            return false;
        }

        public void SignOut()
        {
            FormsAuthentication.SignOut();
        }
    }
}
