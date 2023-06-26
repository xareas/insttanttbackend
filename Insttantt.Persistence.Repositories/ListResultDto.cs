namespace Insttantt.Workflow.Persistence.Repositories;

/// <summary>
/// Resultado paginado de datos
/// </summary>
/// <typeparam name="T">Elementos dto</typeparam>
[Serializable]
public class ListResultDto<T> : IListResult<T>
{
    private IReadOnlyList<T> _items = null!;

    public ListResultDto()
    {
        _items = (IReadOnlyList<T>)new List<T>();
    }

    public IReadOnlyList<T> Items
    {
        get => this._items ??= (IReadOnlyList<T>)new List<T>();
        set => this._items = value;
    }

    public ListResultDto(IReadOnlyList<T> items) => this.Items = items;
}

