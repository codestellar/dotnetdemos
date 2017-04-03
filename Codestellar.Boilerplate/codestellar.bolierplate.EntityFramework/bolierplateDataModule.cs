using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using Abp.Zero.EntityFramework;
using codestellar.bolierplate.EntityFramework;

namespace codestellar.bolierplate
{
    [DependsOn(typeof(AbpZeroEntityFrameworkModule), typeof(bolierplateCoreModule))]
    public class bolierplateDataModule : AbpModule
    {
        public override void PreInitialize()
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<bolierplateDbContext>());

            Configuration.DefaultNameOrConnectionString = "Default";
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
