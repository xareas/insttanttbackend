namespace Insttantt.Workflow.Persistence.Repositories;
/// <summary>
/// Limita los resultados de la carga de datos
/// </summary>
public interface ILimitedResultRequest
{
    int MaxResultCount { get; set; }
}

