using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNet.WebApi.Extensions.Filters;

public class ProducesNoContentAttribute : ProducesResponseTypeAttribute
{
    public ProducesNoContentAttribute()
        : base(StatusCodes.Status204NoContent)
    {
    }
}