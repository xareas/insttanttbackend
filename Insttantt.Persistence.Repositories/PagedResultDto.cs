namespace Insttantt.Workflow.Persistence.Repositories;

/// <summary>
/// Clase encargada de realizar el paginado de elementos
/// </summary>
/// <typeparam name="T">Entidad a paginar</typeparam>
[Serializable]
public class PagedResultDto<T> : ListResultDto<T>, IPagedResult<T>, IListResult<T>, IHasTotalCount
{
    public int TotalCount { get; set; }

    public PagedResultDto()
    {
    }

    public PagedResultDto(int totalCount, IReadOnlyList<T> items) : base(items)
    {
        this.TotalCount = totalCount;
    }
}

