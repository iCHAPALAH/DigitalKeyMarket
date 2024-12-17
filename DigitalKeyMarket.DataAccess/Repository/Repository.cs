using System.Linq.Expressions;
using DigitalKeyMarket.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DigitalKeyMarket.DataAccess.Repository;

public class Repository<T> : IRepository<T> where T : class, IBaseEntity
{
    private readonly IDbContextFactory<DigitalKeyMarketDbContext> _contextFactory;
    
    public Repository(IDbContextFactory<DigitalKeyMarketDbContext> contextFactory)
    {
        _contextFactory = contextFactory;
    }

    public IEnumerable<T> GetAll()
    {
        using var dbContext = _contextFactory.CreateDbContext();
        return dbContext.Set<T>().AsNoTracking().ToList();
    }

    public IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate)
    {
        using var dbContext = _contextFactory.CreateDbContext();
        return dbContext.Set<T>().AsNoTracking().Where(predicate).ToList();
    }

    public T? GetById(int id)
    {
        using var dbContext = _contextFactory.CreateDbContext();
        return dbContext.Set<T>().FirstOrDefault(e => e.Id == id);
    }

    public T? GetById(Guid id)
    {
        using var dbContext = _contextFactory.CreateDbContext();
        return dbContext.Set<T>().AsNoTracking().FirstOrDefault(e => e.ExternalId == id);
    }

    public T Save(T entity)
    {
        using var dbContext = _contextFactory.CreateDbContext();
        
        entity.ModificationTime = DateTime.UtcNow;
        EntityEntry<T> result;
        
        if (dbContext.Set<T>().AsNoTracking().FirstOrDefault(e => e.Id == entity.Id) == null)
        {
            entity.ExternalId = Guid.NewGuid();
            entity.CreationTime = entity.ModificationTime;
            result = dbContext.Set<T>().Add(entity);
        }
        else
        {
            result = dbContext.Set<T>().Attach(entity);
            dbContext.Entry(entity).State = EntityState.Modified;
        }
        
        dbContext.SaveChanges();
        return result.Entity;
    }

    public void Delete(T entity)
    {
        using var dbContext = _contextFactory.CreateDbContext();
        dbContext.Set<T>().Remove(entity);
        dbContext.SaveChanges();
    }
}