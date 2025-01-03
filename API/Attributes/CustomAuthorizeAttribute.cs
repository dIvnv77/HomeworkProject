﻿using API.Errors;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace API.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class CustomAuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        public CustomAuthorizeAttribute(params string[] roles)
        {
            this.Roles = roles;
        }

        public ICollection<string> Roles { get; }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            // skip authorization if action is decorated with [AllowAnonymous] attribute
            var allowAnonymous = context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any();
            if (allowAnonymous)
                return;

            // authorization
            if (!context.HttpContext.User.Identity.IsAuthenticated)
            {
                context.Result = new JsonResult(new ApiResponse(StatusCodes.Status401Unauthorized)) { StatusCode = StatusCodes.Status401Unauthorized };
                return;
            }

            bool isInRole = false;

            foreach (var role in this.Roles)
            {
                if (context.HttpContext.User.IsInRole(role))
                {
                    isInRole = true;
                    break;
                }
            }

            if (!isInRole)
            {
                context.Result = new JsonResult(new ApiResponse(StatusCodes.Status403Forbidden)) { StatusCode = StatusCodes.Status403Forbidden };
                return;
            }
        }
    }
}
