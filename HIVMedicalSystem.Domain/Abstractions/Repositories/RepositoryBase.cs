using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace HIVMedicalSystem.Domain.Abstractions.Repositories;

public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
{
    public RepositoryBase()
    {
    }
    public async Task<IEnumerable<TEntity>> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "", int? pageIndex = null,
        int? pageSize = null)
    {
        Console.WriteLine("hoho");
        try
        {
            using var context = new AppDbContext();
            IQueryable<TEntity> query = context.Set<TEntity>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                         (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            if (pageIndex.HasValue && pageSize.HasValue)
            {
                int validPageIndex = pageIndex.Value > 0 ? pageIndex.Value - 1 : 0;
                int validPageSize = pageSize.Value > 0 ? pageSize.Value : 10;

                query = query.Skip(validPageIndex * validPageSize).Take(validPageSize);
            }

            return query.ToList();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.InnerException);
            Console.WriteLine("hehe");
            return null;
        }
    }

    public TEntity GetByID(object id)
    {
        using var context = new AppDbContext();
        var dbSet = context.Set<TEntity>();
        return dbSet.Find(id);
    }

    public void Insert(TEntity entity)
    {
        try
        {
            using var context = new AppDbContext();
            context.Set<TEntity>().Add(entity);
            context.SaveChanges();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.InnerException);
        }
    }

    public async Task Delete(object id)
    {
        try
        {
            using var context = new AppDbContext();
            TEntity entityToDelete = await context.Set<TEntity>().FindAsync(id);
            Delete(entityToDelete);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.InnerException);
        }
    }

    public async Task Delete(TEntity entity)
    {
        try
        {
            using var context = new AppDbContext();
            if (context.Entry(entity).State == EntityState.Detached)
            {
                context.Set<TEntity>().Attach(entity);
            }

            context.Set<TEntity>().Remove(entity);
            await context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.InnerException);
        }
    }

    public async Task Update(TEntity entity)
    {
        try
        {
            using var context = new AppDbContext();
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.InnerException);
        }
    }
}