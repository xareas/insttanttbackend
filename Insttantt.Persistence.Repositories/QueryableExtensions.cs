using System.Linq.Expressions;


namespace Insttantt.Workflow.Persistence.Repositories;

/// <summary>
/// Metodos de extension para elementos IQueryable
/// </summary>
public static class QueryableExtensions
{

    #region Metodos de Extension para ayudar en el Paginado

    /// <summary>
    /// Metodo de extension para el Paginado
    /// </summary>
    /// <typeparam name="T">Entidad</typeparam>
    /// <param name="query">queryable</param>
    /// <param name="skipCount">Registro a saltar</param>
    /// <param name="maxResultCount">maxima cantidad de registros</param>
    /// <returns></returns>
    public static IQueryable<T> PageBy<T>(
          this IQueryable<T> query,
          int skipCount,
          int maxResultCount)
    {
        if (query == null)
            throw new ArgumentNullException(nameof(query));
        return Queryable.Take<T>(Queryable.Skip<T>(query, skipCount), maxResultCount);
    }

    public static IQueryable<T> PageBy<T>(
      this IQueryable<T> query,
      IPagedResultRequest pagedResultRequest)
    {
        return query.PageBy<T>(pagedResultRequest.SkipCount, pagedResultRequest.MaxResultCount);
    }




    #endregion

    #region Metodos para construir un Iqueryable filtrable si el dato existe o no


    public static IQueryable<T> WhereIf<T>(
          this IQueryable<T> query,
          bool condition,
          Expression<Func<T, bool>> predicate)
    {
        return !condition ? query : query.Where<T>(predicate);
    }

    public static IQueryable<T> WhereIf<T>(
      this IQueryable<T> query,
      bool condition,
      Expression<Func<T, int, bool>> predicate)
    {
        return !condition ? query : query.Where<T>(predicate);
    }

    #endregion

}


