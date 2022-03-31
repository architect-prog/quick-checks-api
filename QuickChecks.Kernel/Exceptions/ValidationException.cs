using System;
using System.Runtime.Serialization;

namespace QuickChecks.Kernel.Exceptions;

[Serializable]
public class ValidationException : Exception
{
    public ValidationException(string message) : base(message)
    {
    }

    protected ValidationException(
        SerializationInfo info,
        StreamingContext context) : base(info, context)
    {
    }
}