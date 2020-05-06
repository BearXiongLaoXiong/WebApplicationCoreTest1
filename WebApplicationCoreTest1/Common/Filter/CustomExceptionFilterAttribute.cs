using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace WebApplicationCoreTest1.Common.Filter
{
    public class CustomExceptionFilterAttribute : ExceptionFilterAttribute
    {
        private readonly ILogger<CustomExceptionFilterAttribute> _logger;
        public CustomExceptionFilterAttribute(ILogger<CustomExceptionFilterAttribute> logger)
        {
            _logger = logger;
        }
        public override void OnException(ExceptionContext context)
        {
            if (!context.ExceptionHandled)
            {
                Console.WriteLine($"异常:{context.HttpContext.Request.Path}");
                _logger.LogInformation($"异常:{context.HttpContext.Request.Path}");
                context.Result = new JsonResult(new
                {
                    Code = 999,
                    Message = "Error haha 123"
                });
                context.ExceptionHandled = true;
            }
            //base.OnException(context);
        }
    }
}
