using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApplicationCoreTest1.Common.Filter
{
    public class CustomFilterFactoryAttribute : Attribute, IFilterFactory
    {
        private readonly Type _type;
        public bool IsReusable { get; } = true;
        public CustomFilterFactoryAttribute(Type type)
        {
            _type = type;
        }
        public IFilterMetadata CreateInstance(IServiceProvider serviceProvider)
        {
            return serviceProvider.GetService(_type) as IFilterMetadata;

        }

    }
}
