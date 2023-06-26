using Insttantt.Workflow.Persistence.Repositories;
using Insttantt.Workflow.Shared;
using MediatR;

namespace Insttantt.Workflow.CQRServices.Worflow;
public class DeleteWorkflowHandler : IRequestHandler<DeleteWorkflow>
{
    private readonly IRepository<Models.Workflow, int> _repository;
    public DeleteWorkflowHandler(IRepository<Models.Workflow, int> repository)
    {
        _repository = repository;
    }
    public async Task Handle(DeleteWorkflow request, CancellationToken cancellationToken)
    {
        await _repository.DeleteAsync(request.Input.Id);
    }
}


public record DeleteWorkflow(EntityDto<int> Input) : IRequest
{
}

