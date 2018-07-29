using System;
using System.Collections.Generic;

namespace ts.translation.data.definitions.petroglyph.formats.dat.index
{
    class PGDatIndexTableHolder : IPGBinary
    {
        private List<PGDatIndexTableRecord> _indexTable;

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

        internal PGDatIndexTableHolder(byte[] bytes)
        {
            SetIndexTable(FromBytes(bytes));
        }

        private List<PGDatIndexTableRecord> FromBytes(byte[] bytes)
        {
            List<PGDatIndexTableRecord> indexTable = new List<PGDatIndexTableRecord>();
            for (int i = 0; i < bytes.Length; i += 3 * sizeof(UInt32))
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
    }
}
