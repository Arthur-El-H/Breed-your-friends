using System;
using System.Runtime.Serialization;

[Serializable]
internal class unexpectedError : Exception
{
    public unexpectedError()
    {
    }

    public unexpectedError(string message) : base(message)
    {
    }

    public unexpectedError(string message, Exception innerException) : base(message, innerException)
    {
    }

    protected unexpectedError(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}