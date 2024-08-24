using PrintManager.Domain.Common.Models;
using System.Linq.Expressions;

namespace PrintManager.Application.Common.Interfaces.Persistence;

public interface IGenericRepository<E, V> 
    where E : Entity<V>
    where V : ValueObject
{   
    public void Add(in E sender);

    public IEnumerable<E> GetAll();
    public Task<List<E>> GetAllAsync();

    public E GetById(V id);
    public Task<E> GetByIdAsync(V id);

    public void Update(in E sender);
    public bool Remove(V id);

    public int Save();
    public Task SaveAsync();

    public IQueryable<E> Filter(Expression<Func<E, bool>> predicate);
    public Task<IQueryable<E>> FilterAsync(Expression<Func<E, bool>> predicate);
}
