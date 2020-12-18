using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Model.CheckPermissions;

namespace Model.AuthorizationHandler
{
    public class CheckPermissionsHandler : AuthorizationHandler<CheckPermissionsRequirement>
    {
        ICheckPermissions checkPermissions;
        public CheckPermissionsHandler(ICheckPermissions checkPermissions)
        {
            this.checkPermissions = checkPermissions;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, CheckPermissionsRequirement requirement)
        {
            if(checkPermissions.CheckPermissionForUser(context.User, requirement.chucnang_id))
                context.Succeed(requirement);
            return Task.FromResult(0);
        }
    }
}
