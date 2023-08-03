using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BitTrade.Controllers
{
    public class BaseController : Controller
    {
        public JsonResult JsonNet(object data)
        {
            return new JsonNetResult(data);
        }
    }
    public class JsonNetResult : JsonResult
    {
        public JsonNetResult(object data)
        {
            Data = data;
        }
        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
                throw new ArgumentNullException("context");

            var response = context.HttpContext.Response;

            response.ContentType = !string.IsNullOrEmpty(ContentType)
                                   ? ContentType
                                   : "application/json";

            if (ContentEncoding != null)
                response.ContentEncoding = ContentEncoding;

            // If you need special handling, you can call another form of SerializeObject below
            var serializedObject = JsonConvert.SerializeObject(Data, Formatting.Indented);
            response.Write(serializedObject);
        }
    }
}
