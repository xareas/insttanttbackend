using Insttantt.Workflow.Core;
using Insttantt.Workflow.Shared;
using Microsoft.AspNetCore.Mvc;

namespace Insttantt.Workflow.EndPointApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ExecuteController : ControllerBase
{
    private readonly IWorkflowBuilder _builder;
    public ExecuteController(IWorkflowBuilder builder)
    {
        _builder = builder;
    }


    [HttpPost]
    [Route("ExecuteWorkflow")]
    public async Task<OkResult> Execute(EntityDto<int> input)
    {
        await _builder.ExecuteWorkflow();
        //await Mediator.Send(new DeleteWorkflow(input));
        return Ok();
    }

}