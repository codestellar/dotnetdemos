using Abp.MultiTenancy;
using codestellar.bolierplate.Users;

namespace codestellar.bolierplate.MultiTenancy
{
    public class Tenant : AbpTenant<User>
    {
        public Tenant()
        {
            
        }

        public Tenant(string tenancyName, string name)
            : base(tenancyName, name)
        {
        }
    }
}