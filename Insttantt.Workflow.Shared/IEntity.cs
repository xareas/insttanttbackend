namespace Insttantt.Workflow.Shared;

public interface IEntity
{
    object[] GetKeys();
}

/// <summary>
/// Interfaz que determina si es un entidad de un modelo
/// </summary>
/// <typeparam name="TKey"></typeparam>
public interface IEntity<TKey> : IEntity
{
    TKey Id { get; set; }

    /// <summary>
    /// Chequea si la entidad es transitoria, es decir que no persiste en la base de datos
    /// </summary>
    /// <returns></returns>
    bool IsTransient();
}
