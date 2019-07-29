using System;
using System.Runtime.Serialization;

namespace ts.translation.common.exceptions
{
    internal class TranslationObjectCountOutOfBoundsException : Exception
    {
        public TranslationObjectCountOutOfBoundsException()
        {
        }

        public TranslationObjectCountOutOfBoundsException(string message) : base(message)
        {
        }

        public TranslationObjectCountOutOfBoundsException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected TranslationObjectCountOutOfBoundsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}