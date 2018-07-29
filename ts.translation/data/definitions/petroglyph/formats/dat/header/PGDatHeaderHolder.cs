using System;

namespace ts.translation.data.definitions.petroglyph.formats.dat.header
{
    class PGDatHeaderHolder : IPGBinary
    {
        private uint _keyCount;

        internal uint GetKeyCount()
        {
            return _keyCount;
        }

        private void SetKeyCount(uint newKeyCount)
        {
            _keyCount = newKeyCount;
        }

        internal PGDatHeaderHolder()
        {
            SetKeyCount(0);
        }

        internal PGDatHeaderHolder(uint keyCount)
        {
            SetKeyCount(keyCount);
        }

        internal PGDatHeaderHolder(int keyCount)
        {
            SetKeyCount((uint) keyCount);
        }

        internal PGDatHeaderHolder(byte[] bytes)
        {
            SetKeyCount(BitConverter.ToUInt32(bytes, 0));
        }

        public byte[] ToBytes()
        {
            byte[] bytes = BitConverter.GetBytes(GetKeyCount());
            return bytes;
        }
    }
}
