using codestellar.bolierplate.EntityFramework;
using EntityFramework.DynamicFilters;

namespace codestellar.bolierplate.Migrations.SeedData
{
    public class InitialHostDbBuilder
    {
        private readonly bolierplateDbContext _context;

        public InitialHostDbBuilder(bolierplateDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            _context.DisableAllFilters();

            new DefaultEditionsCreator(_context).Create();
            new DefaultLanguagesCreator(_context).Create();
            new HostRoleAndUserCreator(_context).Create();
            new DefaultSettingsCreator(_context).Create();
        }
    }
}
