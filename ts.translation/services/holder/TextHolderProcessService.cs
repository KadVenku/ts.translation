using ts.translation.common.data;
using ts.translation.common.util.petroglyph;
using ts.translation.data.definitions.petroglyph.formats.dat;
using ts.translation.data.definitions.serializable.v1;
using ts.translation.data.holder.text;
using ts.translation.services.reader.binaries.dat;
using ts.translation.services.reader.serializable;
using ts.translation.services.writer.binaries.dat;
using ts.translation.services.writer.serializable;

namespace ts.translation.services.holder
{
    internal static class TextHolderProcessService
    {
        internal static void LoadFromXmlFileV1(string filePath)
        {
            LocalisationData data;
            using (TranslationManifestReaderV1 svc = new TranslationManifestReaderV1())
            {
                data = svc.Read(filePath);
            }

            if (data == null)
            {
                return;
            }

            if (GlobalDataHolder.TextHolder == null)
            {
                GlobalDataHolder.TextHolder = new TextHolder(data);
            }
            else
            {
                GlobalDataHolder.TextHolder.Merge(new TextHolder(data));
            }
        }

        internal static void LoadFromDat(string filePath)
        {
            LocalisationData data;
            using (DatReader svc = new DatReader())
            {
                data = PGDatTypeUtility.Convert(svc.Read(filePath));
            }

            if (data == null)
            {
                return;
            }

            if (GlobalDataHolder.TextHolder == null)
            {
                GlobalDataHolder.TextHolder = new TextHolder(data);
            }
            else
            {
                GlobalDataHolder.TextHolder.Merge(new TextHolder(data));
            }
        }

        internal static void SaveToXmlFileV1(string filePath)
        {
            using (TranslationManifestWriter svc = new TranslationManifestWriter())
            {
                if (GlobalDataHolder.TextHolder == null)
                {
                    return;
                }

                svc.Write(filePath, GlobalDataHolder.TextHolder.ToLocalisationData());
            }
        }

        internal static void SaveToDatFile(string filePath)
        {
            foreach (PGDatType datFile in GlobalDataHolder.TextHolder.GetAllDatFiles())
            {
                if (datFile.GetHeader().GetKeyCount() < 1)
                {
                    continue;
                }
                using (DatWriter writer = new DatWriter())
                {
                    writer.Write(filePath, datFile);
                }
            }
        }
    }
}