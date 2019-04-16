using DataPersistence.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataPersistence.Repositories
{
    public class GenericRepository<T> where T: class
    {
        protected DbContext Context { get; }
        public string ConnectionString { get => ""; }
        public GenericRepository(IBasicContext context)
        {
            this.Context = context.Context;
        }

        public T GetSingleOrDefaultByExpression(Func<T, bool> expression)
        {
            return Context.Set<T>().SingleOrDefault(expression);
        }

        public IEnumerable<T> GetAllByExpression(Func<T, bool> expression)
        {
            return Context.Set<T>().Where(expression);
        }

        public T Add(T newEntity)
        {
            var addedEntity = Context.Set<T>().Add(newEntity);
            return addedEntity.Entity;
        }

        public T Remove(T entity)
        {
            var removedEntity = Context.Set<T>().Remove(entity);
            return removedEntity.Entity;
        }

        public T Update(T newEntity)
        {
            var updatedEntity = Context.Set<T>().Update(newEntity);
            return updatedEntity.Entity;
        }

        public void SaveChanges()
        {
            Context.SaveChanges();
        }
    }
}
