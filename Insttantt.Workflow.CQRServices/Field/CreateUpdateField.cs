using FluentValidation;
using Insttantt.Workflow.Dtos;
using Insttantt.Workflow.Persistence.Repositories;
using Mapster;
using MediatR;

namespace Insttantt.Workflow.CQRServices.Field;

public class CreateUpdateFieldHandler : IRequestHandler<CreateUpdateField, FieldDto>
{
    private readonly IRepository<Models.Field, int> _repository;
    private readonly IValidator<FieldDto> _validator;
    public CreateUpdateFieldHandler(IRepository<Models.Field, int> repository, IValidator<FieldDto> validator)
    {
        _repository = repository;
        _validator = validator;
    }

    public async Task<FieldDto> Handle(CreateUpdateField request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request.Input, cancellationToken);

        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }


        var data = request.Input.Adapt<Models.Field>();
        data.Id = await _repository.InsertOrUpdateAndGetIdAsync(data);
        return data.Adapt<FieldDto>();
    }
}

//Parametro de Actualizacion
public record CreateUpdateField(FieldDto Input) : IRequest<FieldDto>
{
}


