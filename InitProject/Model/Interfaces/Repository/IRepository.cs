using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Linq.Expressions;

namespace InitProject.Model.Interfaces.Repository;

public interface IRepository<TEntity> where TEntity : class
{
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task<IQueryable<TEntity>> GetAllIncludingAsync(params Expression<Func<TEntity, object>>[] includeProperties);
    Task<TEntity> GetByIdAsync(object id);
    Task InsertAsync(TEntity entity);
    Task UpdateAsync(TEntity entity);
    Task DeleteAsync(object id);
    Task DeleteAsync(TEntity entity);
    Task PatchAsync(TEntity entity, JsonPatchDocument<TEntity> patchDoc, ModelStateDictionary modelState);
}
