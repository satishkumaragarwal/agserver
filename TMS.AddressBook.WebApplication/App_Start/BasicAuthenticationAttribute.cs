using System;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace TMS.AddressBook.WebApplication.App_Start
{
    public class BasicAuthenticationAttribute : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (actionContext.Request.Headers.Authorization == null)
            {
                actionContext.Response = actionContext.Request.
                    CreateResponse(HttpStatusCode.Unauthorized);
            }
            else
            {
                string authenticationtoken = actionContext.Request.Headers.Authorization.Parameter;
                string decodedtoken = Encoding.UTF8.GetString(Convert.FromBase64String(authenticationtoken));
                string[] UserNamePasswordArray = decodedtoken.Split(':');
                string username = UserNamePasswordArray[0];
                string password = UserNamePasswordArray[1];

                if (BusinessLayer.BusinessLayer.Login(username, password))
                {
                    Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(username), null);
                }
                else
                {
                    actionContext.Response = actionContext.Request.
                   CreateResponse(HttpStatusCode.Unauthorized);
                }
            }
        }
    }
}