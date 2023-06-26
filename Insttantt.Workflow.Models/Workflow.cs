namespace Insttantt.Workflow.Models;
public class Workflow : Entity<int>
{
    public Workflow()
    {
        WorkflowSteps = new HashSet<WorkflowStep>();

    }
    public string Code { get; set; } = null!;

    public string Name { get; set; } = null!;

    public virtual ICollection<WorkflowStep> WorkflowSteps { get; set; }



}
