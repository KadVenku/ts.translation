using System;
using System.Collections.Generic;
using ts.translation.data.definitions.petroglyph.formats.dat.header;

namespace ts.translation.data.definitions.petroglyph.formats.dat.index
{
    class PGDatIndexTableHolder : IPGBinary
    {
        private List<PGDatIndexTableRecord> _indexTable;
        private const long STRUCT_SIZE = sizeof(uint) * 3;
        private const long STARTING_INDEX = sizeof(uint);

        internal List<PGDatIndexTableRecord> GetIndexTable()
        {
            return _indexTable;
        }

        private void SetIndexTable(List<PGDatIndexTableRecord> indexTable)
        {
            _indexTable = indexTable;
        }

        internal PGDatIndexTableHolder()
        {
            SetIndexTable(new List<PGDatIndexTableRecord>());
        }

        internal PGDatIndexTableHolder(List<PGDatIndexTableRecord> indexTable)
        {
            SetIndexTable(indexTable);
        }

        internal PGDatIndexTableHolder(byte[] bytes, PGDatHeaderHolder header)
        {
            SetIndexTable(FromBytes(bytes, header.GetKeyCount()));
        }

        private List<PGDatIndexTableRecord> FromBytes(byte[] bytes, uint keyCount)
        {
            List<PGDatIndexTableRecord> indexTable = new List<PGDatIndexTableRecord>();
            long lKeyCount = keyCount;
            long endIndex = STARTING_INDEX + lKeyCount * STRUCT_SIZE;
            for (long i = sizeof(uint); i < endIndex; i += STRUCT_SIZE)
            {
                indexTable.Add(new PGDatIndexTableRecord(bytes, i));
            }
            return indexTable;
        }

        public byte[] ToBytes()
        {
            List<byte> indexTable = new List<byte>();
            foreach (PGDatIndexTableRecord indexTableRecord in GetIndexTable())
            {
                indexTable.AddRange(indexTableRecord.ToBytes());
            }
            return indexTable.ToArray();
        }

        public long GetStructSize()
        {
            return STRUCT_SIZE;
        }
    }
}
