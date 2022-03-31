using QuickChecks.ContentProcessing.Dto.InnerDto;
using System.Collections.Generic;

namespace QuickChecks.ContentProcessing.Dto;

public class PollContentDto
{
    public IEnumerable<ParsedCategoryDto> Categories { get; set; }
}