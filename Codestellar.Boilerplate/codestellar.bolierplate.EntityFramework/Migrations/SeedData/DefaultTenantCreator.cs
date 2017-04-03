using System.Linq;
using codestellar.bolierplate.EntityFramework;
using codestellar.bolierplate.MultiTenancy;

namespace codestellar.bolierplate.Migrations.SeedData
{
    public class DefaultTenantCreator
    {
        private readonly bolierplateDbContext _context;

        public DefaultTenantCreator(bolierplateDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateUserAndRoles();
        }

        private void CreateUserAndRoles()
        {
            //Default tenant

            var defaultTenant = _context.Tenants.FirstOrDefault(t => t.TenancyName == Tenant.DefaultTenantName);
            if (defaultTenant == null)
            {
                _context.Tenants.Add(new Tenant {TenancyName = Tenant.DefaultTenantName, Name = Tenant.DefaultTenantName});
                _context.SaveChanges();
            }
        }
    }
}
