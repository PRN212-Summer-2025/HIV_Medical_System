using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace HIVMedicalSystem.Domain.Abstractions.Repositories;

public interface IRepositoryBase<TEntity> where TEntity : class
{
    Task<IEnumerable<TEntity>> Get(
        Expression<Func<TEntity, bool>> filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
        string includeProperties = "",
        int? pageIndex = null,
        int? pageSize = null);

    Task<TEntity> GetByID(object id);

    Task Insert(TEntity entity);

    Task Delete(object id);

    Task Delete(TEntity entity);

    void Update(TEntity entity);
}