using BitTrade.Common.Models;
using BitTrade.DAL;
using BitTrade.DAL.Interfaces;
using System;
using System.Linq;
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
            var User = _unitOfWork._userRepository.Get(u => u.Email == model.Email);
            bool isExist = false;

            if (User.Count() != 0)
            {
               isExist = User?.FirstOrDefault()?.Password == model.Password;
            }

            if (isExist)
            {
                //FormsAuthentication.SetAuthCookie(model.Email, true);
                var authTicket = new FormsAuthenticationTicket(1, model.Email, DateTime.Now, DateTime.Now.AddMinutes(10080), model.RememberMe, "Moderator:Admin");
                var encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);

                HttpContext.Current.Response.Cookies.Add(authCookie);

                return true;
            }

            return false;
        }

        public void Register(EnrollModel model)
        {
            User user = new User
            {

                FirstName = model.FirstName,
                LastName = model.LastName,
                DateOfBirth = model.DateOfBirth,
                IsActive = model.IsActive,
                Email = model.Email,
                Gender = model.Gender,
                ImageURL = model.ImageURL,
                Password = model.Password,
                Role = model.Role,

            };
            _unitOfWork._userRepository.Insert(user);
            //TODO: reg 
            _unitOfWork.Commit();
        }

        public void SignOut()
        {
            FormsAuthentication.SignOut();
        }
    }
}
