using System.Linq.Expressions;
using DigitalKeyMarket.DataAccess.Entities;

namespace DigitalKeyMarket.DataAccess.Repository;

public interface IRepository<T> where T : BaseEntity
{
    IEnumerable<T> GetAll();
    IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate);
    T? GetById(int id);
    T? GetById(Guid id);
    T Save(T entity);
    void Delete(T entity);
}