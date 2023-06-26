using Insttantt.Workflow.Shared;

namespace Insttantt.Workflow.Models;

public abstract class Entity<TKey> : IEntity<TKey>
{
    public virtual TKey? Id { get; set; }

    /// <summary>
    /// Comprueba si persiste o no, es decir si es una entidad transitoriao
    /// </summary>
    /// <returns></returns>
    public virtual bool IsTransient()
    {
        if (EqualityComparer<TKey>.Default.Equals(this.Id, default(TKey)))
            return true;
        if (typeof(TKey) == typeof(short))
            return Convert.ToInt16((object)this.Id!) <= 0;
        if (typeof(TKey) == typeof(int))
            return Convert.ToInt32((object)this.Id!) <= 0;
        return typeof(TKey) == typeof(long) && Convert.ToInt64((object)this.Id!) <= 0L;
    }

    public object[] GetKeys()
    {
        return new object[] { Id };
    }
}

