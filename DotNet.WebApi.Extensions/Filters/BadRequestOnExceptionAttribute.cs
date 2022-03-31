using DotNet.WebApi.Extensions.Filters.Base;
using Microsoft.AspNetCore.Http;

namespace DotNet.WebApi.Extensions.Filters;

public class BadRequestOnExceptionAttribute : HttpStatusCodeOnExceptionAttribute
{
    public BadRequestOnExceptionAttribute(params Type[] exceptionTypes)
        : base(StatusCodes.Status400BadRequest, exceptionTypes)
    {
    }
}