using DotNet.WebApi.Extensions.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNet.WebApi.Extensions.Filters;

public class ProducesNotFoundAttribute : ProducesResponseTypeAttribute
{
    public ProducesNotFoundAttribute()
        : base(typeof(ErrorResult), StatusCodes.Status404NotFound)
    {
    }
}