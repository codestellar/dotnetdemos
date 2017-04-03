using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;

namespace codestellar.bolierplate.EntityFramework.Repositories
{
    public abstract class bolierplateRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<bolierplateDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected bolierplateRepositoryBase(IDbContextProvider<bolierplateDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //add common methods for all repositories
    }

    public abstract class bolierplateRepositoryBase<TEntity> : bolierplateRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected bolierplateRepositoryBase(IDbContextProvider<bolierplateDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //do not add any method here, add to the class above (since this inherits it)
    }
}
