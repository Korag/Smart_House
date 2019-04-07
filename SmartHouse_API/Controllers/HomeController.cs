using SmartHouse_API.DAL;
using System.Web.Mvc;


namespace SmartHouse_API.Controllers
{
    public class HomeController : Controller
    {
        private IDbOperative _context;

        public HomeController()
        {
            _context = new DbOperativeMethods();
        }

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
