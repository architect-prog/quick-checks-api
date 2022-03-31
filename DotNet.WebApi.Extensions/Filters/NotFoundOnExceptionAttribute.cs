using DotNet.WebApi.Extensions.Filters.Base;
using Microsoft.AspNetCore.Http;

namespace DotNet.WebApi.Extensions.Filters;

public class NotFoundOnExceptionAttribute : HttpStatusCodeOnExceptionAttribute
{
    public NotFoundOnExceptionAttribute(params Type[] exceptionTypes)
        : base(StatusCodes.Status404NotFound, exceptionTypes)
    {
    }
}