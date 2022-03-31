using DotNet.FunctionalExtensions.Extensions;
using QuickChecks.ContentProcessing.Dto;
using QuickChecks.ContentProcessing.Interfaces;
using System;

namespace QuickChecks.ContentProcessing.Services;

public class PollContentSerializer : IPollContentSerializer
{
    private readonly ISerializerFactory serializerFactory;

    public PollContentSerializer(ISerializerFactory serializerFactory)
    {
        this.serializerFactory = serializerFactory;
    }

    public string SerializePollContent(PollContentDto content)
    {
        if (content == null)
        {
            throw new ArgumentNullException(nameof(content));
        }

        var serializer = serializerFactory.CreateSerializer();
        var result = serializer.Serialize(content);
        return result;
    }

    public PollContentDto DeserializePollContent(string content)
    {
        if (content.IsNullOrWhitespace())
        {
            throw new ArgumentNullException(nameof(content));
        }

        var deserializer = serializerFactory.CreateDeserializer();
        var result = deserializer.Deserialize<PollContentDto>(content);
        return result;
    }
}