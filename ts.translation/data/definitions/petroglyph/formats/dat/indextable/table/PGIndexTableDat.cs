using System;
using System.Collections.Generic;
using System.Text;
using ts.translation.data.definitions.petroglyph.formats.dat.indextable.record;
using ts.translation.data.definitions.petroglyph.pgchecksum;

namespace ts.translation.data.definitions.petroglyph.formats.dat.indextable.table
{
    internal class PGIndexTableDat
    {
        private List<PGIndexTableRecordDat> IndexTable { get; }

        internal PGIndexTableDat()
        {
            IndexTable = new List<PGIndexTableRecordDat>();
        }

        internal PGIndexTableDat(byte[] stream, uint itemCount)
        {
            IndexTable = ReadFromByteStream(stream, itemCount);
        }

        private static List<PGIndexTableRecordDat> ReadFromByteStream(byte[] stream, uint itemCount)
        {
            List<PGIndexTableRecordDat> indexTable = new List<PGIndexTableRecordDat>();
            const int bytesToSkip = sizeof(uint);
            uint indexTableSizeInBytes = itemCount * bytesToSkip * 3;
            int readObjectCount = 1;
            for(int i = bytesToSkip; i < indexTableSizeInBytes; indexTableSizeInBytes += bytesToSkip)
            {
                readObjectCount++;
                PGCheckSum32 crc32 = new PGCheckSum32(BitConverter.ToUInt32(stream, i));
                i += bytesToSkip;
                uint valueStringLenght = BitConverter.ToUInt32(stream, i);
                i += bytesToSkip;
                uint keyStringLength = BitConverter.ToUInt32(stream, i);

                indexTable.Add(new PGIndexTableRecordDat(crc32, valueStringLenght, keyStringLength));
            }

            return indexTable;
        }

        internal byte[] ToBytes()
        {
            List<byte> indexByteList = new List<byte>();
            foreach (PGIndexTableRecordDat indexRecord in IndexTable)
            {
                indexByteList.AddRange(indexRecord.ToBytes());
            }
            return indexByteList.ToArray();
        }
    }
}
