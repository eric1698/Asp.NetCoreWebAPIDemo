using log4net;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoAPI.Filter
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        private readonly ILog log = LogManager.GetLogger(Startup.repository.Name, typeof(GlobalExceptionFilter));

        public void OnException(ExceptionContext context)
        {
            log.Error(context.Exception);
        }
    }
}
