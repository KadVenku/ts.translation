using System.Collections.Generic;
using ts.translation.data.definitions.petroglyph.formats.dat.content;
using ts.translation.data.definitions.petroglyph.formats.dat.header;
using ts.translation.data.definitions.petroglyph.formats.dat.index;

namespace ts.translation.data.definitions.petroglyph.formats.dat
{
    internal class PGDatType : IPGBinary
    {
        private PGDatHeaderHolder _header;
        private PGDatIndexTableHolder _datIndexTable;
        private PGDatTableHolder _datTable;
        private string _language;

        internal PGDatHeaderHolder GetHeader()
        {
            return _header;
        }

        internal void SetHeader(PGDatHeaderHolder header)
        {
            _header = header;
        }

        internal PGDatIndexTableHolder GetIndexTable()
        {
            return _datIndexTable;
        }

        internal void SetIndexTable(PGDatIndexTableHolder datIndexTable)
        {
            _datIndexTable = datIndexTable;
        }

        internal PGDatTableHolder GetDataTable()
        {
            return _datTable;
        }

        internal void SetDataTable(PGDatTableHolder datTable)
        {
            _datTable = datTable;
        }

        internal string GetLanguage()
        {
            return _language;
        }

        internal void SetLanguage(string language)
        {
            _language = language;
        }

        internal PGDatType(string language, PGDatHeaderHolder header, PGDatIndexTableHolder datIndexTableholder, PGDatTableHolder datTableHolder)
        {
            SetLanguage(language);
            SetHeader(header);
            SetIndexTable(datIndexTableholder);
            SetDataTable(datTableHolder);
        }

        public byte[] ToBytes()
        {
            List<byte> datFileBytes = new List<byte>();
            datFileBytes.AddRange(GetHeader().ToBytes());
            datFileBytes.AddRange(GetIndexTable().ToBytes());
            datFileBytes.AddRange(GetDataTable().ToBytes());

            return datFileBytes.ToArray();
        }
    }
}
