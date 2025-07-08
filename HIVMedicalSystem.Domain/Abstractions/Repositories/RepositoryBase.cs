using System.Linq.Expressions;

namespace HIVMedicalSystem.Domain.Abstractions.Repositories;

public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
{
    public Task<IEnumerable<TEntity>> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "", int? pageIndex = null,
        int? pageSize = null)
    {
        throw new NotImplementedException();
    }

    public Task<TEntity> GetByID(object id)
    {
        throw new NotImplementedException();
    }

    public Task Insert(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public Task Delete(object id)
    {
        throw new NotImplementedException();
    }

    public Task Delete(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public void Update(TEntity entity)
    {
        throw new NotImplementedException();
    }
}