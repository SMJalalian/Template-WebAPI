using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace MyProject.Data.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        DbSet<TEntity> Entities { get; }
        IQueryable<TEntity> Table { get; }
        IQueryable<TEntity> TableNoTracking { get; }

        //Sync Methods 
        void Add(TEntity entity, bool saveNow = true);
        void AddRange(IEnumerable<TEntity> entities, bool saveNow = true);
        void Delete(TEntity entity, bool saveNow = true);
        void DeleteRange(IEnumerable<TEntity> entities, bool saveNow = true);
        void Update(TEntity entity, bool saveNow = true);
        void UpdateRange(IEnumerable<TEntity> entities, bool saveNow = true);
        void LoadCollection<TProperty>(TEntity entity, Expression<Func<TEntity, IEnumerable<TProperty>>> collectionProperty) where TProperty : class;
        void LoadReference<TProperty>(TEntity entity, Expression<Func<TEntity, TProperty>> referenceProperty) where TProperty : class;
        TEntity GetById(params object[] id);
        IEnumerable<TEntity> FindAll();

        void Attach(TEntity entity);
        void Detach(TEntity entity);
        int Count();


        //Async Methods
        Task AddAsync(TEntity entity, CancellationToken cancellationToken, bool saveNow = true);
        Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken, bool saveNow = true);
        Task DeleteAsync(TEntity entity, CancellationToken cancellationToken, bool saveNow = true);
        Task DeleteRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken, bool saveNow = true);
        Task UpdateAsync(TEntity entity, CancellationToken cancellationToken, bool saveNow = true);
        Task UpdateRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken, bool saveNow = true);
        Task LoadCollectionAsync<TProperty>(TEntity entity, Expression<Func<TEntity, IEnumerable<TProperty>>> collectionProperty, CancellationToken cancellationToken) where TProperty : class;
        Task LoadReferenceAsync<TProperty>(TEntity entity, Expression<Func<TEntity, TProperty>> referenceProperty, CancellationToken cancellationToken) where TProperty : class;
        Task<TEntity> GetByIdAsync(CancellationToken cancellationToken, params object[] id);
        Task<IEnumerable<TEntity>> FindAllAsync(CancellationToken cancellationToken);
    }
}