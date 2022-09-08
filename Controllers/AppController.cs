using DungeonForceWoW.Services;
using DungeonForceWoW.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DungeonForceWoW.Controllers
{
    public class AppController : Controller
    {
        private readonly IMailServices mailServices;

        public AppController(IMailServices mailServices)
        {
            this.mailServices = mailServices;
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
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
    }
}
