namespace Insttantt.Workflow.Persistence.Repositories;

public class GenericRequest : PagedAndSortedResultRequestDto
{
    public string Filter { get; set; }
}

