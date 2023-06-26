namespace Insttantt.Workflow.Persistence.Repositories;

/// <summary>
/// Interfaz para obtener un elemento paginado, ordenado y con una cantidad especifica de datos
/// </summary>
public interface IPagedAndSortedResultRequest :
        IPagedResultRequest,
        ILimitedResultRequest,
        ISortedResultRequest
{
}

