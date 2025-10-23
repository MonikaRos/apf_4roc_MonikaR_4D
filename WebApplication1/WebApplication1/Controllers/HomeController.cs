using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using UserApp.DataLayer.Entities;
using UserApp.datalayer;
using System.Diagnostics;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;

        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }


        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Users()
        {
            var users = _context.Users.ToList();
            return View(users);
        }

        public IActionResult UserDetail(Guid userPublicId)
        {
            var user = _context.Users.FirstOrDefault(u => u.PublicId == userPublicId);
            if (user == null)
                return NotFound();

            return View(user);
        }

        [HttpGet]
        public IActionResult CreateUser()
        {
            return View(new CreateUserModel());
        }

        [HttpPost]
        public IActionResult CreateUser(CreateUserModel model)
        {
            if (ModelState.IsValid)
            {
                var newUser = new UserEntity
                {
                    PublicId = Guid.NewGuid(),
                    Name = model.Name,
                    Email = model.Email
                };

                _context.Users.Add(newUser);
                _context.SaveChanges();

                return RedirectToAction("Users");
            }

            return View(model);
        }


        [HttpGet]
        public IActionResult EditUser(Guid userPublicId)
        {
            var user = _context.Users.FirstOrDefault(u => u.PublicId == userPublicId);
            if (user == null)
                return NotFound();

            ViewBag.UserPublicId = user.PublicId;

            var model = new CreateUserModel
            {
                Name = user.Name,
                Email = user.Email
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult EditUser(Guid userPublicId, CreateUserModel model)
        {
            var user = _context.Users.FirstOrDefault(u => u.PublicId == userPublicId);
            if (user == null)
                return NotFound();

            if (ModelState.IsValid)
            {
                user.Email = model.Email; 
                _context.SaveChanges();
                return RedirectToAction("Users");
            }

            return View(model);
        }

        
        [HttpPost]
        public IActionResult DeleteUser(Guid userPublicId)
        {
            var user = _context.Users.FirstOrDefault(u => u.PublicId == userPublicId);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }

            return RedirectToAction("Users");
        }

        
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
