namespace Insttantt.Workflow.Dtos;
public partial class WorkflowStepFieldDto
{
    public int Id { get; set; }

    public int WorkflowStepId { get; set; }

    public int FieldId { get; set; }

    public string? SetValue { get; set; }

    public bool Output { get; set; }


}
