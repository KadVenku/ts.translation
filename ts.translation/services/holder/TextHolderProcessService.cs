using ts.translation.common.util;
using ts.translation.data.definitions.serializable;
using ts.translation.data.holder.text;
using ts.translation.services.reader.serializable;

namespace ts.translation.services.holder
{
    internal static class TextHolderProcessService
    {
        internal static void LoadFromXml(string filePath)
        {
            LocalisationData data;
            using (TranslationManifestReaderService readerService = new TranslationManifestReaderService())
            {
                data = readerService.Read(filePath);
            }

            if (data == null) return;
            if (GlobalDataHolder.TextHolder== null)
            {
                GlobalDataHolder.TextHolder = new TextHolder(data);
            }
            else
            {
                GlobalDataHolder.TextHolder.Import(data);
            }
        }
    }
}