using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using codestellar.bolierplate.EntityFramework;

namespace codestellar.bolierplate.Migrator
{
    [DependsOn(typeof(bolierplateDataModule))]
    public class bolierplateMigratorModule : AbpModule
    {
        public override void PreInitialize()
        {
            Database.SetInitializer<bolierplateDbContext>(null);

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}