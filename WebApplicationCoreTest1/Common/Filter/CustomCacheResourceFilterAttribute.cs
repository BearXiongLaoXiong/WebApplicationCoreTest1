using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace WebApplicationCoreTest1.Common.Filter
{
    public class CustomCacheResourceFilterAttribute : Attribute, IResourceFilter, IFilterMetadata, IOrderedFilter
    {
        private static readonly Dictionary<string, IActionResult> Dictionary = new Dictionary<string, IActionResult>();
        public int Order => 0;
        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            var key = context.HttpContext.Request.Path;
            if (Dictionary.ContainsKey(key))
                context.Result = Dictionary[key];
        }

        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            Dictionary.Add(context.HttpContext.Request.Path, context.Result);
            
        }
    }
}
