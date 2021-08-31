using System;
using System.Collections.Generic;

namespace ObligatorioDA2.Application.Interface
{
    public interface IService<T>
    {
        T Create(T entity);

        void Delete(int id);

        T Update(int id, T entity);

        T Get(int id);

        IEnumerable<T> GetAll();
    }

}

