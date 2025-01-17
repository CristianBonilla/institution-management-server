using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Institution.Infrastructure
{
    public class RepositoryContext<TContext> : IDisposable, IRepositoryContext<TContext> where TContext : DbContext
    {
        readonly TContext context;
        bool disposed = false;

        public RepositoryContext(TContext context) => this.context = context;

        public EntityEntry<TEntity> EntityEntry<TEntity>(TEntity entity) where TEntity : class
        {
            return context.Entry(entity);
        }

        public DbSet<TEntity> EntitySet<TEntity>() where TEntity : class
        {
            return context.Set<TEntity>();
        }

        public int Save() => context.SaveChanges();

        public Task<int> SaveAsync() => context.SaveChangesAsync();

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
                context.Dispose();

            disposed = true;
        }
    }
}
