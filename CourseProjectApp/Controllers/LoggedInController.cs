using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CourseProjectApp.Controllers
{
    public class LoggedInController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult LogOut()
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index", "Main");
            }
            else
            {
                return RedirectToAction("Index", "LoggedIn");
            }
        }
    }
}