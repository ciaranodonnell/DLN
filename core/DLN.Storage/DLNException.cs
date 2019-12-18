using System;
using System.Runtime.Serialization;

namespace DLN.Core
{
    [Serializable]
    internal class DLNException : Exception
    {
        public DLNException()
        {
        }

        public DLNException(string message) : base(message)
        {
        }

        public DLNException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DLNException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}