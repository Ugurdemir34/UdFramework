using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Ud.Core.DDD.Abstractions;
using Ud.Core.UnitOfWork.Abstractions;

namespace Ud.Core.UnitOfWork.Repository
{
    public class QueryRepository<T>(DbContext _context) : IQueryRepository<T> where T : BaseEntity
    {
        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken)
        {
            if (predicate is null)
            {
                return null;
            }
            var value = await _context.Set<T>().FirstOrDefaultAsync(predicate, cancellationToken);
            if (value is null)
            {
                return null;
            }
            return value;
        }

        public async Task<List<T>> ListAsync(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate).ToList();
        }
    }
}
