using Microsoft.EntityFrameworkCore;

namespace Ud.Core.UnitOfWork.Abstractions
{
    public interface IUnitOfWork
    {
    }
    public interface IUnitOfWork<TContext> : IUnitOfWork,IRepositoryFactory<TContext>, IDisposable where TContext : DbContext
    {
        TContext Context { get; }
    }
}
