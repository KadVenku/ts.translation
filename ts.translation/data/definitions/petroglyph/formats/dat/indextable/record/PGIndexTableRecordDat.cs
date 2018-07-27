using System;
using System.Collections.Generic;
using ts.translation.data.definitions.petroglyph.pgchecksum;

namespace ts.translation.data.definitions.petroglyph.formats.dat.indextable.record
{
    class PGIndexTableRecordDat
    {
        private uint Crc32 { get; }
        private uint ValueStringLength { get; }
        private uint KeyStringLength { get; }

        public PGIndexTableRecordDat(PGCheckSum32 crc32, uint valueStringLenght, uint keyStringLength)
        {
            Crc32 = crc32.Checksum;
            KeyStringLength = keyStringLength;
            ValueStringLength = valueStringLenght;
        }

        internal PGIndexTableRecordDat(byte[] stream, int index)
        {
            Crc32 = BitConverter.ToUInt32(stream, index);
            KeyStringLength = BitConverter.ToUInt32(stream, index + sizeof(uint));
            ValueStringLength = BitConverter.ToUInt32(stream, index + sizeof(uint) * 2);

        }

        public byte[] ToBytes()
        {
            List<byte> indexTable = new List<byte>();
            indexTable.AddRange(BitConverter.GetBytes(Crc32));
            indexTable.AddRange(BitConverter.GetBytes(ValueStringLength));
            indexTable.AddRange(BitConverter.GetBytes(KeyStringLength));
            return indexTable.ToArray();
        }
    }
}
