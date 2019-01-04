using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseProjectApp.Entities;
using CourseProjectApp.Models;
using CourseProjectApp.Models.CSharp;
using CourseProjectApp.Services;
using CourseProjectApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using static CourseProjectApp.Models.CSharp.CSharp6.Static6;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CourseProjectApp.Controllers
{
    

    public class HomeController : Controller
    {
        //private readonly FirstClass _secondInstance;

        //private readonly AccessModifiers _accessModifiers;

        private IMyInjectedService myService;
        private ProfileContext _myContext;
        public HomeController(IMyInjectedService myService,ProfileContext context)
        {
            this.myService = myService;
            this._myContext = context;
        }

        //public HomeController(FirstClass firstInstance, AccessModifiers accessModifiers)
        //{
        //    _secondInstance = firstInstance;
        //    _accessModifiers = accessModifiers;
        //}

        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            var item = await GetGuid();
            ViewBag.myobject = this.myService;
            //SeedData.Seed(_myContext);
            return View(item);
        }

        public IActionResult FirstView()
        {
            //var model = new MyData{MyId = 3,MyValue = "My View"};
            var model = new List<MyData> {
                new MyData{ MyId = 1, MyValue = "First"},
                 new MyData{ MyId = 2, MyValue = "Second"}
            };

            var viewmodel = new FirstViewViewModel();
            viewmodel.MyType = model;

            return View(viewmodel);
        } 

        public ContentResult IdRoute()
        {
            return Content("Attribute Routing");
        }

        //return types
        public JsonResult MyObject()
        {
            var mymodel = new MyData { MyId = 1, MyValue = "My First Value"};

            return new JsonResult(mymodel);
        }

        private async Task<IMyInjectedService> GetGuid()
        {

            return await Task.FromResult(myService);

        }
        public IActionResult Error()
        {
            return View();
        }
    }
}
