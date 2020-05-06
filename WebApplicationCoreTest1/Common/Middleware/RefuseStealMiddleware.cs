using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace WebApplicationCoreTest1.Common.Middleware
{
    public class RefuseStealMiddleware
    {
        private readonly RequestDelegate _requestDelegate;

        public RefuseStealMiddleware(RequestDelegate requestDelegate)
        {
            _requestDelegate = requestDelegate;
        }

        public async Task Invoke(HttpContext context)
        {
            var url = context.Request.Path.Value;
            if (!url.Contains(".jpg")) await _requestDelegate(context);
            else await _requestDelegate(context);
            //var urlReferrer = context.Request.Headers["Referer"];
            //if (string.IsNullOrWhiteSpace(urlReferrer))
            //    await Set404Image(context);
            //else if (!urlReferrer.Contains("localhost"))
            //    await Set404Image(context);
            //else await _requestDelegate(context);

        }

        private async Task Set404Image(HttpContext context)
        {
            var f = File.OpenRead(@"C:\Xiong Program\CSharpObject\学习项目\AspNetCoreMvc学习\WebApplicationCoreTest1\WebApplicationCoreTest1\bin\Debug\netcoreapp3.1\1.png");
            var bytes = new byte[f.Length];
            await f.ReadAsync(bytes, 0, bytes.Length);
            await context.Response.Body.WriteAsync(bytes, 0, bytes.Length);
        }
    }
}
