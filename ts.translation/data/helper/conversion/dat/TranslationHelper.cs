using System;

namespace ts.translation.data.helper.conversion.dat
{
    class TranslationHelper : IComparable
    {
        internal string Key { get; }
        internal uint Crc32 { get; }
        internal string Value { get; }

        internal TranslationHelper(string key, uint crc32, string value)
        {
            Key = key.Replace("\0", string.Empty);
            Crc32 = crc32;
            Value = value.Replace("\0", string.Empty);
        }
        public int CompareTo(object obj)
        {
            switch (obj)
            {
                case null:
                    return 1;
                case TranslationHelper otherTranslation:
                    return Crc32.CompareTo(otherTranslation.Crc32);
                default:
                    throw new ArgumentException($"{obj.GetType()} is not {typeof(TranslationHelper)}");
            }
        }
    }
}
