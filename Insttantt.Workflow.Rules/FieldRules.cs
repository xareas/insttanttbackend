using FluentValidation;
using Insttantt.Workflow.Dtos;

namespace Insttantt.Workflow.Rules;
public class FieldRules : AbstractValidator<FieldDto>
{
    public FieldRules()
    {

        RuleFor(p => p.Code).NotEmpty();
        RuleFor(p => p.Code).MaximumLength(50);
        RuleFor(p => p.Name).NotEmpty();
        RuleFor(p => p.Name).MaximumLength(150);


    }

}
