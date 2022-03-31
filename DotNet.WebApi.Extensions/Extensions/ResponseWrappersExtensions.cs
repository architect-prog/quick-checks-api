using DotNet.WebApi.Extensions.Responses;

namespace DotNet.WebApi.Extensions.Extensions;

public static class ResponseWrappersExtensions
{
    public static CollectionWrapper<T> WrapCollection<T>(this IEnumerable<T> source, int totalCount)
    {
        if (source == null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        var result = new CollectionWrapper<T>(source, totalCount);
        return result;
    }
}