namespace Insttantt.Workflow.Dtos;
public partial class WorkflowStepDto
{

    public int Id { get; set; }

    public int WorkFlowId { get; set; }

    public int StepId { get; set; }

    public int StepNumber { get; set; }

    public int After { get; set; }

    public int Before { get; set; }



}
