namespace Insttantt.Workflow.Persistence.Repositories;

//IPagedResultRequest,ILimitedResultRequest,ISortedResultRequest
public class PagedAndSortedResultRequestDto : PagedResultRequestDto, IPagedAndSortedResultRequest
{
    public virtual string Sorting { get; set; } = "";
}

