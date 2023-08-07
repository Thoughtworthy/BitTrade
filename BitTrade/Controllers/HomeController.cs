using BitTrade.BLL;
using System.Linq;
using System.Web.Mvc;
using BitTrade.Common.Models;

namespace BitTrade.Controllers
{

    [Authorize]
    public class HomeController : BaseController
    {

        [AllowAnonymous]
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
        public ActionResult LogIn(LoginModel model)
        {
            if (AccountService.LogIn(model))
            {
                return Redirect($"{Request.Url.Scheme}://{Request.Url.Host}{model.ReturnUrl}");
            }
            else
            {
                return RedirectToAction("UserLogIn", new { ReturnUrl = model.ReturnUrl });
            }

        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult UserLogIn()
        {
            string returnUrl = Request.QueryString["ReturnUrl"];
            return View(new LoginModel { ReturnUrl = string.IsNullOrEmpty(returnUrl) ? "/" : returnUrl });

        }

        [HttpPost]
        public ActionResult SignOut()
        {
            AccountService.SignOut();

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