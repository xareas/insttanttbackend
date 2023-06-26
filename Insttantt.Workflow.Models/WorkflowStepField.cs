namespace Insttantt.Workflow.Models;
public class WorkflowStepField : Entity<int>
{
    public WorkflowStepField()
    {

    }

    public int WorkflowStepId { get; set; }

    public int FieldId { get; set; }

    public string? SetValue { get; set; }

    public bool Output { get; set; }



    public virtual Field Field { get; set; } = null!;

    public virtual WorkflowStep WorkflowStep { get; set; } = null!;



}
