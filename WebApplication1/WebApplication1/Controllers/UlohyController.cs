using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class UlohyController : Controller
    {
        public IActionResult Uloha1()
        {
            return View();
        }

        public IActionResult Uloha2()
        {
            return View();
        }

        public IActionResult Uloha3()
        {
            return View();
        }

        public IActionResult Uloha4()
        {
            var userInfoList = new List<Models.UserInfo> {
                new UserInfo()
                {
                    Name = "Adam",
                    Email = "gmail.com",
                    Telephone = "059,4365",
                    Username = "vvsdf"
                },

                new UserInfo()
                {
                    Name = "Ondrej",
                    Email = "gmail.com",
                    Telephone = "085684365",
                    Username = "vvvsffdf"
                }
            };
          
            return View(userInfoList);
        }

        public IActionResult Uloha5()
        {
            var userInfoList = new List<Models.UserInfo> {
                new UserInfo()
                {
                    Name = "Adam",
                    Email = "gmail.com",
                    Telephone = "059,4365",
                    Username = "vvsdf"
                },

                new UserInfo()
                {
                    Name = "Ondrej",
                    Email = "gmail.com",
                    Telephone = "085684365",
                    Username = "vvvsffdf"
                }
            };
            return View(userInfoList);
        }

    }
}
