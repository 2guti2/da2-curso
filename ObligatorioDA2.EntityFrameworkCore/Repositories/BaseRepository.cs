using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ObligatorioDA2.EntityFrameworkCore.Contracts;

namespace ObligatorioDA2.EntityFrameworkCore.Repositories
{
    public abstract class BaseRepository<T> : IRepository<T> where T : class
    {
        protected Context Context { get; init; }

        public virtual void Create(T entity)
        {
            Context.Set<T>().Add(entity);
            Save();
        }

        public virtual void Delete(T entity)
        {
            Context.Set<T>().Remove(entity);
            Save();
        }

        public virtual void Update(T entity)
        {
            Context.Set<T>().Update(entity);
            Context.Entry(entity).State = EntityState.Modified;
            Save();
        }

        public virtual IEnumerable<T> ReadAll()
        {
            return Context.Set<T>().ToList();
        }

        public virtual IEnumerable<T> ReadAllWhere(Func<T, bool> predicate)
        {
            return Context.Set<T>().Where(predicate).ToList();
        }

        public T First(Func<T, bool> predicate)
        {
            return Context.Set<T>().First(predicate);
        }

        public bool Any()
        {
            return Context.Set<T>().Any();
        }

        public abstract T Read(int id);

        protected void Save()
        {
            Context.SaveChanges();
        }
    }
}