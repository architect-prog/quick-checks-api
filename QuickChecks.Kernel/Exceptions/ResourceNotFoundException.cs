using System;
using System.Runtime.Serialization;

namespace QuickChecks.Kernel.Exceptions;

[Serializable]
public class ResourceNotFoundException : Exception
{
    public ResourceNotFoundException(string resourceName) : base(resourceName)
    {
    }

    protected ResourceNotFoundException(
        SerializationInfo info,
        StreamingContext context) : base(info, context)
    {
    }
}