using Insttantt.Workflow.CQRServices.Step;
using Insttantt.Workflow.Dtos;
using Insttantt.Workflow.EndPointApi.Infraestructure;
using Insttantt.Workflow.Persistence.Repositories;
using Insttantt.Workflow.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Insttantt.Workflow.EndPointApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StepController : BaseController<StepDto, int>
{

    public StepController(ILoggerManager logger, IMediator mediator) : base(logger, mediator)
    {
    }

    [HttpGet]
    [Route("GetAll")]
    public override async Task<PagedResultDto<StepDto>> GetAll(GenericRequest input)
    {
        var data = await Mediator.Send(new QueryStep(input));
        return data;
    }

    [HttpGet]
    [Route("GetById")]
    public override async Task<StepDto> GetById(int id)
    {
        var data = await Mediator.Send(new QueryByIdStep(id));
        return data;
    }

    [HttpPost]
    [Route("Create")]
    public override async Task<StepDto> InsertOrEdit(StepDto input)
    {
        var data = await Mediator.Send(new CreateStep(input));
        return data;
    }

    [HttpPost]
    [Route("Delete")]
    public override async Task<OkResult> Delete(EntityDto<int> input)
    {
        await Mediator.Send(new DeleteStep(input));
        return Ok();
    }


}