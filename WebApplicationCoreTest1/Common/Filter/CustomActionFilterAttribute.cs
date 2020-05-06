using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApplicationCoreTest1.Common.Filter
{
    public class CustomActionFilterAttribute : Attribute, IActionFilter, IFilterMetadata
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine("Action OnActionExecuted ");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine("Action OnActionExecuting ");
        }
    }

    public class CustomControllerFilterAttribute : Attribute, IActionFilter, IFilterMetadata
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine("CustomControllerFilterAttribute OnActionExecuted ");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine("CustomControllerFilterAttribute OnActionExecuting ");
        }
    }

    public class CustomGlobaFilterAttribute : Attribute, IActionFilter, IFilterMetadata
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine("CustomGlobaFilterAttribute OnActionExecuted ");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine("CustomGlobaFilterAttribute OnActionExecuting ");
        }
    }

    public class CustomResultFilterAttribute : Attribute, IResultFilter, IFilterMetadata, IOrderedFilter
    {
        public int Order { get; } = 0;
        public void OnResultExecuted(ResultExecutedContext context)
        {
            Console.WriteLine("CustomResultFilterAttribute OnResultExecuted ");
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            Console.WriteLine("CustomResultFilterAttribute OnResultExecuting ");
        }

    }

    public class CustomResourceFilterAttribute : Attribute, IResourceFilter, IFilterMetadata, IOrderedFilter
    {
        public int Order { get; } = 0;
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            Console.WriteLine("CustomResourceFilterAttribute OnResourceExecuted ");
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            Console.WriteLine("CustomResourceFilterAttribute OnResourceExecuting ");
        }
    }


    public class CustomClientCacheResultFilterAttribute : Attribute, IResultFilter, IFilterMetadata, IOrderedFilter
    {
        public int Duration { get; set; } = 60;
        public int Order { get; } = 0;
        public void OnResultExecuted(ResultExecutedContext context)
        {
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            context.HttpContext.Response.Headers["Cache-Control"] = $"public,max-age={Duration}";

        }

    }
}
