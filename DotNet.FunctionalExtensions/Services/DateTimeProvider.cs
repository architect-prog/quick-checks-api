using DotNet.FunctionalExtensions.Interfaces;

namespace DotNet.FunctionalExtensions.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTimeOffset GetUtcNow()
    {
        var result = DateTimeOffset.UtcNow;
        return result;
    }
}