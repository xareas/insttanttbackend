using Insttantt.Workflow.Shared;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Insttantt.Workflow.Persistence.Repositories;

/// <summary>
/// Repositorio generico basado en el manejo de entidades
/// </summary>
/// <typeparam name="TEntity">Entidad</typeparam>
/// <typeparam name="TKey">Clave</typeparam>
public abstract class RepositoryAsync<TEntity, TKey>
        : IRepository<TEntity, TKey>, IDisposable
        where TEntity : class, IEntity<TKey>
{

    private const string KeyName = "Id";

    protected readonly DbContext _context;

    protected RepositoryAsync(DbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    #region Metodos Get Consultas de datos

    public IQueryable<TEntity> GetAll()
    {
        return _context.Set<TEntity>();
    }

    /// <summary>
    /// </summary>
    /// <param name="propertySelectors"></param>
    /// <returns></returns>
    public IQueryable<TEntity> GetAllIncluding(params Expression<Func<TEntity, object>>[] propertySelectors)
    {
        return GetAll();
    }

    public async Task<TEntity> GetByIdAsync(TKey id)
    {
        var entity = await FirstOrDefaultAsync(id);
        if (entity == null)
        {
            throw new EntityNotFoundException(typeof(TEntity), id!);
        }

        return entity;
    }

    public T Query<T>(Func<IQueryable<TEntity>, T> queryMethod)
    {
        return queryMethod(GetAll());
    }

    #endregion


    #region Metodos para encontrar un Elemento Single/FirsOrDefault
    public Task<TEntity> SingleAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return Task.FromResult(Single(predicate));
    }

    public virtual TEntity Single(Expression<Func<TEntity, bool>> predicate)
    {
        return GetAll().Single(predicate);
    }

    public virtual TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
    {
        return GetAll().FirstOrDefault(predicate)!;
    }
    public Task<TEntity> FirstOrDefaultAsync(TKey id)
    {
        return Task.FromResult(FirstOrDefault(id));
    }
    public virtual TEntity FirstOrDefault(TKey id)
    {
        return GetAll().FirstOrDefault(CreateEqualityExpressionForId(id))!;
    }

    public Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return Task.FromResult(FirstOrDefault(predicate));
    }

    #endregion

    #region Metodos CRUD

    public async Task<TEntity> InsertAsync(TEntity entity)
    {
        _context.Set<TEntity>().Add(entity);
        await PersistAsync();
        return entity;
    }

    public async Task<TKey> InsertAndGetIdAsync(TEntity entity)
    {
        _context.Set<TEntity>().Add(entity);
        await PersistAsync();
        return entity.Id;
    }

    public virtual async Task<TEntity> InsertOrUpdateAsync(TEntity entity)
    {
        return entity.IsTransient()
            ? await InsertAsync(entity)
            : await UpdateAsync(entity);
    }

    public async Task<TKey> InsertOrUpdateAndGetIdAsync(TEntity entity)
    {
        entity = await InsertOrUpdateAsync(entity);

        if (MayHaveTemporaryKey(entity) || entity.IsTransient())
        {
            await _context.SaveChangesAsync();
        }

        return entity.Id;
    }

    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        _context.Set<TEntity>().Attach(entity);
        _context.Entry(entity).State = EntityState.Modified;
        await PersistAsync();
        return entity;
    }

    public async Task DeleteAsync(TEntity entity)
    {
        _context.Set<TEntity>().Remove(entity);
        await PersistAsync();
    }

    public async Task DeleteAsync(TKey id)
    {
        await Delete(id);
    }

    private async Task Delete(TKey id)
    {
        var entity = GetFromChangeTrackerOrNull(id);
        if (entity != null)
        {
            await DeleteAsync(entity);
            return;
        }

        entity = FirstOrDefault(id);
        if (entity != null)
        {
            await DeleteAsync(entity);
        }

    }

    #endregion

    #region Conteo de Elementos

    public async Task<IQueryable<TEntity>> GetAllAsync()
    {
        return await Task.FromResult(_context.Set<TEntity>());
    }
    public async Task<long> LongCountAsync()
    {
        return await (await GetAllAsync()).LongCountAsync();
    }


    public async Task<long> LongCountAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await (await GetAllAsync()).Where(predicate).LongCountAsync();
    }

    public async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await (await GetAllAsync()).AnyAsync(predicate);
    }

    public async Task SaveAllAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
    {
        await _context.AddRangeAsync(entities, cancellationToken);
        await PersistAsync();
    }

    public async Task DeleteAllAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
    {
        _context.Remove(entities);
        await PersistAsync();
    }

    #endregion

    #region Metodos Sincronos

    public void Update(TEntity entity)
    {
        _context.Set<TEntity>().Attach(entity);
        _context.Entry(entity).State = EntityState.Modified;
        _context.SaveChanges();
    }

    public void Delete(TEntity entity)
    {
        _context.Set<TEntity>().Remove(entity);
        _context.SaveChanges();
    }

    public TEntity Insert(TEntity entity)
    {
        _context.Set<TEntity>().Add(entity);
        _context.SaveChanges();
        return entity;
    }

    #endregion

    #region Metodos de Utilidades

    private async Task PersistAsync()
    {
        await _context.SaveChangesAsync();
    }

    protected virtual Expression<Func<TEntity, bool>> CreateEqualityExpressionForId(TKey id)
    {
        try
        {

            var lambdaParam = Expression.Parameter(typeof(TEntity));
            //El campo identity de la tabla debe llamarse ID, Entity<TKey>
            var leftExpression = Expression.PropertyOrField(lambdaParam, KeyName);

            var idValue = Convert.ChangeType(id, typeof(TKey));
            //Construimos un arbol de expression
            Expression<Func<object>> closure = () => idValue!;
            var rightExpression = Expression.Convert(closure.Body, leftExpression.Type);

            var lambdaBody = Expression.Equal(leftExpression, rightExpression);

            return Expression.Lambda<Func<TEntity, bool>>(lambdaBody, lambdaParam);

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    /// <summary>
    /// Determinar si esta en el contexto
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    private TEntity GetFromChangeTrackerOrNull(TKey id)
    {
        var entry = _context.ChangeTracker.Entries()
            .FirstOrDefault(
                ent =>
                    ent.Entity is TEntity &&
                    EqualityComparer<TKey>.Default.Equals(id, ((ent.Entity as TEntity)!).Id)
            );

        return (entry?.Entity as TEntity)!;
    }

    /// <summary>
    /// Determina si el ID puede ser comparado
    /// analisis para futuras mejoras
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    private static bool MayHaveTemporaryKey(TEntity entity)
    {
        if (typeof(TKey) == typeof(byte))
        {
            return true;
        }

        if (typeof(TKey) == typeof(int))
        {
            return Convert.ToInt32(entity.Id) <= 0;
        }

        if (typeof(TKey) == typeof(short))
        {
            return Convert.ToInt16(entity.Id) <= 0;
        }

        if (typeof(TKey) == typeof(long))
        {
            return Convert.ToInt64(entity.Id) <= 0;
        }

        return false;
    }
    #endregion

    public void Dispose()
    {
        _context?.Dispose();
    }
}

