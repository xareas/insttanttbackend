namespace Insttantt.Workflow.Persistence.Repositories;

/// <summary>
/// Interfaz de paginado
/// </summary>
public interface IPagedResultRequest : ILimitedResultRequest
{
    int SkipCount { get; set; }
}

