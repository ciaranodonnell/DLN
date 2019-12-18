using System;
using System.Runtime.Serialization;

namespace DLN.AMQP.Frames
{
    [Serializable]
    internal class AMQPSerializationException : Exception
    {
        public AMQPSerializationException()
        {
        }

        public AMQPSerializationException(string message) : base(message)
        {
        }

        public AMQPSerializationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected AMQPSerializationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}