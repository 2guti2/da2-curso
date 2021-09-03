using System.Collections.Generic;

namespace ObligatorioDA2.EntityFrameworkCore.Contracts
{
    public interface IRepository<T> where T : class
    {
        void Create(T entity);

        void Delete(T entity);

        void Update(T entity);

        IEnumerable<T> ReadAll();

        bool Any();

        T Read(int id);
    }
}