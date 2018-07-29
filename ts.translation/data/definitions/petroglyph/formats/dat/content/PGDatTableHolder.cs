using System.Collections.Generic;
using ts.translation.data.definitions.petroglyph.formats.dat.content.record;

namespace ts.translation.data.definitions.petroglyph.formats.dat.content
{
    class PGDatTableHolder : IPGBinary
    {
        private List<PGDatTableRecord> _dataTable = new List<PGDatTableRecord>();

        internal IEnumerable<PGDatTableRecord> GetDataTable()
        {
            return _dataTable;
        }

        internal void SetDataTable(List<PGDatTableRecord> dataTable)
        {
            _dataTable = dataTable;
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
