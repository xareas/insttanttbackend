using FluentValidation;
using Insttantt.Workflow.Dtos;
using Insttantt.Workflow.Persistence.Repositories;
using Mapster;
using MediatR;

namespace Insttantt.Workflow.CQRServices.Step;

public class CreateStepHandler : IRequestHandler<CreateStep, StepDto>
{
    private readonly IRepository<Models.Step, int> _repository;
    private readonly IValidator<StepDto> _validator;
    public CreateStepHandler(IRepository<Models.Step, int> repository, IValidator<StepDto> validator)
    {
        _repository = repository;
        _validator = validator;
    }

    public async Task<StepDto> Handle(CreateStep request, CancellationToken cancellationToken)
    {

        var validationResult = await _validator.ValidateAsync(request.Input, cancellationToken);

        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }
        var data = request.Input.Adapt<Models.Step>();
        data.Id = await _repository.InsertOrUpdateAndGetIdAsync(data);
        return data.Adapt<StepDto>();
    }
}

//Parametro de Actualizacion
public record CreateStep(StepDto Input) : IRequest<StepDto>
{
}

