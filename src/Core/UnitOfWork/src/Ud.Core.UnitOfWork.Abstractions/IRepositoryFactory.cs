using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ud.Core.DDD.Abstractions;

namespace Ud.Core.UnitOfWork.Abstractions
{
    public interface IRepositoryFactory
    {

    }
    public interface IRepositoryFactory<TContext> : IRepositoryFactory where TContext : DbContext
    {
        ICommandRepository<TEntity> GetCommandRepository<TEntity>() where TEntity : BaseEntity;
        IQueryRepository<TEntity> GetQueryRepository<TEntity>() where TEntity : BaseEntity;

    }
}
