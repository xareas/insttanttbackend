using FluentValidation;
using Insttantt.Workflow.Dtos;

namespace Insttantt.Workflow.Rules;
public class WorkflowStepFieldRules : AbstractValidator<WorkflowStepFieldDto>
{
    public WorkflowStepFieldRules()
    {
        RuleFor(p => p.SetValue).MaximumLength(250);

    }

}
