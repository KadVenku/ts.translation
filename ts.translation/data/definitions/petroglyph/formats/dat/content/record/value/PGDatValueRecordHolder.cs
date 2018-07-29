using System;
using System.Collections.Generic;
using System.Text;

namespace ts.translation.data.definitions.petroglyph.formats.dat.content.record.value
{
    internal class DatValueRecordHolder : APGDatTableRecordHolder
    {
        private string _translation;

        internal string GetTranslation()
        {
            return _translation;
        }

        internal void SetTranslation(string translation)
        {
            _translation = translation;
        }

        internal DatValueRecordHolder()
        {
            SetTranslation("[MISSING]");
        }

        internal DatValueRecordHolder(string translation)
        {
            SetTranslation(translation);
        }

        internal DatValueRecordHolder(byte[] bytes, long index, long stringLength)
        {
            char[] chars = Encoding.UTF7.GetChars(bytes, Convert.ToInt32(index), Convert.ToInt32(stringLength));
            SetTranslation(new string(chars));
        }

        public override byte[] ToBytes()
        {
            List<byte> valueBytes = new List<byte>();
            foreach (char character in GetTranslation())
            {
                valueBytes.AddRange(BitConverter.GetBytes(character));
            }
            return valueBytes.ToArray();
        }


    }
}
