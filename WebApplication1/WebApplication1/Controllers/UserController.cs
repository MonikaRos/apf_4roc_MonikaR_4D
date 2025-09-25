using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public IActionResult UserForm()
        {
            return View(new UserInfo());
        }

        [HttpPost]
        public IActionResult UserForm(UserInfo user)
        {
            return RedirectToAction("UserDetail", user);
        }

        [HttpGet]
        public IActionResult UserDetail(string name, string email, string telephone, string username, int age, string address)
        {
            var model = new UserInfo
            {
                Name = name,
                Email = email,
                Telephone = telephone,
                Username = username,
                Age = age,
                Address = address
            };

            return View(model);
        }
    }
}
