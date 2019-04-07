using SmartHouse_API.Models;
using SmartHouse_API.DAL;
using System.Web.Mvc;
using Type = SmartHouse_API.Models.Type;

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

            SmartDevice sm = new SmartDevice()
            {
                Name = "lightbulb1",
                Type = Type.type1,
                Localization = Localization.loc1,
                State = State.state1,
                Disabled = false
            };

            _context.ChangeSmartDeviceState(sm, State.state2);

            return View();
        }
    }
}
