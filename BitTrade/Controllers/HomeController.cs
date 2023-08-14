using BitTrade.BLL.Services;
using BitTrade.Common.Models;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

namespace BitTrade.Controllers
{

    [Authorize]
    public class HomeController : BaseController
    {
        readonly IAccountService _accountService;
        readonly IUserService _userService;
        readonly IMessageService _messageService;
        public HomeController(IAccountService accountService, IUserService userService, IMessageService messageService)
        {
            _accountService = accountService;
            _userService = userService;
            _messageService = messageService;
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
        [HttpGet]
        public ActionResult Messages(int? id)
        {
            var model = _messageService.GetConversations(id);

            return View(model);
        }


        [HttpGet]
        public ActionResult MessagesPartial(int id)
        {
            var model = _messageService.GetByUserID(id);
            if (model == null)
            {
                return PartialView("_Messages", new MessageModel());
            }
            return PartialView("_Messages", model);
        }

        public ActionResult Exchange()
        {
            return View();
        }

        public ActionResult Search()
        {
            return View();
        }
        public ActionResult SearchPartial(string data)
        {
            string decodedData = HttpUtility.UrlDecode(data);
            FriendShipModel[] models = JsonConvert.DeserializeObject<FriendShipModel[]>(decodedData);

            return PartialView("_Search", models);
        }


    }
}