using System;
using System.Runtime.Serialization;

namespace DLN.AMQP
{
    [Serializable]
    internal class AMQPException : Exception
    {
        public AMQPException()
        {
        }

        public AMQPException(string message) : base(message)
        {
        }

        public AMQPException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected AMQPException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}