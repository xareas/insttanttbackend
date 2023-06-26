using Insttantt.Workflow.Dtos;

namespace Insttantt.Workflow.Core
{
    /// <summary>
    /// Pattern : Chain of Responsability
    /// </summary>
    public abstract class StepChain
    {
        protected string Named { get; set; }
        protected StepChain Next;
        public void SetNextStep(StepChain next)
        {
            Next = next;
        }

        public void MakeStep()
        {
            //Process();
            Next?.MakeStep();
        }
        /// <summary>
        /// Una tarea o 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public abstract Task<List<FieldDto>> Process(List<FieldDto> input);
    }
}
