namespace DotNet.FunctionalExtensions.Extensions;

public static class StringExtensions
{
    public static bool IsNullOrWhitespace(this string source)
    {
        var result = string.IsNullOrWhiteSpace(source);
        return result;
    }
}