using System;
using ts.translation.data.definitions.petroglyph.formats.dat.content.record.key;
using ts.translation.data.definitions.petroglyph.formats.dat.content.record.value;

namespace ts.translation.data.definitions.petroglyph.formats.dat.content.record
{
    internal class PGDatTableRecord
    {
        private DatKeyRecordHolder _datKey;
        private DatValueRecordHolder _datValue;

        internal DatKeyRecordHolder GetKey()
        {
            return _datKey;
        }

        internal void SetKey(DatKeyRecordHolder datKey)
        {
            _datKey = datKey;
        }

        internal DatValueRecordHolder GetValue()
        {
            return _datValue;
        }

        internal void SetValue(DatValueRecordHolder datValue)
        {
            _datValue = datValue;
        }

        internal PGDatTableRecord()
        {
            SetKey(new DatKeyRecordHolder($"TEXT_GENERATED_{Guid.NewGuid()}"));
            SetValue(new DatValueRecordHolder($"MISSING: {GetKey().GetStringKey()}"));
        }

        internal PGDatTableRecord(string key, string value)
        {
            SetKey(new DatKeyRecordHolder(key));
            SetValue(new DatValueRecordHolder(value));
        }

        internal PGDatTableRecord(byte[] bytes, long keyIndex, long keyLength, long valueIndex, long valueLength)
        {
            SetKey(new DatKeyRecordHolder(bytes, keyIndex, keyLength));
            SetValue(new DatValueRecordHolder(bytes, valueIndex, valueLength));
        }
    }
}