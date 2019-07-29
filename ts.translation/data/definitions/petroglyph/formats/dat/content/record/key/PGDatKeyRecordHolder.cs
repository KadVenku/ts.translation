using System;
using System.Text;

namespace ts.translation.data.definitions.petroglyph.formats.dat.content.record.key
{
    internal class DatKeyRecordHolder : APGDatTableRecordHolder
    {
        private string _stringKey;
        internal readonly Encoding ENCODING = Encoding.ASCII;

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

        internal DatKeyRecordHolder(byte[] bytes, long index, long keyLength)
        {
            char[] chars = ENCODING.GetChars(bytes, Convert.ToInt32(index), Convert.ToInt32(keyLength));
            SetStringKey(new string(chars));
        }

        public override byte[] ToBytes()
        {
            return ENCODING.GetBytes(GetStringKey());
        }
    }
}