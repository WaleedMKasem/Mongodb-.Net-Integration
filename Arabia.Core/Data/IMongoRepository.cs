using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Arabia.Core.Data
{
    /// <summary>
    /// Repository
    /// </summary>
    public partial interface IMongoRepository<T> where T : BaseEntity
    {
        /// <summary>
        /// Get entity by identifier
        /// </summary>
        /// <param name="id">Identifier</param>
        /// <returns>Entity</returns>
        T GetById(ObjectId id);

        /// <summary>
        /// Insert entity
        /// </summary>
        /// <param name="entity">Entity</param>
        bool Add(T entity);
        
        /// <summary>
        /// Update entity
        /// </summary>
        /// <param name="entity">Entity</param>
        bool Update(T entity);

        bool Increment(Expression<Func<T, long>> field, ObjectId id);

        /// <summary>
        /// Delete entity
        /// </summary>
        /// <param name="id">Entity</param>
        bool Remove(ObjectId id);
        
        /// <summary>
        /// Searches for a list of entities that match a specified predicate
        /// </summary>
        /// <param name="predicate">Predicate to use when searching for entities</param>
        /// <returns></returns>
        IList<T> GetBySpec(Expression<Func<T, bool>> predicate);

        IList<T> GetByQuery(IMongoQuery query);

        /// <summary>
        /// Gets a Collection
        /// </summary>
        IQueryable<T> Collection { get; }
    }
}
