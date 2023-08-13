using BitTrade.BLL.Services;
using BitTrade.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TradePlatform.Models;

namespace BitTrade.Controllers.ApiControllers
{
    public class UserController : ApiBaseController
    {
        private readonly IAccountService _accountService;
        private readonly IUserService _userService;
        private readonly IMessageService _messageService;
        public UserController(IAccountService accountService, IUserService userService, IMessageService messageService)
        {
            _accountService = accountService;
            _userService = userService;
            _messageService = messageService;
        }

        public IHttpActionResult Get(int id)
        {
            var user = _userService.GetUserByID(id);
            //var jsonOb = Newtonsoft.Json.JsonConvert.SerializeObject(user);

            return Ok(user);
        }
        public IHttpActionResult Post([FromBody] string value)
        {
            return Ok(value);
        }
        public IHttpActionResult Put(UserModel model)
        {
            if (!ModelState.IsValid)
            {
                throw new Exception("Ivalid input.");
            }

            try
            {
                _userService.Update(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Ok();
        }
    }
}
