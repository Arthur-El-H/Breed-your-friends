using System;
using System.Runtime.Serialization;

[Serializable]
internal class wrongMethodParamException : Exception
{
    public wrongMethodParamException()
    {
    }

    public wrongMethodParamException(string message) : base(message)
    {
    }

    public wrongMethodParamException(string message, Exception innerException) : base(message, innerException)
    {
    }

    protected wrongMethodParamException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}