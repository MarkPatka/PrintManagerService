using Microsoft.EntityFrameworkCore;
using PrintManager.Domain.Common.Models;
using System.Linq.Expressions;

namespace PrintManager.Application.Common.Interfaces.Persistence;

public abstract class GenericRepository<E, V>
    : IGenericRepository<E, V>
    where E : Entity<V>
    where V : ValueObject
{
    private readonly DbContext _context;
    protected DbSet<E> _dbSet => _context.Set<E>();

    protected GenericRepository(DbContext context) =>
        _context = context;

    public void Add(in E sender)
    {
        _dbSet.Add(sender);
        Save();
    }
    public void AddRange(in IEnumerable<E> sender)
    {
        _dbSet.AddRange(sender);
        Save();
    }
    public IQueryable<E> Filter(Expression<Func<E, bool>> predicate)
    {
        return _dbSet.Where(predicate);
    }
    public Task<IQueryable<E>> FilterAsync(Expression<Func<E, bool>> predicate)
    {
        return Task.Run(() => _dbSet.AsNoTracking().Where(predicate));
    }
    public IEnumerable<E> GetAll()
    {
        return _dbSet.AsEnumerable();
    }
    public Task<List<E>> GetAllAsync()
    {
        return _dbSet.ToListAsync();
    }
    public E GetById(V id)
    {
        return _dbSet.Find(id) 
            ?? throw new Exception($"Object with primary key value: {id} not found.");
    }
    public async Task<E> GetByIdAsync(V id)
    {
        return await _dbSet.FindAsync(id) 
            ?? throw new Exception($"Object with primary key value: {id} not found.");
    }
    public bool Remove(V id)
    {
        var toDelete = _dbSet.Find(id);
        if (toDelete is not null)
        {
            _dbSet.Remove(toDelete);
            Save();
            return true;
        }
        return false;
    }
    public int Save()
    {
        return _context.SaveChanges();
    }
    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }
    public void Update(in E sender)
    {
        _dbSet.Entry(sender).State = EntityState.Modified;
        Save();
    }
}
