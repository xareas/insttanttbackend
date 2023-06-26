namespace Insttantt.Workflow.Shared;
/// <summary>
/// Usa esta interfaz si tieen una estrategia de registro diferente
/// </summary>
public interface IHasFactoryService
{
    /// <summary>
    /// Factori de Implementacion
    /// </summary>
    /// <returns>Delegado de funcion, retorna un IServiceProvider</returns>
    Func<IServiceProvider, object> GetFactory();
}
