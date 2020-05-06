using System;
using Microsoft.AspNetCore.Mvc;
using WebApplicationCoreTest1.Common.Filter;


namespace WebApplicationCoreTest1.Controllers
{
    //[CustomExceptionFilter]
    //[ServiceFilter(typeof(CustomExceptionFilterAttribute))]
    //[TypeFilter(typeof(CustomExceptionFilterAttribute))]
    //[CustomFilterFactory(typeof(CustomExceptionFilterAttribute))]
    [CustomControllerFilter]
    public class FourthController : Controller
    {
        //[CustomExceptionFilter]
        public IActionResult Index()
        {
            int a = 3;
            int b = 4;
            int c = b - a - 1;
            int d = 4 / c;
            return View();
        }

        [CustomActionFilter]
        public IActionResult IndexInfo()
        {
            Console.WriteLine("IndexInfo");
            return View();
        }
    }

    public interface ITest
    {
        void Run(string a, int b);
    }

    public class MyTest:ITest
    {
        public void Run(string a, int b)
        {
            Console.WriteLine($"运行Run:[{a} - {b}]");
        }
    }

}