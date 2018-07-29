using System.IO;
using ts.translation.common.util.petroglyph;
using ts.translation.common.util.ts;
using ts.translation.data.definitions.petroglyph.formats.dat;

namespace ts.translation.services.writer.binaries.dat
{
    internal class DatWriter : IWriter<PGDatType>
    {
        public void Dispose()
        {
        }

        public void Write(string path, PGDatType writable)
        {
            if (FilePathUtility.FileExists(FilePathUtility.GetTranlsationFilePath(path, PGLanguageUtility.ToPGLanguage(writable.GetLanguage()))))
            {
                File.Delete(FilePathUtility.GetTranlsationFilePath(path, PGLanguageUtility.ToPGLanguage(writable.GetLanguage())));
            }

            using (BinaryWriter writer = new BinaryWriter(File.Open(FilePathUtility.GetTranlsationFilePath(path, PGLanguageUtility.ToPGLanguage(writable.GetLanguage())), FileMode.Create)))
            {
                writer.Write(writable.ToBytes());
            }
        }
    }
}
