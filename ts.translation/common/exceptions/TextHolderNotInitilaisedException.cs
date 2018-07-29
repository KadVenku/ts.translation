using System;
using System.Runtime.Serialization;

namespace ts.translation.common.exceptions
{
    class TextHolderNotInitilaisedException : Exception
    {
        public TextHolderNotInitilaisedException()
        {
        }

        public TextHolderNotInitilaisedException(string message) : base(message)
        {
        }

        public TextHolderNotInitilaisedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected TextHolderNotInitilaisedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}