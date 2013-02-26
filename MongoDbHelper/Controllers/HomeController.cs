using System.Web.Mvc;

namespace MongoDbHelper.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Index(string objectIds)
        {


            return View();
        }
    }
}
