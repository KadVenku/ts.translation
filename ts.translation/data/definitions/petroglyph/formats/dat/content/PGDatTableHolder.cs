using System.Collections.Generic;
using ts.translation.data.definitions.petroglyph.formats.dat.content.record;
using ts.translation.data.definitions.petroglyph.formats.dat.header;
using ts.translation.data.definitions.petroglyph.formats.dat.index;

namespace ts.translation.data.definitions.petroglyph.formats.dat.content
{
    internal class PGDatTableHolder : IPGBinary
    {
        private List<PGDatTableRecord> _dataTable = new List<PGDatTableRecord>();
        private const long STRUCT_SIZE = sizeof(char);

        internal List<PGDatTableRecord> GetDataTable()
        {
            return _dataTable;
        }

        internal void SetDataTable(List<PGDatTableRecord> dataTable)
        {
            _dataTable = dataTable;
        }

        internal PGDatTableHolder()
        {
            if (GetDataTable() == null)
            {
                SetDataTable(new List<PGDatTableRecord>());
            }
        }

        internal PGDatTableHolder(byte[] byteStream, PGDatHeaderHolder datHeaderHolder, PGDatIndexTableHolder indexTableHolder)
        {
            //start: value table     = Header       + Size of the index table
            long startingIndexValues = sizeof(uint) + datHeaderHolder.GetKeyCount() * indexTableHolder.GetStructSize();
            //start: key table     = start: value table  + size of value table.
            long startingIndexKeys = startingIndexValues + GetValueTableSize(indexTableHolder);
            for (int i = 0; i < datHeaderHolder.GetKeyCount(); i++)
            {
                GetDataTable().Add(new PGDatTableRecord(byteStream, startingIndexKeys, indexTableHolder.GetIndexTable()[i].GetKeyStringLength(), startingIndexValues, indexTableHolder.GetIndexTable()[i].GetValueStringLength()));
                startingIndexKeys = startingIndexKeys + indexTableHolder.GetIndexTable()[i].GetKeyStringLength();
                startingIndexValues = startingIndexValues + STRUCT_SIZE * indexTableHolder.GetIndexTable()[i].GetValueStringLength();
            }
        }

        private static long GetValueTableSize(PGDatIndexTableHolder indexTableHolder)
        {
            long size = 0L;
            foreach (PGDatIndexTableRecord datIndexTableRecord in indexTableHolder.GetIndexTable())
            {
                size = size + datIndexTableRecord.GetValueStringLength() * STRUCT_SIZE;
            }

            return size;
        }

        public byte[] ToBytes()
        {
            List<byte> tempKeyByteStream = new List<byte>();
            List<byte> tempValueByteStream = new List<byte>();
            foreach (PGDatTableRecord dataTableRecord in GetDataTable())
            {
                tempKeyByteStream.AddRange(dataTableRecord.GetKey().ToBytes());
                tempValueByteStream.AddRange(dataTableRecord.GetValue().ToBytes());
            }
            List<byte> dataTableBytes = new List<byte>();
            dataTableBytes.AddRange(tempValueByteStream);
            dataTableBytes.AddRange(tempKeyByteStream);
            return dataTableBytes.ToArray();
        }
    }
}