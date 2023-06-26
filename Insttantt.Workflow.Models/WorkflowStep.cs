namespace Insttantt.Workflow.Models;
public class WorkflowStep : Entity<int>
{
    public WorkflowStep()
    {
        WorkflowStepFields = new HashSet<WorkflowStepField>();

    }


    public int WorkFlowId { get; set; }

    public int StepId { get; set; }

    public int StepNumber { get; set; }

    public int After { get; set; }

    public int Before { get; set; }


    public virtual Step Step { get; set; } = null!;
    public virtual Workflow Workflow { get; set; } = null!;
    public virtual ICollection<WorkflowStepField> WorkflowStepFields { get; set; }



}
