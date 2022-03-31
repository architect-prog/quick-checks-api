namespace DotNet.FunctionalExtensions.Extensions;

public static class PathExtensions
{
    public static string JoinPath(this string first, string second)
    {
        if (first.IsNullOrWhitespace())
        {
            throw new ArgumentNullException(nameof(first));
        }

        if (second.IsNullOrWhitespace())
        {
            throw new ArgumentNullException(nameof(second));
        }

        var result = Path.Join(first, second);
        return result;
    }

    public static string GetDirectoryName(this string path)
    {
        if (path.IsNullOrWhitespace())
        {
            throw new ArgumentNullException(nameof(path));
        }

        var result = Path.GetDirectoryName(path);
        return result;
    }
}