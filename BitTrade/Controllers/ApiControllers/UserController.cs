using BitTrade.BLL.Services;
using BitTrade.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BitTrade.Controllers.ApiControllers
{
    public class UserController : ApiController
    {
        readonly IAccountService _accountService;
        readonly IUserService _userService;
        readonly IMessageService _messageService;
        public UserController(IAccountService accountService, IUserService userService, IMessageService messageService)
        {
            _accountService = accountService;
            _userService = userService;
            _messageService = messageService;
        }

        public IHttpActionResult Get()
        {
            return Ok(new string[] { "value1", "value2" });
        }
        public IHttpActionResult Get(int id)
        {
            return Ok("value1");
        }
        public IHttpActionResult Post([FromBody] string value)
        {
            return Ok(value);
        }
        public IHttpActionResult Put(UserModel model)
        {
            return Ok();
        }
    }
}
