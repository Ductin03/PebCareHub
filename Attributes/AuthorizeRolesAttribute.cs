using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace PebCareHub.Attributes
{
    public class AuthorizeRolesAttribute : Attribute, IAuthorizationFilter
    {
        private readonly string[] _roles;
        public AuthorizeRolesAttribute(params string[] roles) : base()
        {
            _roles = roles;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.User;
            if (user == null || !user.Identity.IsAuthenticated)
            {
                context.Result = new ForbidResult();
                return;
            }
            else
            {
                var role = user.Claims.FirstOrDefault(x => x.Type == "RoleName")?.Value;
                if (!_roles.Contains(role))
                {
                    context.Result = new ForbidResult();
                    return;
                }
            }
        }
    }
}
