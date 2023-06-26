﻿using System.ComponentModel.DataAnnotations;

namespace Insttantt.Workflow.Persistence.Repositories;

public class LimitedResultRequestDto : ILimitedResultRequest
{
    [Range(1, int.MaxValue)]
    public virtual int MaxResultCount { get; set; } = 10;
}

