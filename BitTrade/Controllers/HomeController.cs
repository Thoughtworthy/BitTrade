using BitTrade.BLL.Services;
using System.Linq;
using System.Web.Mvc;
using BitTrade.Common.Models;

namespace BitTrade.Controllers
{

    [Authorize]
    public class HomeController : BaseController
    {
        readonly IAccountService _accountService;
        readonly IUserService _userService;
        public HomeController(IAccountService accountService, IUserService userService)
        {
            _accountService = accountService;
            _userService = userService;
        }

        #region
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
            if (_accountService.LogIn(model))
            {

                //Redirect($"{Request.Url.Scheme}://{Request.Url.Host}{model.ReturnUrl}");
                return Redirect(model.ReturnUrl);
            }
            else
            {
                return RedirectToAction("UserLogIn", new { model.ReturnUrl });
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
            _accountService.SignOut();

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
        public JsonResult GetUsers(string term = "a")
        {
            var Users = _userService.GetUsers();
            var Data = Users.Where(u => u.FirstName.ToLower().Contains(term.ToLower()));

            return JsonNet(Users);
        }
        #endregion



    }
}