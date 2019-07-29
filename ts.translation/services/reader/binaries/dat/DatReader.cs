using System;
using System.IO;
using ts.translation.common.typedefs;
using ts.translation.common.util.petroglyph;
using ts.translation.common.util.ts;
using ts.translation.data.definitions.petroglyph.formats.dat;

namespace ts.translation.services.reader.binaries.dat
{
    internal class DatReader : IReader<PGDatType>
    {
        public PGDatType Read(string path)
        {
            if (path == null)
            {
                throw new ArgumentNullException(nameof(path));
            }

            if (!FilePathUtility.FileExists(path))
            {
                throw new ArgumentException($"File {path} doesn't exist.");
            }

            PGLanguage lang = PGLanguageUtility.GetLanguageFromFileName(FilePathUtility.GetFileName(path));
            byte[] byteStream = File.ReadAllBytes(path);
            PGDatType datType = new PGDatType(byteStream);
            datType.SetLanguage(PGLanguageUtility.ToString(lang));
            return datType;
        }

        public void Dispose()
        {
        }
    }
}