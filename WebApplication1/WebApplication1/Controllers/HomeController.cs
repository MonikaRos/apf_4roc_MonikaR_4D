using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication1.Models;
using UserApp.DataLayer.Entities;
using SQLitePCL;
using UserApp.datalayer;


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

        public IActionResult Users()
        {
            var userList = _context.Users.ToList();
            
            return View(userList);
        }

        public IActionResult UserDetail(Guid userPublicId)
        {
            var user = _context.Users.FirstOrDefault(u => u.PublicId == userPublicId);
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



        public IActionResult Index()
        {
            return View();
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
