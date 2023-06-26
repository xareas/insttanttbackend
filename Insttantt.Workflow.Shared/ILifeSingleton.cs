namespace Insttantt.Workflow.Shared;


public interface ILifeSingleton : ILifeServiced
{
}

public interface ILifeSingleton<T> : ILifeSingleton
{
}
