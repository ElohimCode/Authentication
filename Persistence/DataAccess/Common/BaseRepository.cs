using Application.Contracts.DataAccess.Common;
using Common.Utils.Tools;
using Domain.Common.Entity;
using Domain.Common.Enum;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.DataAccess.Common
{
    public class BaseRepository<TEntity, TKey> : IBaseRepository<TEntity, TKey>
        where TEntity : BaseEntity<TKey>
        where TKey : IComparable<TKey>
    {
        protected readonly ApplicationDbContext _context;

        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public virtual async Task CreateAsync(TEntity entity)
        {
            entity.CreatedAt = DataTimeUtils.Now();
            entity.UpdatedAt = DataTimeUtils.Now();
            entity.RecordStatus = RecordStatus.Active;
            await _context.Set<TEntity>().AddAsync(entity);
        }

        public Task<int> DeleteAsync(TEntity entity, bool soft = true)
        {
            return DeleteByIdAsync(entity.Id, soft);
        }

        public async Task<int> DeleteByIdAsync(TKey key, bool soft = true)
        {
            TEntity? entityDB = await GetByIdAsync(key);
            int count = 0;
            if (entityDB is not null)
            {
                if (soft) entityDB.RecordStatus = RecordStatus.Deleted;
                else _context.Set<TEntity>().Remove(entityDB);
                count = 1;
            }
            return count;
        }

        public Task<TEntity?> FirstOrDefaultAsync(Func<TEntity, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>()
                .ToListAsync();
        }

        public async Task<TEntity?> GetByIdAsync(TKey key)
        {
            return await _context.Set<TEntity>()
                .FirstOrDefaultAsync(entity => entity.Id.Equals(key));
        }

        public Task UpdateAsync(TKey key, TEntity entity)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            await Task.CompletedTask;
            _context.Set<TEntity>().Update(entity);
        }

        public async Task<IEnumerable<TEntity>> WhereAsync(Func<TEntity, bool> predicate)
        {
            await Task.CompletedTask;
            return _context.Set<TEntity>().Where(predicate);
        }
    }
}
