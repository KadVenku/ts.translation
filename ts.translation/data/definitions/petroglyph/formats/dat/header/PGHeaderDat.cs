using System;
using ts.translation.common.exceptions;

namespace ts.translation.data.definitions.petroglyph.formats.dat.header
{
    internal class PGHeaderDat
    {
        private uint TranslationObjectCount { get; }

        public PGHeaderDat()
        {
            TranslationObjectCount = 0;
        }

        internal PGHeaderDat(byte[] stream)
        {
            try
            {
                TranslationObjectCount = ReadFromByteStream(stream);
            }
            catch (Exception e)
            {
                if (e.GetType() != typeof(NullReferenceException))
                {
                    throw new ByteStreamCorruptedException("Failed to read corrupted byte stream.");
                }
                throw;
            }
        }

        internal PGHeaderDat(uint translationObjectCount)
        {
            TranslationObjectCount = translationObjectCount;
        }

        internal PGHeaderDat(int translationObjectCount)
        {
            if (translationObjectCount >= 0)
            {
                TranslationObjectCount = (uint) translationObjectCount;
            }
            else
            {
                throw new TranslationObjectCountOutOfBoundsException($"The index {translationObjectCount} is out of bounds.");
            }
        }

        private static uint ReadFromByteStream(byte[] stream)
        {
            return BitConverter.ToUInt32(stream, 0);
        }

        private byte[] ToBytes()
        {
            return BitConverter.GetBytes(TranslationObjectCount);
        }
    }
}
