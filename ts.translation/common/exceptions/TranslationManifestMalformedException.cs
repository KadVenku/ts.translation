using System;
using System.Runtime.Serialization;

namespace ts.translation.common.exceptions
{
    internal class TranslationManifestMalformedException : Exception
    {
        public TranslationManifestMalformedException()
        {
        }

        public TranslationManifestMalformedException(string message) : base(message)
        {
        }

        public TranslationManifestMalformedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected TranslationManifestMalformedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}