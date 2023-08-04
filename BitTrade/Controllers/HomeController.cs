using BitTrade.BLL;
using System.Linq;
using System.Web.Mvc;
using BitTrade.Controllers;
using System.Globalization;
using System.Web.Security;

namespace BitTrade.Controllers
{

    [Authorize(Users = "David,Poxos")]
    public class HomeController : BaseController
    {

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult UserProfile()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult LogIn(string email, string password)
        {
            //TODO: Change arguments 
            if (email == "davit.torosyan.2014@mai.ru" && password == "test")
            {
                FormsAuthentication.SetAuthCookie("davit.torosyan.2014@mai.ru", true);

                return RedirectToAction("Index");
            }
            return RedirectToAction("UserLogIn");
        }

        [AllowAnonymous]
        public ActionResult UserLogIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("UserLogIn");
        }


        public ActionResult Exchange()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
        public JsonResult GetUsers(string term)
        {
            var Users = UserService.GetUsers();
            var Data = Users.Where(u => u.FirstName.ToLower().Contains(term.ToLower()));

            return JsonNet(Data);
        }
    }
}