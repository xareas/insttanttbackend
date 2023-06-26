using FluentValidation;
using Insttantt.Workflow.Dtos;
using Insttantt.Workflow.Persistence.Repositories;
using Mapster;
using MediatR;

namespace Insttantt.Workflow.CQRServices.Worflow;

public class CreateWorkflowHandler : IRequestHandler<CreateWorkflow, WorkflowDto>
{
    private readonly IRepository<Models.Workflow, int> _repository;
    private readonly IValidator<WorkflowDto> _validator;
    public CreateWorkflowHandler(IRepository<Models.Workflow, int> repository, IValidator<WorkflowDto> validator)
    {
        _repository = repository;
        _validator = validator;
    }

    public async Task<WorkflowDto> Handle(CreateWorkflow request, CancellationToken cancellationToken)
    {

        var validationResult = await _validator.ValidateAsync(request.Input, cancellationToken);
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }
        var data = request.Input.Adapt<Models.Workflow>();
        data.Id = await _repository.InsertOrUpdateAndGetIdAsync(data);
        return data.Adapt<WorkflowDto>();
    }
}

//Parametro de Actualizacion
public record CreateWorkflow(WorkflowDto Input) : IRequest<WorkflowDto>
{
}

