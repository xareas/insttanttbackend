using Insttantt.Workflow.Persistence.Repositories;
using Insttantt.Workflow.Shared;
using MediatR;

namespace Insttantt.Workflow.CQRServices.Field
{
    public class DeleteFieldHandler : IRequestHandler<DeleteField>
    {
        private readonly IRepository<Models.Field, int> _repository;
        public DeleteFieldHandler(IRepository<Models.Field, int> repository)
        {
            _repository = repository;
        }
        public async Task Handle(DeleteField request, CancellationToken cancellationToken)
        {
            await _repository.DeleteAsync(request.Input.Id);
        }
    }


    public record DeleteField(EntityDto<int> Input) : IRequest
    {
    }

}
