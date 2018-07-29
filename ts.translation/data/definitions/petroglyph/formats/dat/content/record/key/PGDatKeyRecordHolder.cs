using System;
using System.Collections.Generic;
using System.Text;

namespace ts.translation.data.definitions.petroglyph.formats.dat.content.record.key
{
    internal class DatKeyRecordHolder : APGDatTableRecordHolder
    {
        private string _stringKey;

        internal string GetStringKey()
        {
            return _stringKey;
        }

        internal void SetStringKey(string stringKey)
        {
            _stringKey = stringKey;
        }

        internal DatKeyRecordHolder(string stringKey)
        {
            SetStringKey(stringKey);
        }

        internal DatKeyRecordHolder(byte[] bytes, uint index, uint keyLength)
        {
            byte[] tempArray = CutArray(bytes, index, index + keyLength);
            SetStringKey(Encoding.ASCII.GetString(tempArray));
        }

        public override byte[] ToBytes()
        {
            List<byte> stringKeyBytes = new List<byte>();
            foreach (char character in GetStringKey())
            {
                stringKeyBytes.Add(BitConverter.GetBytes(character)[0]);
            }
            return stringKeyBytes.ToArray();
        }
    }
}
