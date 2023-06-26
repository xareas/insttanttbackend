using Insttantt.Workflow.Dtos;
using Insttantt.Workflow.Persistence.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace Insttantt.Workflow.CQRServices.Worflow;



public class QueryWorkflowHandler : IRequestHandler<QueryWorkflow, PagedResultDto<WorkflowDto>>
{
    private readonly IRepository<Models.Workflow, int> _repository;

    public QueryWorkflowHandler(IRepository<Models.Workflow, int> repository)
    {
        _repository = repository;
    }
    public async Task<PagedResultDto<WorkflowDto>> Handle(QueryWorkflow request, CancellationToken cancellationToken)
    {
        var steps = _repository.GetAll()
            .WhereIf(!string.IsNullOrWhiteSpace(request.Input.Filter), e => e.Code.Contains(request.Input.Filter));

        var filterSort = steps.OrderBy(request.Input.Sorting ?? "id desc")
            .PageBy(request.Input);

        var result = from o in filterSort
                     select new WorkflowDto()
                     {
                         Id = o.Id,
                         Code = o.Code,
                         Name = o.Name
                     };

        var totalCount = await result.CountAsync(cancellationToken);
        var data = await result.ToListAsync(cancellationToken);

        return new PagedResultDto<WorkflowDto>(totalCount, data);
    }
}

public record QueryWorkflow(GenericRequest Input) : IRequest<PagedResultDto<WorkflowDto>>
{
}
