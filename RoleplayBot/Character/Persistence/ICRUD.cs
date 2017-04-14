using System.Collections.Generic;

namespace RoleplayBot.Character.Persistence
{
    public interface ICRUD<T>
    {
        /// <summary>
        /// Create an entity.
        /// </summary>
        /// <param name="entity"></param>
        void Create(T entity);

        /// <summary>
        /// Return all entities.
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> Read();

        /// <summary>
        /// Return an entity identified by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T Read(int id);

        /// <summary>
        /// Update an existing entity.
        /// </summary>
        /// <param name="entity"></param>
        void Update(T entity);

        /// <summary>
        /// Remove an existing entity.
        /// </summary>
        /// <param name="id"></param>
        void Delete(int id);
    }
}