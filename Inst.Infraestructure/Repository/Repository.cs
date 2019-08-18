﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Inst.Infrastructure
{
    class Repository<TEntity> : IRepository<TEntity>, IDisposable where TEntity : class
    {
        readonly InstitutionContext context;
        readonly DbSet<TEntity> entitySet;
        readonly Func<TEntity, EntityEntry<TEntity>> entityEntry;
        bool disposed = false;

        public Repository(InstitutionContext context)
        {
            entitySet = context.Set<TEntity>();
            entityEntry = t => context.Entry(t);
            this.context = context;
        }

        public TEntity Create(TEntity entity)
        {
            var created = entitySet.Add(entity);

            return created.Entity;
        }

        public IEnumerable<TEntity> CreateAll(IEnumerable<TEntity> entities)
        {
            foreach (TEntity entity in entities)
                yield return Create(entity);
        }

        public TEntity Update(TEntity entity)
        {
            var entry = entityEntry(entity);

            if (entry.State == EntityState.Detached)
                entitySet.Attach(entity);

            var updated = entitySet.Update(entity);

            return updated.Entity;
        }

        public IEnumerable<TEntity> UpdateAll(IEnumerable<TEntity> entities)
        {
            foreach (TEntity entity in entities)
                yield return Update(entity);
        }

        public TEntity Delete(TEntity entity)
        {
            var entry = entityEntry(entity);

            if (entry.State == EntityState.Detached)
                entitySet.Attach(entity);

            var deleted = entitySet.Remove(entity);

            return deleted.Entity;
        }

        public IEnumerable<TEntity> DeleteAll(IEnumerable<TEntity> entities)
        {
            foreach (TEntity entity in entities)
                yield return Delete(entity);
        }

        public TEntity Find(params object[] keyValues) => entitySet.Find(keyValues);

        public TEntity Find(Expression<Func<TEntity, bool>> expression) => entitySet.FirstOrDefault(expression);

        public bool Exists(Expression<Func<TEntity, bool>> expression) => entitySet.Any(expression);

        public IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            params Expression<Func<TEntity, object>>[] includes)
        {
            var querySet = entitySet.AsQueryable();

            if (filter != null)
                querySet = querySet.Where(filter);

            foreach (var expression in includes)
                querySet = querySet.Include(expression);

            var queryable = orderBy != null ? orderBy(querySet) : querySet;

            return queryable;
        }

        public int Save() => context.SaveChanges();

        public Task<int> SaveAsync() => context.SaveChangesAsync();

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
                context.Dispose();
            
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
