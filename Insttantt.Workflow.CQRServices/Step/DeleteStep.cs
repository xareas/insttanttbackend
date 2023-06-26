using Insttantt.Workflow.Persistence.Repositories;
using Insttantt.Workflow.Shared;
using MediatR;

namespace Insttantt.Workflow.CQRServices.Step;

public class DeleteStepHandler : IRequestHandler<DeleteStep>
{
    private readonly IRepository<Models.Step, int> _repository;
    public DeleteStepHandler(IRepository<Models.Step, int> repository)
    {
        _repository = repository;
    }
    public async Task Handle(DeleteStep request, CancellationToken cancellationToken)
    {
        await _repository.DeleteAsync(request.Input.Id);
    }
}


public record DeleteStep(EntityDto<int> Input) : IRequest
{
}

