using System.Collections.Generic;

namespace RoleplayBot.Persistence
{
    public interface IRepository<T>
    {
        void Create(T entity);

        IEnumerable<T> Read();

        T Read(int id);

        void Update(T entity);

        void Delete(int id);
    }
}