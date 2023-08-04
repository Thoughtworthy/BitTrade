using Newtonsoft.Json;
using System;
using System.Web.Mvc;

namespace TradePlatform.Models
{
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