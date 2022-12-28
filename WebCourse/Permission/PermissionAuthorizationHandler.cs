using Domin.Entity;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace WebCourse.Permission
{
    public class PermissionAuthorizationHandler : AuthorizationHandler<PermissionRequirement>
    {
        public PermissionAuthorizationHandler()
        {

        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
        {
            if (context.User == null)
                return;

            var Permission = context.User.Claims.Where(x => x.Type == Helper.Permission && x.Issuer == "LOCAL AUTHORITY");

            if (Permission.Any())
            {
                context.Succeed(requirement);
                return;
            }
        }


    }
}
