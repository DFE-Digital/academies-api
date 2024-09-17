using Dfe.Academies.Domain.Common;
using Dfe.Academies.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;

namespace Dfe.Academies.Infrastructure.Repositories
{
#pragma warning disable CS8603, S2436

    [ExcludeFromCodeCoverage]
    public abstract class Repository<TAggregate, TId, TDbContext> : IRepository<TAggregate, TId>
        where TAggregate : class, IAggregateRoot<TId>
        where TId : ValueObject
        where TDbContext : DbContext
    {
        /// <summary>
        /// The <typeparamref name="TDbContext" />
        /// </summary>
        protected readonly TDbContext DbContext;

        /// <summary>Constructor</summary>
        /// <param name="dbContext"></param>
        protected Repository(TDbContext dbContext) => this.DbContext = dbContext;

        /// <summary>Shorthand for _dbContext.Set</summary>
        /// <returns></returns>
        protected virtual DbSet<TAggregate> DbSet()
        {
            return this.DbContext.Set<TAggregate>();
        }

        /// <inheritdoc />
        public virtual IQueryable<TAggregate> Query() => (IQueryable<TAggregate>)this.DbSet();

        /// <inheritdoc />
        public virtual ICollection<TAggregate> Fetch(Expression<Func<TAggregate, bool>> predicate)
        {
            return (ICollection<TAggregate>)((IQueryable<TAggregate>)this.DbSet()).Where<TAggregate>(predicate).ToList<TAggregate>();
        }

        /// <inheritdoc />
        public virtual async Task<ICollection<TAggregate>> FetchAsync(
          Expression<Func<TAggregate, bool>> predicate,
          CancellationToken cancellationToken = default(CancellationToken))
        {
            return (ICollection<TAggregate>)await EntityFrameworkQueryableExtensions.ToListAsync<TAggregate>(((IQueryable<TAggregate>)this.DbSet()).Where<TAggregate>(predicate), cancellationToken);
        }

        /// <inheritdoc />
        public virtual TAggregate Find(params TId[] keyValues) => this.DbSet().Find(keyValues);

        /// <inheritdoc />
        public virtual TAggregate Find(Expression<Func<TAggregate, bool>> predicate)
        {
            return ((IQueryable<TAggregate>)this.DbSet()).FirstOrDefault<TAggregate>(predicate);
        }

        /// <inheritdoc />
        public virtual async Task<TAggregate> FindAsync(params TId[] keyValues)
        {
            return await this.DbSet().FindAsync(keyValues);
        }

        /// <inheritdoc />
        public virtual async Task<TAggregate> FindAsync(
          Expression<Func<TAggregate, bool>> predicate,
          CancellationToken cancellationToken = default(CancellationToken))
        {
            return await EntityFrameworkQueryableExtensions.FirstOrDefaultAsync<TAggregate>((IQueryable<TAggregate>)this.DbSet(), predicate, cancellationToken);
        }

        /// <inheritdoc />
        public virtual TAggregate Get(Expression<Func<TAggregate, bool>> predicate)
        {
            return ((IQueryable<TAggregate>)this.DbSet()).Single<TAggregate>(predicate);
        }

        /// <inheritdoc />
        public virtual TAggregate Get(params TId[] keyValues)
        {
            return this.Find(keyValues) ?? throw new InvalidOperationException(
                $"Entity type {(object)typeof(TAggregate)} is null for primary key {(object)keyValues}");
        }

        /// <inheritdoc />
        public virtual async Task<TAggregate> GetAsync(Expression<Func<TAggregate, bool>> predicate)
        {
            return await EntityFrameworkQueryableExtensions.SingleAsync<TAggregate>((IQueryable<TAggregate>)this.DbSet(), predicate, new CancellationToken());
        }

        /// <inheritdoc />
        public virtual async Task<TAggregate> GetAsync(params TId[] keyValues)
        {
            return await this.FindAsync(keyValues) ?? throw new InvalidOperationException(
                $"Entity type {(object)typeof(TAggregate)} is null for primary key {(object)keyValues}");
        }

        /// <inheritdoc />
        public virtual TAggregate Add(TAggregate entity)
        {
            this.DbContext.Add<TAggregate>(entity);
            this.DbContext.SaveChanges();
            return entity;
        }

        /// <inheritdoc />
        public virtual async Task<TAggregate> AddAsync(TAggregate entity, CancellationToken cancellationToken = default(CancellationToken))
        {
            await this.DbContext.AddAsync<TAggregate>(entity, cancellationToken);
            await this.DbContext.SaveChangesAsync(cancellationToken);
            return entity;
        }

        /// <inheritdoc />
        public virtual IEnumerable<TAggregate> AddRange(ICollection<TAggregate> entities)
        {
            this.DbContext.AddRange((IEnumerable<object>)entities);
            this.DbContext.SaveChanges();
            return (IEnumerable<TAggregate>)entities;
        }

        /// <inheritdoc />
        public virtual async Task<IEnumerable<TAggregate>> AddRangeAsync(
          ICollection<TAggregate> entities,
          CancellationToken cancellationToken = default(CancellationToken))
        {
            await this.DbContext.AddRangeAsync((IEnumerable<object>)entities, cancellationToken);
            await this.DbContext.SaveChangesAsync(cancellationToken);
            return (IEnumerable<TAggregate>)entities;
        }

        /// <inheritdoc />
        public virtual TAggregate Remove(TAggregate entity)
        {
            this.DbContext.Remove<TAggregate>(entity);
            this.DbContext.SaveChanges();
            return entity;
        }

        /// <inheritdoc />
        public virtual async Task<TAggregate> RemoveAsync(
          TAggregate entity,
          CancellationToken cancellationToken = default(CancellationToken))
        {
            this.DbContext.Remove<TAggregate>(entity);
            await this.DbContext.SaveChangesAsync(cancellationToken);
            return entity;
        }

        /// <inheritdoc />
        public virtual int Delete(Expression<Func<TAggregate, bool>> predicate)
        {
            return DbSet().Where(predicate).ExecuteDelete();
        }

        /// <inheritdoc />
        public virtual IEnumerable<TAggregate> RemoveRange(ICollection<TAggregate> entities)
        {
            this.DbSet().RemoveRange((IEnumerable<TAggregate>)entities);
            this.DbContext.SaveChanges();
            return (IEnumerable<TAggregate>)entities;
        }

        /// <inheritdoc />
        public virtual async Task<IEnumerable<TAggregate>> RemoveRangeAsync(
          ICollection<TAggregate> entities,
          CancellationToken cancellationToken = default(CancellationToken))
        {
            this.DbSet().RemoveRange((IEnumerable<TAggregate>)entities);
            await this.DbContext.SaveChangesAsync(cancellationToken);
            return (IEnumerable<TAggregate>)entities;
        }

        /// <inheritdoc />
        public virtual TAggregate Update(TAggregate entity)
        {
            this.DbContext.Update<TAggregate>(entity);
            this.DbContext.SaveChanges();
            return entity;
        }

        /// <inheritdoc />
        public virtual async Task<TAggregate> UpdateAsync(
          TAggregate entity,
          CancellationToken cancellationToken = default(CancellationToken))
        {
            this.DbContext.Update<TAggregate>(entity);
            await this.DbContext.SaveChangesAsync(cancellationToken);
            return entity;
        }
    }
#pragma warning restore CS8603, S2436
}
