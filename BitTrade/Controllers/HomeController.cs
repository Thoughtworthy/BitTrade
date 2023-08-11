using BitTrade.BLL.Services;
using BitTrade.Common.Models;
using System.Web.Mvc;

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


        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult UserProfile(int? id)
        {
            if (id.HasValue)
            {
                UserModel user = _userService.GetUserByID(id.Value);
                if (user != null)
                {
                    return View(user);
                }
            }
            return View(new UserModel());
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult UserLogIn()
        {
            string returnUrl = Request.QueryString["ReturnUrl"];

            return View(new LoginModel { ReturnUrl = string.IsNullOrEmpty(returnUrl) ? "/" : returnUrl });

        }


        [HttpPost]
        [AllowAnonymous]
        public ActionResult UserLogIn(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("UserLogIn", model);
            }

            if (!_accountService.LogIn(model).IsSuccessful)
            {
                model.EmailErrorMessage = _accountService.LogIn(model).EmailErrorMessage;
                model.PasswordErrorMessage = _accountService.LogIn(model).PasswordErrorMessage;
                return View("UserLogIn", model);
            }

            return Redirect(model.ReturnUrl);
        }


        [HttpGet]
        [AllowAnonymous]
        public ActionResult UserRegistration()
        {
            return View(new RegisterModel());
        }


        [HttpPost]
        [AllowAnonymous]
        public ActionResult UserRegistration(RegisterModel model)
        {

            if (!ModelState.IsValid)
            {
                return View("UserRegistration", model);
            }

            if (!_accountService.Register(model).IsSuccessful)
            {
                model.EmailErrorMessage = _accountService.Register(model).EmailErrorMessage;

                return View("UserRegistration", model);
            }

            return Redirect("UserLogIn");

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


        public ActionResult Messenger()
        {
            return View();
        }

    }
}