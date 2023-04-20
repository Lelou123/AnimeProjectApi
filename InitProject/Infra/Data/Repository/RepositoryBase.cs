using InitProject.Model.Interfaces.Repository;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace InitProject.Infra.Data.Repository;

public class RepositoryBase<TEntity> : IRepository<TEntity> where TEntity : class
{
    private readonly DbContext _context;
    private readonly DbSet<TEntity> _dbSet;

    public RepositoryBase(DbContext context)
    {
        _context = context;
        _dbSet = context.Set<TEntity>();
    }

    public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public virtual async Task<IQueryable<TEntity>> GetAllIncludingAsync(params Expression<Func<TEntity, object>>[] includeProperties)
    {
        IQueryable<TEntity> query = _dbSet;
        foreach (var includeProperty in includeProperties)
        {
            query = query.Include(includeProperty);
        }
        return await Task.FromResult(query);
    }

    public virtual async Task<TEntity> GetByIdAsync(object id)
    {
        return await _dbSet.FindAsync(id);
    }

    public virtual async Task InsertAsync(TEntity entity)
    {
        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public virtual async Task UpdateAsync(TEntity entity)
    {
        _dbSet.Attach(entity);
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public virtual async Task DeleteAsync(object id)
    {
        TEntity entityToDelete = await _dbSet.FindAsync(id);
        await DeleteAsync(entityToDelete);
    }

    public virtual async Task DeleteAsync(TEntity entity)
    {
        if (_context.Entry(entity).State == EntityState.Detached)
        {
            _dbSet.Attach(entity);
        }
        _dbSet.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task PatchAsync(TEntity entity, JsonPatchDocument<TEntity> patchDoc, ModelStateDictionary modelState)
    {
        patchDoc.ApplyTo(entity, modelState);
        await UpdateAsync(entity);
    }
}