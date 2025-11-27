using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using System.Collections.Generic;

namespace WebApplication1.Controllers
{
    public class UserController : Controller
    {
        
        private static List<UserInfo> userList { get; set; } = new List<UserInfo>();

        [HttpGet]
        public IActionResult UserForm()
        {
            return View(new UserInfo());
        }

        [HttpPost]
        public IActionResult UserForm(UserInfo user)
        {
            if (ModelState.IsValid)
            {
                userList.Add(user);
                return RedirectToAction("UserDetail");
            }

            return View(user);
        }

        [HttpGet]
        public IActionResult UserDetail()
        {
            
            return View(userList);
        }


    }
}
