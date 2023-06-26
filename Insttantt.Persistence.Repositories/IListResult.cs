namespace Insttantt.Workflow.Persistence.Repositories;
/// <summary>
/// Determina si devolvera la lista de elementos
/// </summary>
/// <typeparam name="T">Lista de elementos</typeparam>
public interface IListResult<T>
{
    IReadOnlyList<T> Items { get; set; }
}

