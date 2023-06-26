using Insttantt.Workflow.CQRServices.Field;
using Insttantt.Workflow.Dtos;
using Insttantt.Workflow.EndPointApi.Infraestructure;
using Insttantt.Workflow.Persistence.Repositories;
using Insttantt.Workflow.Shared;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Insttantt.Workflow.EndPointApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FieldController : BaseController<FieldDto, int>
{
    public FieldController(ILoggerManager logger, IMediator mediator) : base(logger, mediator)
    {
    }

    [HttpGet]
    [Route("GetAll")]
    public override async Task<PagedResultDto<FieldDto>> GetAll(GenericRequest input)
    {
        var data = await Mediator.Send(new QueryField(input));
        return data;
    }

    [HttpGet]
    [Route("GetById")]
    public override async Task<FieldDto> GetById(int id)
    {
        var data = await Mediator.Send(new QueryByIdField(id));
        return data;
    }

    [HttpPost]
    [Route("Create")]
    public override async Task<FieldDto> InsertOrEdit(FieldDto input)
    {
        var data = await Mediator.Send(new CreateUpdateField(input));
        return data;
    }

    [HttpPost]
    [Route("Delete")]
    public override async Task<OkResult> Delete(EntityDto<int> input)
    {
        await Mediator.Send(new DeleteField(input));
        return Ok();
    }


}