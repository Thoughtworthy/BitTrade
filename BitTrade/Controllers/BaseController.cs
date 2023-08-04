using System.Web.Mvc;
using TradePlatform.Models;

namespace BitTrade.Controllers
{
    public class BaseController : Controller
    {
        public JsonResult JsonNet(object data)
        {
            return new JsonNetResult(data);
        }
    }
    
}
