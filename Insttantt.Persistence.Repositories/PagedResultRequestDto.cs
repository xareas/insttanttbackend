using System.ComponentModel.DataAnnotations;

namespace Insttantt.Workflow.Persistence.Repositories;

/// <summary>
/// Resultado del Paginado de una Request
/// </summary>
public class PagedResultRequestDto :
        LimitedResultRequestDto,
        IPagedResultRequest,
        ILimitedResultRequest
{
    [Range(0, int.MaxValue)]
    public virtual int SkipCount { get; set; }

}

