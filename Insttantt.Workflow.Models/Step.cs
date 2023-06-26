namespace Insttantt.Workflow.Models;
public class Step : Entity<int>
{
    public Step()
    {
    }

    public string Code { get; set; } = null!;
    public string Name { get; set; } = null!;

}
