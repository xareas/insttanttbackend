namespace Insttantt.Workflow.Core
{
    public interface IWorkflowBuilder
    {
        IServiceProvider Provider { get; }
        String Named { get; set; }
        Guid Guid { get; set; }

        public Task ExecuteWorkflow();
    }
}
