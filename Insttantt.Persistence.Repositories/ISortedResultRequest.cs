namespace Insttantt.Workflow.Persistence.Repositories;

/// <summary>
/// Orden por el cual se ordenan los resultados
/// </summary>
public interface ISortedResultRequest
{
    string Sorting { get; set; }
}

