using DotNet.FunctionalExtensions.Extensions;
using DotNet.FunctionalExtensions.Interfaces;
using System.Reflection;

namespace DotNet.FunctionalExtensions.Services;

public class AssemblyFileReader : IAssemblyFileReader
{
    public string GetFileFromCurrentAssembly(string path)
    {
        if (path.IsNullOrWhitespace())
        {
            throw new ArgumentNullException(nameof(path));
        }

        var callingAssemblyLocation = Assembly.GetCallingAssembly().Location;

        var assemblyDirectory = callingAssemblyLocation.GetDirectoryName();
        var fileLocation = assemblyDirectory.JoinPath(path);
        using (var stream = new StreamReader(fileLocation))
        {
            var result = stream.ReadToEnd();
            return result;
        }
    }
}