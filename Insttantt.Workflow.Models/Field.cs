namespace Insttantt.Workflow.Models;
public class Field : Entity<int>
{
    public Field()
    {

    }

    public string Code { get; set; } = null!;
    public string Name { get; set; } = null!;

}
