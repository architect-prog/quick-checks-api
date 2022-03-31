using System;
using System.Collections.Generic;

namespace QuickChecks.Kernel.Entities;

public class PollTemplateEntity
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTimeOffset CreatedDate { get; set; }
    public DateTimeOffset UpdatedDate { get; set; }

    public IEnumerable<PollEntity> Polls { get; set; }
}