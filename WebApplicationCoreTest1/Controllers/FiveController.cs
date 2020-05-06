using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplicationCoreTest1.Common.Filter;

namespace WebApplicationCoreTest1.Controllers
{
    public class FiveController : Controller
    {
        [CustomResourceFilter]
        [CustomActionFilter]
        [CustomResultFilter]
        public IActionResult Index()
        {
            Console.WriteLine("Index Controller");
            return View();
        }

        //[CustomCacheResourceFilter]
        //[ResponseCache(Duration = 60)]//浏览器缓存
        [CustomClientCacheResultFilter(Duration = 600)]
        public IActionResult ResourceCacheTest()
        {
            //浏览器缓存
            //HttpContext.Response.Headers["Cache-Control"] = "public,max-age=600";
            ViewBag.Time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff");
            return View();
        }
    }
}