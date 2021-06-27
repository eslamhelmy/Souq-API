using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;
using Souq.ViewModels;

namespace Souq.API.Middlewares
{
    
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class CheckTokenAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = (UserViewModel)context.HttpContext.Items["User"];
            //context.HttpContext.Request.Headers.TryGetValue("token", out headerValue);
            if (user == null)
            {

                // not logged in
                context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
            }

        }
    }
}
