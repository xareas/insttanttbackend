using Insttantt.Workflow.Shared;
using System.Linq.Expressions;


namespace Insttantt.Workflow.Persistence.Repositories;

/// <summary>
/// Interface base para el manejo de repositorios genericos asincronos,
/// es probable que evolucione por compatibilidad con metodos sincronos
/// </summary>
/// <typeparam name="TEntity">Entidad</typeparam>
/// <typeparam name="TKey">Clave Primaria</typeparam>
public interface IRepository<TEntity, TKey> :
        IRepositoryBase where TEntity : class, IEntity<TKey>
{
    IQueryable<TEntity> GetAll();
    IQueryable<TEntity> GetAllIncluding(params Expression<Func<TEntity, object>>[] propertySelectors);

    Task<TEntity> GetByIdAsync(TKey id);
    T Query<T>(Func<IQueryable<TEntity>, T> queryMethod);
    Task<TEntity> SingleAsync(Expression<Func<TEntity, bool>> predicate);
    Task<TEntity> FirstOrDefaultAsync(TKey id);
    Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
    Task<TEntity> InsertAsync(TEntity entity);
    Task<TKey> InsertAndGetIdAsync(TEntity entity);
    Task<TEntity> InsertOrUpdateAsync(TEntity entity);
    Task<TKey> InsertOrUpdateAndGetIdAsync(TEntity entity);
    Task<TEntity> UpdateAsync(TEntity entity);
    Task DeleteAsync(TEntity entity);
    Task DeleteAsync(TKey id);
    Task<long> LongCountAsync();
    Task<long> LongCountAsync(Expression<Func<TEntity, bool>> predicate);
    Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate);
    Task SaveAllAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken);
    Task DeleteAllAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken);
    //Metodos sincronos
    void Update(TEntity entity);
    void Delete(TEntity entity);
    TEntity Insert(TEntity entity);
}
