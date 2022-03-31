namespace DotNet.WebApi.Extensions.Responses;

public class CollectionWrapper<T>
{
    public IEnumerable<T> Items { get; }
    public int TotalCount { get; }

    public CollectionWrapper(IEnumerable<T> items, int totalCount)
    {
        Items = items;
        TotalCount = totalCount;
    }
}