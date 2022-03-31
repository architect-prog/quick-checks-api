using QuickChecks.ContentProcessing.Interfaces;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace QuickChecks.ContentProcessing.Services;

public class SerializerFactory : ISerializerFactory
{
    public ISerializer CreateSerializer()
    {
        var serializer = new SerializerBuilder()
            .WithNamingConvention(CamelCaseNamingConvention.Instance)
            .Build();

        return serializer;
    }

    public IDeserializer CreateDeserializer()
    {
        var deserializer = new DeserializerBuilder()
            .WithNamingConvention(CamelCaseNamingConvention.Instance)
            .Build();

        return deserializer;
    }
}