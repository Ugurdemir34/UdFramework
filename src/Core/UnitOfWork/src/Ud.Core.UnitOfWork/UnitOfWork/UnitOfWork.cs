using Microsoft.EntityFrameworkCore;
using Ud.Core.DDD.Abstractions;
using Ud.Core.UnitOfWork.Abstractions;

namespace Ud.Core.UnitOfWork.UnitOfWork
{
    public class UnitOfWork<TContext>(TContext context) : IUnitOfWork<TContext> where TContext : DbContext
    {
        public TContext Context { get; }
        public Dictionary<object, Type> repositories = new Dictionary<object, Type>();
        public void Dispose()
        {
            Context.Dispose();
            GC.SuppressFinalize(this);
        }

        public ICommandRepository<TEntity> GetCommandRepository<TEntity>() where TEntity : BaseEntity
        {
            if (repositories.Keys.Contains(typeof(TEntity)))
            {
                return repositories[typeof(TEntity)] as ICommandRepository<TEntity>;
            }
            var repository = new CommandRepository<TEntity>(Context);
            repositories.Add(repository, typeof(TEntity));
            return repository;
        }

        public IQueryRepository<TEntity> GetQueryRepository<TEntity>() where TEntity : BaseEntity
        {
            if (repositories.Keys.Contains(typeof(TEntity)))
            {
                return repositories[typeof(TEntity)] as IQueryRepository<TEntity>;
            }
            var repository = new QueryRepository<TEntity>(Context);
            repositories.Add(repository, typeof(TEntity));
            return repository;
        }
    }
}
