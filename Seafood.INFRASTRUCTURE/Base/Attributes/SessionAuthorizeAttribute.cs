using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Seafood.INFRASTRUCTURE.Base.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seafood.INFRASTRUCTURE.Base.Attributes
{
    public class SessionAuthorizeAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        //protected override bool AuthorizeCore(HttpContext httpContext)
        //{
        //    bool isAuthroized = base.AuthorizeCore(httpContext);
        //    if (!isAuthroized)
        //        return false;

        //    return IsTokenValid(httpContext);
        //}

        //private bool IsTokenValid(HttpContext httpContext)
        //{
        //    UserData user = null;
        //    try
        //    {
        //        user = Seafood.MemCached.Authenticator.CurrentUser(httpContext);
        //        if (user != null)
        //        {
        //            return true;
        //        }
        //    }
        //    catch
        //    {

        //    }
        //    return false;
        //}
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!context.HttpContext.Session.TryGetValue("AccessTokenSession", out byte[] accessTokenSession))
            {
                context.Result = new ObjectResult(new ResponseModel() { Success = false, Message = $"You need login, you are hacker >.<", StatusCode = 401 }) { StatusCode = 401 };
            }
        }
    }
}
