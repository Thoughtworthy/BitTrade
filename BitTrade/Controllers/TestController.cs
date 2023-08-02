using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TradePlatform.Models;
using TradePlatform.Enums;

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


        [HttpGet]
        public ActionResult Test()
        {
            MyUser myUser = new MyUser()
            {
                ID = 1,
                FirstName = "Simon",
                IsActive = true,
                DayType = DayType.Day,
                Names = new List<string>
                {
                    "Nairobi",
                    "Denver",
                    "Tokyo",
                }
            };
            return View(myUser);
        }

        [HttpPost]
        public JsonResult Test(MyUser myUser)
        {

            return Json(myUser,JsonRequestBehavior.AllowGet);
        }


    }
}
