namespace Insttantt.Workflow.Shared;

public interface ILifeTransient : ILifeServiced
{
}

public interface ILifeTransient<T> : ILifeTransient
{
}
