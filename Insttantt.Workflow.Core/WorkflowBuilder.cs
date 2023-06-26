using Insttantt.Workflow.Dtos;
using Insttantt.Workflow.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Insttantt.Workflow.Core
{
     /// <summary>
     /// todo: No se pudo concluir el workflow con manejos de estados.
     /// Sorry.
     /// </summary>
    public class WorkflowBuilder : IWorkflowBuilder
    {
        public IServiceProvider Provider { get; }
        public string Named { get; set; }
        public Guid Guid { get; set; }

        public WorkflowBuilder(IServiceProvider provider)
        {
            Provider = provider;
            Named = "";
            Guid = Guid.NewGuid();
        }

        public async Task ExecuteWorkflow()
        {

            var stepRepo = (IRepository<Models.WorkflowStep, int>)Provider.GetService(typeof(IRepository<Models.WorkflowStep, int>))!;

            var steps = await stepRepo.GetAll()
                                             .Where(filter => filter.WorkFlowId == 1).ToListAsync();

            foreach (var e in steps)
            {
                var outputs = await new StepBuilder(e.Step.Code).Process(new List<FieldDto>());
            }

        }


    }
}
