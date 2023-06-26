using Insttantt.Workflow.Dtos;
using Insttantt.Workflow.Persistence.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace Insttantt.Workflow.CQRServices.Step;

public class QueryStepHandler : IRequestHandler<QueryStep, PagedResultDto<StepDto>>
{
    private readonly IRepository<Models.Step, int> _repository;

    public QueryStepHandler(IRepository<Models.Step, int> repository)
    {
        _repository = repository;
    }
    public async Task<PagedResultDto<StepDto>> Handle(QueryStep request, CancellationToken cancellationToken)
    {
        var steps = _repository.GetAll()
            .WhereIf(!string.IsNullOrWhiteSpace(request.Input.Filter), e => e.Code.Contains(request.Input.Filter));

        var filterSort = steps.OrderBy(request.Input.Sorting ?? "id desc")
            .PageBy(request.Input);

        var result = from o in filterSort
                     select new StepDto()
                     {
                         Id = o.Id,
                         Code = o.Code,
                         Name = o.Name
                     };

        var totalCount = await result.CountAsync(cancellationToken);
        var data = await result.ToListAsync(cancellationToken);

        return new PagedResultDto<StepDto>(totalCount, data);
    }
}

public record QueryStep(GenericRequest Input) : IRequest<PagedResultDto<StepDto>>
{
}
