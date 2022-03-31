using QuickChecks.Kernel.Entities.Enum;
using System;
using System.Collections.Generic;

namespace QuickChecks.Kernel.Entities;

public class PollEntity
{
    public int Id { get; set; }
    public string Title { get; set; }
    public PollStatus Status { get; set; }
    public bool IsDeleted { get; set; }
    public DateTimeOffset? StartedDate { get; set; }
    public DateTimeOffset? CompletedDate { get; set; }

    public int? PollTemplateId { get; set; }
    public PollTemplateEntity PollTemplate { get; set; }
    public IEnumerable<CategoryEntity> Categories { get; set; }
}