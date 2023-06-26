using Insttantt.Workflow.Dtos;

namespace Insttantt.Workflow.Core
{
    public class StepBuilder : StepChain
    {
        public StepBuilder(String named)
        {
            Named = named;
        }

        public override async Task<List<FieldDto>> Process(List<FieldDto> input)
        {
            //Recuperamos los pasos del repositorio
            Console.WriteLine("Procesando Paso.....");
            return new List<FieldDto>() { new FieldDto() };
        }
    }
}
