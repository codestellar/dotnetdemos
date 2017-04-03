using Abp.Authorization;
using codestellar.bolierplate.Authorization.Roles;
using codestellar.bolierplate.MultiTenancy;
using codestellar.bolierplate.Users;

namespace codestellar.bolierplate.Authorization
{
    public class PermissionChecker : PermissionChecker<Tenant, Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
