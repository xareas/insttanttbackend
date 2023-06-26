using Insttantt.Workflow.Dtos;
using Insttantt.Workflow.Persistence.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace Insttantt.Workflow.CQRServices.Field;

public class QueryFieldHandler : IRequestHandler<QueryField, PagedResultDto<FieldDto>>
{
    private readonly IRepository<Models.Field, int> _repository;

    public QueryFieldHandler(IRepository<Models.Field, int> repository)
    {
        _repository = repository;
    }
    public async Task<PagedResultDto<FieldDto>> Handle(QueryField request, CancellationToken cancellationToken)
    {
        var steps = _repository.GetAll()
            .WhereIf(!string.IsNullOrWhiteSpace(request.Input.Filter), e => e.Code.Contains(request.Input.Filter));

        var filterSort = steps.OrderBy(request.Input.Sorting ?? "id desc")
            .PageBy(request.Input);

        var result = from o in filterSort
                     select new FieldDto()
                     {
                         Id = o.Id,
                         Code = o.Code,
                         Name = o.Name
                     };

        var totalCount = await result.CountAsync(cancellationToken);
        var data = await result.ToListAsync(cancellationToken);

        return new PagedResultDto<FieldDto>(totalCount, data);
    }
}

public record QueryField(GenericRequest Input) : IRequest<PagedResultDto<FieldDto>>
{
}

