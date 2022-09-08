using DungeonForceWoW.Data;
using DungeonForceWoW.Services;
using DungeonForceWoW.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DungeonForceWoW.Controllers
{
    public class AppController : Controller
    {
        private readonly IMailServices mailServices;
        private readonly DungeonForceContext context;

        public AppController(IMailServices mailServices, DungeonForceContext context)
        {
            this.mailServices = mailServices;
            this.context = context;
        }
        public IActionResult Index()
        {
            ViewBag.Title = "Dungeon Force";
            return View();
        }
        [HttpGet("about")]
        public IActionResult About()
        {
            ViewBag.Title = "About Dungeon Force";
            return View();
        }
        [HttpGet("contact")]
        public IActionResult Contact()
        {
            ViewBag.Title = "Contact us!";
            //throw new InvalidOperationException();
            return View();
        }        
        [HttpPost("contact")]
        public IActionResult Contact(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                mailServices.SendMessage("sofia@hansson.se", model.Subject, $"From: {model.Name} - {model.Email}, Message: {model.Message}");
                ViewBag.UserMessage = "Message sent";
                ModelState.Clear();
            }
            else
            {
                // Visa error
            }

            //throw new InvalidOperationException();
            return View();
        }
        [HttpGet("shop")]
        public IActionResult Shop()
        {
            ViewBag.Title = "Shop of Dungeon Force";
            var result = from p in context.Products
                         orderby p.Category
                         select p;
            return View(result.ToList());
        }
        public IActionResult Login()
        {
            return View();
        }
    }
}
