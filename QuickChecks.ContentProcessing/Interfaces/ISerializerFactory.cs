using YamlDotNet.Serialization;

namespace QuickChecks.ContentProcessing.Interfaces;

public interface ISerializerFactory
{
    ISerializer CreateSerializer();
    IDeserializer CreateDeserializer();
}