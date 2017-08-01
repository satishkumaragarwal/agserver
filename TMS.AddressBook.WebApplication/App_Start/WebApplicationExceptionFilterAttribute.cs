using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;
using TMS.AddressBook.Logging;

namespace TMS.AddressBook.WebApplication.App_Start
{
    public class WebApplicationExceptionFilterAttribute : ExceptionFilterAttribute
    {
        ILogger _log;
        public WebApplicationExceptionFilterAttribute(ILogger log)
        {
            _log = log;
        }

        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            _log.WriteErrorLogToFile("Exception : " + actionExecutedContext.Exception.Message);
            actionExecutedContext.Response = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.InternalServerError);
        }
    }
}