using System.Data.Entity.Migrations;
using Abp.MultiTenancy;
using Abp.Zero.EntityFramework;
using codestellar.bolierplate.Migrations.SeedData;
using EntityFramework.DynamicFilters;

namespace codestellar.bolierplate.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<bolierplate.EntityFramework.bolierplateDbContext>, IMultiTenantSeed
    {
        public AbpTenantBase Tenant { get; set; }

        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "bolierplate";
        }

        protected override void Seed(bolierplate.EntityFramework.bolierplateDbContext context)
        {
            context.DisableAllFilters();

            if (Tenant == null)
            {
                //Host seed
                new InitialHostDbBuilder(context).Create();

                //Default tenant seed (in host database).
                new DefaultTenantCreator(context).Create();
                new TenantRoleAndUserBuilder(context, 1).Create();
            }
            else
            {
                //You can add seed for tenant databases and use Tenant property...
            }

            context.SaveChanges();
        }
    }
}
