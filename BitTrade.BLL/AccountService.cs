using BitTrade.Common.Models;
using System;
using System.Web;
using System.Web.Security;

namespace BitTrade.BLL
{
    public class AccountService
    {
        public static bool LogIn(LoginModel model)
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

        public static void SignOut()
        {
            FormsAuthentication.SignOut();
        }
    }
}
