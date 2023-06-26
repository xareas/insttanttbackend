using Insttantt.Workflow.CQRServices.Worflow;
using Insttantt.Workflow.Dtos;
using Insttantt.Workflow.EndPointApi.Infraestructure;
using Insttantt.Workflow.Persistence.Repositories;
using Insttantt.Workflow.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Insttantt.Workflow.EndPointApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WorkflowController : BaseController<WorkflowDto, int>
{

    public WorkflowController(ILoggerManager logger,
        IMediator mediator) : base(logger, mediator)
    {
    }

    [HttpGet]
    [Route("GetAll")]
    public override async Task<PagedResultDto<WorkflowDto>> GetAll(GenericRequest input)
    {
        var data = await Mediator.Send(new QueryWorkflow(input));
        return data;
    }

    [HttpGet]
    [Route("GetById")]
    public override async Task<WorkflowDto> GetById(int id)
    {
        var data = await Mediator.Send(new QueryByIdWorkflow(id));
        return data;
    }

    [HttpPost]
    [Route("Create")]
    public override async Task<WorkflowDto> InsertOrEdit(WorkflowDto input)
    {
        var data = await Mediator.Send(new CreateWorkflow(input));
        return data;
    }

    [HttpPost]
    [Route("Delete")]
    public override async Task<OkResult> Delete(EntityDto<int> input)
    {
        await Mediator.Send(new DeleteWorkflow(input));
        return Ok();
    }


}