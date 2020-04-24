using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;
using System.Web.Http.Controllers;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading;
using System.Security.Principal;
using FlightManagementSystem.Modules;
using FlightManagementSystem.Modules.Login;
using FlightManagementSystem.Models;

namespace ASPProject2.Controllers
{
    public class BasicAdminAuthenticationAttribute : AuthorizationFilterAttribute
    {

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            BaseAuthenticationAttribute<LoginToken<Administrator>> baseAuth = new BaseAuthenticationAttribute<LoginToken<Administrator>>();
            baseAuth.OnAuthorization(actionContext, "User is not administrator. please try again");
        }

        /*
                public override void OnAuthorization(HttpActionContext actionContext)
                {
                    //actionContext.Response =  actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized, "you are not allowed");
                    if(actionContext.Request.Headers.Authorization == null)
                    {
                        actionContext.Response  = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized, "you must send username & password in basic authentication");
                        return;
                    }
                    string authenticationToken = actionContext.Request.Headers.Authorization.Parameter;
                    string decodeAuthorizationToken = Encoding.UTF8.GetString(Convert.FromBase64String(authenticationToken));
                    string[] usernamePasswordArray = decodeAuthorizationToken.Split(':');
                    string userName = usernamePasswordArray[0];
                    string password = usernamePasswordArray[1];

                    ILoginToken iLoginToken;
                    LoginService ls = new LoginService();
                    try
                    {
                        ls.TryLogin(password, userName, out iLoginToken);
                        //ILoginToken token = FlightCenterSystem.Login(userName, password, out BaseFacade facade);
                        if (iLoginToken is LoginToken<Administrator>)
                        {
                            actionContext.Request.Properties["token"] = iLoginToken;
                            actionContext.Request.Properties["username"] = userName;
                        }
                        else
                        {
                            actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized,
                                            "User is not admin. please try again");
                        }
                    }
                    catch (Exception ex)
                    {

                            actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized, "you are not allowed");          
                    }

                }
            */
    }
}