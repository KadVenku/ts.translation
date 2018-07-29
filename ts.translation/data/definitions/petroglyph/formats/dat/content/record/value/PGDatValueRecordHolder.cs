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

        internal DatValueRecordHolder(byte[] bytes, uint index, uint stringLength)
        {
            byte[] tempArray = CutArray(bytes, index, index + stringLength);
            SetTranslation(Encoding.UTF7.GetString(tempArray));
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
