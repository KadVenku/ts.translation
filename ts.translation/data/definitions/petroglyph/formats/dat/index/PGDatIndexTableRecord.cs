using System;
using System.Collections.Generic;

namespace ts.translation.data.definitions.petroglyph.formats.dat.index
{
    internal class PGDatIndexTableRecord : IPGBinary
    {
        private uint _crc32Checksum;
        private uint _keyStringLength;
        private uint _valueStringLength;

        internal uint GetCrc32Checksum()
        {
            return _crc32Checksum;
        }

        internal void SetCrc32Checksum(uint crc32Checksum)
        {
            _crc32Checksum = crc32Checksum;
        }

        internal uint GetKeyStringLength()
        {
            return _keyStringLength;
        }

        internal void SetKeyStringLength(uint keyStringLength)
        {
            _keyStringLength = keyStringLength;
        }

        internal uint GetValueStringLength()
        {
            return _valueStringLength;
        }

        internal void SetValueStringLength(uint valueStringLength)
        {
            _valueStringLength = valueStringLength;
        }

        internal PGDatIndexTableRecord()
        {
            SetCrc32Checksum(0);
            SetKeyStringLength(0);
            SetValueStringLength(0);
        }

        internal PGDatIndexTableRecord(byte[] bytes, long startingIndex)
        {
            SetCrc32Checksum(BitConverter.ToUInt32(bytes, Convert.ToInt32(startingIndex)));
            SetValueStringLength(BitConverter.ToUInt32(bytes, Convert.ToInt32(startingIndex) + sizeof(uint)));
            SetKeyStringLength(BitConverter.ToUInt32(bytes, Convert.ToInt32(startingIndex) + sizeof(uint) * 2));
        }

        internal PGDatIndexTableRecord(uint crc32Checksum, uint keyStringLength, uint valueStringLength)
        {
            SetCrc32Checksum(crc32Checksum);
            SetKeyStringLength(keyStringLength);
            SetValueStringLength(valueStringLength);
        }

        public byte[] ToBytes()
        {
            List<byte> index = new List<byte>();
            index.AddRange(BitConverter.GetBytes(GetCrc32Checksum()));
            index.AddRange(BitConverter.GetBytes(GetValueStringLength()));
            index.AddRange(BitConverter.GetBytes(GetKeyStringLength()));
            return index.ToArray();
        }
    }
}