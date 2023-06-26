using FluentValidation;
using Insttantt.Workflow.Dtos;
using Insttantt.Workflow.Persistence.Repositories;
using Mapster;
using MediatR;

namespace Insttantt.Workflow.CQRServices.Worflow;


public class AddWorkflowStepFieldHandler : IRequestHandler<AddWorkflowStepField, WorkflowStepFieldDto>
{
    private readonly IRepository<Models.WorkflowStepField, int> _repository;
    private readonly IValidator<WorkflowStepFieldDto> _validator;
    public AddWorkflowStepFieldHandler(IRepository<Models.WorkflowStepField, int> repository, IValidator<WorkflowStepFieldDto> validator)
    {
        _repository = repository;
        _validator = validator;
    }

    public async Task<WorkflowStepFieldDto> Handle(AddWorkflowStepField request, CancellationToken cancellationToken)
    {

        var validationResult = await _validator.ValidateAsync(request.Input, cancellationToken);
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }
        var data = request.Input.Adapt<Models.WorkflowStepField>();
        data.Id = await _repository.InsertOrUpdateAndGetIdAsync(data);
        return data.Adapt<WorkflowStepFieldDto>();
    }
}

//Parametro de Actualizacion
public record AddWorkflowStepField(WorkflowStepFieldDto Input) : IRequest<WorkflowStepFieldDto>
{
}

