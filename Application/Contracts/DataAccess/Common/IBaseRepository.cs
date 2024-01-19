using Domain.Common.Entity;

namespace Application.Contracts.DataAccess.Common
{
    public interface IBaseRepository<TEntity, TKey>
        where TEntity : BaseEntity<TKey>
        where TKey : IComparable<TKey>
    {
        /// <summary>
        /// Add an entity by key but get the key from entity
        /// </summary>
        /// <param name="entity">Entity Param with key</param>
        /// <returns>An entity</returns>
        Task CreateAsync(TEntity entity);

        Task<TEntity?> FirstOrDefaultAsync(Func<TEntity, bool> predicate);

        // Retrieve

        /// <summary>
        /// Retrieve a model by key
        /// </summary>
        /// <param name="key">Identity Param</param>
        /// <returns>A model</returns>
        Task<TEntity?> GetByIdAsync(TKey key);

        /// <summary>
        /// Retrieve all models
        /// </summary>
        /// <returns>All models</returns>
        Task<IEnumerable<TEntity>> GetAllAsync();

        /// <summary>
        /// Retrieve model(s) based on the query
        /// </summary>
        /// <param name="query">search parameter</param>
        /// <returns>All models that match the query</returns>
        Task<IEnumerable<TEntity>> WhereAsync(Func<TEntity, bool> predicate);

        // Update

        /// <summary>
        /// Make changes to an entity in the db
        /// </summary>
        /// <param name="key">Identity Params</param>
        /// <param name="entity">New entity</param>
        /// <returns>The new entity</returns>
        Task UpdateAsync(TKey key, TEntity entity);

        /// <summary>
        /// Make changes to an entity in the db using only entity
        /// </summary>
        /// <param name="entity">New entity</param>
        /// <returns>THe new entity</returns>
        Task UpdateAsync(TEntity entity);

        // Delete

        /// <summary>
        /// Remove an entity from db
        /// </summary>
        /// <param name="key">Identity Param</param>
        /// <param name="soft">Delete Param</param>
        /// <returns></returns>
        Task<int> DeleteByIdAsync(TKey key, bool soft = true);

        /// <summary>
        /// Remove an entity from db using entity
        /// </summary>
        /// <param name="entity">Entity containing Identity Param</param>
        /// <param name="soft">Delete Param</param>
        /// <returns></returns>
        Task<int> DeleteAsync(TEntity entity, bool soft = true);
    }
}

