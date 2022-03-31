namespace DotNet.FunctionalExtensions.Interfaces;

public interface IAssemblyFileReader
{
    string GetFileFromCurrentAssembly(string path);
}