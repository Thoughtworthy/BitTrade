using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BitTrade.Controllers
{
    public class UserController : ApiController
    {
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
    }
}
