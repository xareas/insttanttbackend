using Insttantt.Workflow.Dtos;
using Insttantt.Workflow.Persistence.Repositories;
using Mapster;
using MediatR;

namespace Insttantt.Workflow.CQRServices.Field
{

    public class QueryByIdFieldHandler : IRequestHandler<QueryByIdField, FieldDto>
    {
        private readonly IRepository<Models.Field, int> _repository;
        public QueryByIdFieldHandler(IRepository<Models.Field, int> repository)
        {
            _repository = repository;
        }

        public async Task<FieldDto> Handle(QueryByIdField request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.Id);
            var output = entity.Adapt<FieldDto>();
            return output;
        }
    }

    public record QueryByIdField(int Id) : IRequest<FieldDto>
    {
    }
}
