using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BitTrade.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            return View();
        }
        public FileContentResult Foo(string arg)
        {
            byte[] result = System.Text.Encoding.UTF8.GetBytes(arg);

            return File(result, "text/plain"/*, "HehoHEho"*/); // For having download it 
        }

        // Like API

        public JsonResult JsonFoo(string flag)
        {
            string[] data;
            switch (flag)
            {
                case "Armenian":
                    data = new []{ "red", "blue", "orange" };
                    break;
                default:
                    data = new[] { "green", "white", "red" };
                    break;
            }
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public PartialViewResult MyPartal()
        {

            return PartialView("PartalView");
        }
    }
}
