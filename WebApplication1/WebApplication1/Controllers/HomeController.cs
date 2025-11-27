using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using BusinessLayer.Inerfaces.Services;
using Common.Models;
using System.Diagnostics;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserService _userService;

        public HomeController(ILogger<HomeController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Users()
        {
            var users = await _userService.GetAllAsync();
            return View(users);
        }

        public async Task<IActionResult> UserDetail(Guid userPublicId)
        {
            var user = await _userService.GetByPublicIdAsync(userPublicId);
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
        public async Task<IActionResult> CreateUser(CreateUserModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var dto = new UserDTO
            {
                Name = model.Name,
                Email = model.Email
            };

            var success = await _userService.CreateAsync(dto);
            if (!success)
            {
                ModelState.AddModelError("", "Nepodarilo sa vytvoriù pouûÌvateæa.");
                return View(model);
            }

            return RedirectToAction("Users");
        }

        [HttpGet]
        public async Task<IActionResult> EditUser(Guid userPublicId)
        {
            var user = await _userService.GetByPublicIdAsync(userPublicId);
            if (user == null)
                return NotFound();

            var model = new CreateUserModel
            {
                Name = user.Name,
                Email = user.Email
            };

            ViewBag.UserPublicId = userPublicId;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditUser(Guid userPublicId, CreateUserModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var dto = new UserDTO
            {
                PublicId = userPublicId,
                Name = model.Name,
                Email = model.Email
            };

            await _userService.UpdateAsync(dto);
            return RedirectToAction("Users");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteUser(Guid userPublicId)
        {
            await _userService.DeleteAsync(userPublicId);
            return RedirectToAction("Users");
        }


        [HttpPost]
        public async Task<IActionResult> DeleteSelected(List<Guid> selectedIds)
        {
            if (selectedIds != null && selectedIds.Any())
            {
                foreach (var id in selectedIds)
                {
                    await _userService.DeleteAsync(id);
                }
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
