using System;
using System.Runtime.Serialization;

namespace DLN.Storage
{
    [Serializable]
    internal class MessageNotFoundException : Exception
    {
        public MessageNotFoundException()
        {
        }

        public MessageNotFoundException(string message) : base(message)
        {
        }

        public MessageNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected MessageNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}