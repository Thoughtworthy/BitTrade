using BitTrade.BLL;
using System.Linq;
using System.Web.Mvc;
using BitTrade.Controllers;

namespace BitTrade.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }
        [Authorize]
        public ActionResult UserProfile()
        {
            return View();
        }
        public ActionResult UserLogIn()
        {
            return View();
        }
        public ActionResult Exchange()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
        public JsonResult GetUsers(string term)
        {
            var Users = UserService.GetUsers();
            var Data = Users.Where(u => u.FirstName.ToLower().Contains(term.ToLower()));

            return JsonNet(Data);
        }
    }
}