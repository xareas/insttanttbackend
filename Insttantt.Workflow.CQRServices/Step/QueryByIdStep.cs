using Insttantt.Workflow.Dtos;
using Insttantt.Workflow.Persistence.Repositories;
using Mapster;
using MediatR;

namespace Insttantt.Workflow.CQRServices.Step;

public class QueryByIdStepHandler : IRequestHandler<QueryByIdStep, StepDto>
{
    private readonly IRepository<Models.Step, int> _repository;
    public QueryByIdStepHandler(IRepository<Models.Step, int> repository)
    {
        _repository = repository;
    }

    public async Task<StepDto> Handle(QueryByIdStep request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id);
        var output = entity.Adapt<StepDto>();
        return output;
    }
}

public record QueryByIdStep(int Id) : IRequest<StepDto>
{
}
