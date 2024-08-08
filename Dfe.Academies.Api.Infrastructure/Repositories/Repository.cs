using Dfe.Academies.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace Dfe.Academies.Infrastructure.Repositories
{
    public abstract class Repository<TEntity, TDbContext> : IRepository<TEntity>
   where TEntity : class, new()
   where TDbContext : DbContext
    {
        /// <summary>
        /// The <typeparamref name="TDbContext" />
        /// </summary>
        protected readonly TDbContext DbContext;

        /// <summary>Constructor</summary>
        /// <param name="dbContext"></param>
        protected Repository(TDbContext dbContext) => this.DbContext = dbContext;

        /// <summary>Short hand for _dbContext.Set</summary>
        /// <returns></returns>
        protected virtual DbSet<TEntity> DbSet()
        {
            return this.DbContext.Set<TEntity>();
        }

        /// <inheritdoc />
        public virtual IQueryable<TEntity> Query() => (IQueryable<TEntity>)this.DbSet();

        /// <inheritdoc />
        public virtual ICollection<TEntity> Fetch(Expression<Func<TEntity, bool>> predicate)
        {
            return (ICollection<TEntity>)((IQueryable<TEntity>)this.DbSet()).Where<TEntity>(predicate).ToList<TEntity>();
        }

        /// <inheritdoc />
        public virtual async Task<ICollection<TEntity>> FetchAsync(
          Expression<Func<TEntity, bool>> predicate,
          CancellationToken cancellationToken = default(CancellationToken))
        {
            return (ICollection<TEntity>)await EntityFrameworkQueryableExtensions.ToListAsync<TEntity>(((IQueryable<TEntity>)this.DbSet()).Where<TEntity>(predicate), cancellationToken);
        }

        /// <inheritdoc />
        public virtual TEntity Find(params object[] keyValues) => this.DbSet().Find(keyValues);

        /// <inheritdoc />
        public virtual async Task<TEntity> FindAsync(params object[] keyValues)
        {
            return await this.DbSet().FindAsync(keyValues);
        }

        /// <inheritdoc />
        public virtual TEntity Find(Expression<Func<TEntity, bool>> predicate)
        {
            return ((IQueryable<TEntity>)this.DbSet()).FirstOrDefault<TEntity>(predicate);
        }

        /// <inheritdoc />
        public virtual async Task<TEntity> FindAsync(
          Expression<Func<TEntity, bool>> predicate,
          CancellationToken cancellationToken = default(CancellationToken))
        {
            return await EntityFrameworkQueryableExtensions.FirstOrDefaultAsync<TEntity>((IQueryable<TEntity>)this.DbSet(), predicate, cancellationToken);
        }

        /// <inheritdoc />
        public virtual TEntity Get(params object[] keyValues)
        {
            return this.Find(keyValues) ?? throw new InvalidOperationException(string.Format("Entity type {0} is null for primary key {1}", (object)typeof(TEntity), (object)keyValues));
        }

        /// <inheritdoc />
        public virtual async Task<TEntity> GetAsync(params object[] keyValues)
        {
            return await this.FindAsync(keyValues) ?? throw new InvalidOperationException(string.Format("Entity type {0} is null for primary key {1}", (object)typeof(TEntity), (object)keyValues));
        }

        /// <inheritdoc />
        public virtual TEntity Get(Expression<Func<TEntity, bool>> predicate)
        {
            return ((IQueryable<TEntity>)this.DbSet()).Single<TEntity>(predicate);
        }

        /// <inheritdoc />
        public virtual async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await EntityFrameworkQueryableExtensions.SingleAsync<TEntity>((IQueryable<TEntity>)this.DbSet(), predicate, new CancellationToken());
        }

        /// <inheritdoc />
        public virtual TEntity Add(TEntity entity)
        {
            this.DbContext.Add<TEntity>(entity);
            this.DbContext.SaveChanges();
            return entity;
        }

        /// <inheritdoc />
        public virtual async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default(CancellationToken))
        {
            EntityEntry<TEntity> entityEntry = await this.DbContext.AddAsync<TEntity>(entity, cancellationToken);
            int num = await this.DbContext.SaveChangesAsync(cancellationToken);
            return entity;
        }

        /// <inheritdoc />
        public virtual IEnumerable<TEntity> AddRange(ICollection<TEntity> entities)
        {
            this.DbContext.AddRange((IEnumerable<object>)entities);
            this.DbContext.SaveChanges();
            return (IEnumerable<TEntity>)entities;
        }

        /// <inheritdoc />
        public virtual async Task<IEnumerable<TEntity>> AddRangeAsync(
          ICollection<TEntity> entities,
          CancellationToken cancellationToken = default(CancellationToken))
        {
            await this.DbContext.AddRangeAsync((IEnumerable<object>)entities, cancellationToken);
            int num = await this.DbContext.SaveChangesAsync(cancellationToken);
            return (IEnumerable<TEntity>)entities;
        }

        /// <inheritdoc />
        public virtual TEntity Remove(TEntity entity)
        {
            this.DbContext.Remove<TEntity>(entity);
            this.DbContext.SaveChanges();
            return entity;
        }

        /// <inheritdoc />
        public virtual async Task<TEntity> RemoveAsync(
          TEntity entity,
          CancellationToken cancellationToken = default(CancellationToken))
        {
            this.DbContext.Remove<TEntity>(entity);
            int num = await this.DbContext.SaveChangesAsync(cancellationToken);
            return entity;
        }

        /// <inheritdoc />
        public virtual int Delete(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet().Where(predicate).ExecuteDelete();
        }

        /// <inheritdoc />
        public virtual IEnumerable<TEntity> RemoveRange(ICollection<TEntity> entities)
        {
            this.DbSet().RemoveRange((IEnumerable<TEntity>)entities);
            this.DbContext.SaveChanges();
            return (IEnumerable<TEntity>)entities;
        }

        /// <inheritdoc />
        public virtual async Task<IEnumerable<TEntity>> RemoveRangeAsync(
          ICollection<TEntity> entities,
          CancellationToken cancellationToken = default(CancellationToken))
        {
            this.DbSet().RemoveRange((IEnumerable<TEntity>)entities);
            int num = await this.DbContext.SaveChangesAsync(cancellationToken);
            return (IEnumerable<TEntity>)entities;
        }

        /// <inheritdoc />
        public virtual TEntity Update(TEntity entity)
        {
            this.DbContext.Update<TEntity>(entity);
            this.DbContext.SaveChanges();
            return entity;
        }

        /// <inheritdoc />
        public virtual async Task<TEntity> UpdateAsync(
          TEntity entity,
          CancellationToken cancellationToken = default(CancellationToken))
        {
            this.DbContext.Update<TEntity>(entity);
            int num = await this.DbContext.SaveChangesAsync(cancellationToken);
            return entity;
        }
    }
}
