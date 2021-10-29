using DDD.Domain.Interfaces;
using DDD.Infrastructure.DB;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DDD.Infrastructure.Repository
{
    public class GenericRepository<T> : IGenericEntie<T>, IDisposable where T : class
    {
        private readonly DbContextOptions<ContextDatabase> _contextOptions;

        public GenericRepository()
        {
            _contextOptions = new DbContextOptions<ContextDatabase>();
        }

        public void Add(T _obj)
        {
            using (var context = new ContextDatabase(_contextOptions))
            {
                context.Set<T>().Add(_obj);
                context.SaveChanges();
            }
        }

        public List<T> GetAll()
        {
            using (var context = new ContextDatabase(_contextOptions))
            {
                return context.Set<T>().AsNoTracking().ToList();
            }
        }

        public T GetById(int id)
        {
            using (var context = new ContextDatabase(_contextOptions))
            {
                return context.Set<T>().Find(id);
            }
        }

        public void Remove(T _obj)
        {
            using (var context = new ContextDatabase(_contextOptions))
            {
                context.Set<T>().Remove(_obj);
                context.SaveChanges();
            }
        }

        public void Update(T _obj)
        {
            using (var context = new ContextDatabase(_contextOptions))
            {
                context.Set<T>().Update(_obj);
                context.SaveChanges();
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }
    }
}
