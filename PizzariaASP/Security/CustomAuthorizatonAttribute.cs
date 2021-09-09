
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzariaASP.Security
{
    public class CustomAuthorizatonAttribute : Attribute, IAuthorizationFilter
    {
        private readonly string[] _roles;

        public CustomAuthorizatonAttribute(params string[] roles)
        {
            _roles = roles;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            string role = context.HttpContext.Session.GetString("Role");
            if (!_roles.Contains(role))
            {
                context.Result = new UnauthorizedResult();
            }
        }
    }
}
