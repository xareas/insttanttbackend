namespace Insttantt.Workflow.Persistence.Repositories;

/// <summary>
/// Interface que determina si la entidad debera hacer un conteo de
/// sus elementos
/// </summary>
public interface IHasTotalCount
{
    int TotalCount { get; set; }
}

