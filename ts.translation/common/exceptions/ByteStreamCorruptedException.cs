using System;
using System.Runtime.Serialization;

namespace ts.translation.common.exceptions
{
    class ByteStreamCorruptedException : Exception
    {
        public ByteStreamCorruptedException()
        {
        }

        public ByteStreamCorruptedException(string message) : base(message)
        {
        }

        public ByteStreamCorruptedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ByteStreamCorruptedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}