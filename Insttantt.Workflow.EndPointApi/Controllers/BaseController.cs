using Insttantt.Workflow.EndPointApi.Infraestructure;
using Insttantt.Workflow.Persistence.Repositories;
using Insttantt.Workflow.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Insttantt.Workflow.EndPointApi.Controllers
{
    public abstract class BaseController<TEntityDto, TKey> : ControllerBase
        where TEntityDto : class
    {
        protected readonly ILoggerManager Logger;
        protected readonly IMediator Mediator;
        protected BaseController(ILoggerManager logger, IMediator mediator)
        {
            Logger = logger;
            Mediator = mediator;
        }

        public abstract Task<PagedResultDto<TEntityDto>> GetAll(GenericRequest input);
        public abstract Task<TEntityDto> GetById(TKey id);
        public abstract Task<TEntityDto> InsertOrEdit(TEntityDto input);
        public abstract Task Delete(EntityDto<TKey> input);

    }
}
