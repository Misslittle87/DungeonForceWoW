using Microsoft.AspNetCore.Mvc;

namespace DungeonForceWoW.Controllers
{
    public class AppController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Title = "Dungeon Force";
            return View();
        }
        public IActionResult About()
        {
            ViewBag.Title = "About Dungeon Force";
            return View();
        }
        public IActionResult Contact()
        {
            ViewBag.Title = "Contact Dungeon Force";
            return View();
        }
        public IActionResult Shop()
        {
            ViewBag.Title = "Shop of Dungeon Force";
            return View();
        }
    }
}
