using System.Collections.Generic;

namespace QuickChecks.Kernel.Interfaces;

public interface IMapper<in TSource, out TDestination>
    where TSource : class
    where TDestination : class
{
    TDestination Map(TSource source);
    IEnumerable<TDestination> MapCollection(IEnumerable<TSource> source);
}