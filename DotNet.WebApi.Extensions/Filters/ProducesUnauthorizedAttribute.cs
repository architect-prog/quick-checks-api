using DotNet.WebApi.Extensions.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNet.WebApi.Extensions.Filters;

public class ProducesUnauthorizedAttribute : ProducesResponseTypeAttribute
{
    public ProducesUnauthorizedAttribute()
        : base(typeof(ErrorResult), StatusCodes.Status401Unauthorized)
    {
    }
}