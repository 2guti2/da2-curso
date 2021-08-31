using System;
using ObligatorioDA2.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using ObligatorioDA2.EntityFrameworkCore;

namespace ObligatorioDA2.Repositories
{
    public abstract class BaseRepository<T> : IRepository<T> where T : class
    {
        protected Context _context { get; set; }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public abstract IEnumerable<T> GetAll();

        public abstract T Get(int id);

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
