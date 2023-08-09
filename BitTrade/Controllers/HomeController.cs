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
                return Redirect(model.ReturnUrl);
            }
            else
            {
                return View("UserLogIn", model);
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

        [HttpGet]
        [AllowAnonymous]
        public ActionResult UserRegistration()
        {
            return View(new EnrollModel());
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult UserRegistration(EnrollModel model)
        {
            bool valid = ModelState.IsValid;
            if (valid)
            {
                _accountService.Register(model);
                return Redirect("UserLogIn");
            }
            else
            {
                return View(model);
            }

        }


        public ActionResult Exchange()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
        #endregion



    }
}