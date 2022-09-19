using DungeonForceWoW.Data;
using DungeonForceWoW.Services;
using DungeonForceWoW.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DungeonForceWoW.Controllers
{
    public class AppController : Controller
    {
        private readonly IMailServices mailServices;
        private readonly IExempelRepository repository;


        //private readonly DungeonForceContext context; // lägg till DungeonForceContext context i construktorn

        public AppController(IMailServices mailServices, IExempelRepository repository) // interfacen i konstruktorn
        {
            this.mailServices = mailServices;
            this.repository = repository;

            //this.context = context;
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
        [Authorize]
        [HttpGet("shop")]
        public IActionResult Shop()
        {
            ViewBag.Title = "Shop of Dungeon Force";
            // Används när man använder sig av context
            //var result = from p in context.Products
            //             orderby p.Title
            //             select p;
            //return View(result.ToList());

            // används vid repository
            var result = repository.GetAllProducts();
            return View(result);
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Gallery()
        {
            ViewBag.Titel = "Gallery of Dungeon Force";
            return View();
        }
    }
}
