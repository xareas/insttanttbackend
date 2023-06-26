namespace Insttantt.Workflow.Persistence.Repositories;

/// <summary>
/// Interface para realizar el paginado
/// </summary>
/// <typeparam name="T">Elemento a paginar</typeparam>
public interface IPagedResult<T> : IListResult<T>, IHasTotalCount
{
}

