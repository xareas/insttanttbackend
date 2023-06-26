using FluentValidation;
using Insttantt.Workflow.Dtos;
using Insttantt.Workflow.Persistence.Repositories;
using Mapster;
using MediatR;

namespace Insttantt.Workflow.CQRServices.Worflow;

public class AddWorkflowStepHandler : IRequestHandler<AddWorkflowStep, WorkflowStepDto>
{
    private readonly IRepository<Models.WorkflowStep, int> _repository;
    private readonly IValidator<WorkflowStepDto> _validator;
    public AddWorkflowStepHandler(IRepository<Models.WorkflowStep, int> repository, IValidator<WorkflowStepDto> validator)
    {
        _repository = repository;
        _validator = validator;
    }

    public async Task<WorkflowStepDto> Handle(AddWorkflowStep request, CancellationToken cancellationToken)
    {

        var validationResult = await _validator.ValidateAsync(request.Input, cancellationToken);
        if (!validationResult.IsValid)
        {
            throw new ValidationException("Error de Validaciones", validationResult.Errors);
        }
        var data = request.Input.Adapt<Models.WorkflowStep>();
        data.Id = await _repository.InsertOrUpdateAndGetIdAsync(data);
        return data.Adapt<WorkflowStepDto>();
    }
}

//Parametro de Actualizacion
public record AddWorkflowStep(WorkflowStepDto Input) : IRequest<WorkflowStepDto>
{
}

