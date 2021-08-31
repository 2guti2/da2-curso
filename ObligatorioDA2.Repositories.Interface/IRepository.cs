using System;
using System.Collections.Generic;

namespace ObligatorioDA2.Repositories.Interface
{
    public interface IRepository<T>
    {
        void Add(T entity);

        void Delete(T entity);

        void Update(T entity);

        IEnumerable<T> GetAll();

        T Get(int id);

        void Save();
    }
}