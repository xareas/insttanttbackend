using Insttantt.Workflow.Dtos;
using Insttantt.Workflow.Persistence.Repositories;
using Mapster;
using MediatR;

namespace Insttantt.Workflow.CQRServices.Worflow;

public class QueryByIdWorkFlowHandler : IRequestHandler<QueryByIdWorkflow, WorkflowDto>
{
    private readonly IRepository<Models.Workflow, int> _repository;
    public QueryByIdWorkFlowHandler(IRepository<Models.Workflow, int> repository)
    {
        _repository = repository;
    }

    public async Task<WorkflowDto> Handle(QueryByIdWorkflow request, CancellationToken cancellationToken)
    {
        var entity = await _repository.GetByIdAsync(request.Id);
        var output = entity.Adapt<WorkflowDto>();
        return output;
    }
}

public record QueryByIdWorkflow(int Id) : IRequest<WorkflowDto>
{
}


