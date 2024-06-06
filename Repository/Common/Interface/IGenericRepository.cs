using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Repository.Common.Interface
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        IList<TEntity> GetAll();
        Task<List<TEntity>> GetAllAsync();
        Task<List<TEntity>> GetAllAsync(CancellationToken cancellationToken);

        List<TEntity> PageAll(int skip, int take);
        Task<List<TEntity>> PageAllAsync(int skip, int take);
        Task<List<TEntity>> PageAllAsync(CancellationToken cancellationToken, int skip, int take);

        TEntity Find(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate);

        IQueryable<TEntity> FindBy(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate);
        TEntity FindById(object id);
        ValueTask<TEntity> FindByIdAsync(object id);
        ValueTask<TEntity> FindByIdAsync(CancellationToken cancellationToken, object id);

        void Save(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void SaveAll(List<TEntity> entity);
    }
}
