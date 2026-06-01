using Microsoft.EntityFrameworkCore;
using QomNewsBase.Application.Interfaces;
using QomNewsBase.Infrastructure.Contexts;
using System.Linq.Expressions;

namespace QomNewsBase.Infrastructure.Repositories;

public class GenericRepository<T> : IRepository<T> where T : class
{
    protected readonly QomNewsBaseContext _context;
    protected readonly DbSet<T> _dbSet;

    public GenericRepository(QomNewsBaseContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    #region Queries

    public async Task<T?> GetByIdAsync(object id, CancellationToken cancellationToken)
    {
        return await _dbSet.FindAsync(id, cancellationToken);
    }

    public async Task<List<T>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _dbSet.AsNoTracking().ToListAsync(cancellationToken);
    }

    #endregion

    #region Commands

    public async Task AddAsync(T entity, CancellationToken cancellationToken)
    {
        await _dbSet.AddAsync(entity, cancellationToken);
    }

    public void Update(T entity)
    {
        _dbSet.Update(entity);
    }

    public void Delete(T entity)
    {
        _dbSet.Remove(entity);
    }

    #endregion

    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }
}