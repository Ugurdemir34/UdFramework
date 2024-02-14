using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Ud.Core.DDD.Abstractions;

namespace Ud.Core.UnitOfWork.Abstractions
{
    public interface IQueryRepository<T> where T : BaseEntity
    {
        Task<T> GetAsync(Expression<Func<T, bool>> predicate,CancellationToken cancellationToken);
        Task<List<T>> ListAsync(Expression<Func<T, bool>> predicate);
        //Task<IPagedList<T>> QueryPagedListAsync(Expression<Func<T, bool>> predicate,
        //    Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
        //    Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
        //    int index = 1,
        //    int size = 20,
        //    CancellationToken cancellationToken = default);
    }
}
