using DotNet.WebApi.Extensions.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNet.WebApi.Extensions.Filters;

public class ProducesBadRequestAttribute : ProducesResponseTypeAttribute
{
    public ProducesBadRequestAttribute()
        : base(typeof(ErrorResult), StatusCodes.Status400BadRequest)
    {
    }
}