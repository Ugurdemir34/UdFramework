using Microsoft.EntityFrameworkCore;
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
    public class CommandRepository<T>(DbContext _context) : ICommandRepository<T> where T : BaseEntity
    {
        public async Task AddAsync(T entity)
        {
            var addedEntity = await _context.AddAsync(entity);
        }

        public async Task AddRangeAsync(List<T> entities)
        {
            await _context.AddRangeAsync(entities);
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = _context.Set<T>();
            var deletedEntity = await entity.FindAsync(id);
            deletedEntity.Delete();
            _context.Update(deletedEntity);
        }

        public async Task HardDeleteAsync(Guid id)
        {
            var entity = _context.Set<T>();
            var deleted = await entity.FindAsync(id);
            _context.Remove(deleted);
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _context.Update(entity);
            await Task.CompletedTask;
            return entity;
        }
    }
}
