using System;
using System.Text;

namespace ts.translation.data.definitions.petroglyph.formats.dat.content.record.value
{
    internal class DatValueRecordHolder : APGDatTableRecordHolder
    {
        private string _translation;
        internal static readonly Encoding ENCODING = Encoding.Unicode;

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
            char[] chars = ENCODING.GetChars(bytes, Convert.ToInt32(index), Convert.ToInt32(stringLength * 2));
            string finalString = new string(chars);
            finalString = finalString.Replace("\0", string.Empty);
            SetTranslation(finalString);
        }

        public override byte[] ToBytes()
        {
            return ENCODING.GetBytes(GetTranslation());
        }
    }
}