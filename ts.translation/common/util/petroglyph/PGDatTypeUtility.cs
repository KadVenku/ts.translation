using System.Collections.Generic;
using ts.translation.common.typedefs;
using ts.translation.data.definitions.petroglyph.formats.dat;
using ts.translation.data.definitions.petroglyph.formats.dat.content;
using ts.translation.data.definitions.petroglyph.formats.dat.content.record;
using ts.translation.data.definitions.petroglyph.formats.dat.header;
using ts.translation.data.definitions.petroglyph.formats.dat.index;
using ts.translation.data.definitions.serializable.v1;
using ts.translation.data.helper.conversion.dat;

namespace ts.translation.common.util.petroglyph
{
    internal static class PGDatTypeUtility
    {
        internal static PGDatType Create(List<TranslationHelper> translationHelperTable, PGLanguage language = PGLanguage.ENGLISH)
        {
            PGDatHeaderHolder headerHolder = new PGDatHeaderHolder(translationHelperTable.Count);
            PGDatIndexTableHolder indexTableHolder = new PGDatIndexTableHolder();
            PGDatTableHolder datTableHolder = new PGDatTableHolder();
            foreach (TranslationHelper translationHelper in translationHelperTable)
            {
                indexTableHolder.GetIndexTable().Add(new PGDatIndexTableRecord(translationHelper.Crc32, (uint)translationHelper.Key.Length, (uint)translationHelper.Value.Length));
                datTableHolder.GetDataTable().Add(new PGDatTableRecord(translationHelper.Key, translationHelper.Value));
            }
            return new PGDatType(PGLanguageUtility.ToString(language), headerHolder, indexTableHolder, datTableHolder);
        }

        internal static LocalisationData Convert(PGDatType datType)
        {
            LocalisationData data = new LocalisationData();
            foreach (PGDatTableRecord record in datType.GetDataTable().GetDataTable())
            {
                Translation trans = new Translation { Language = datType.GetLanguage(), Text = record.GetValue().GetTranslation() };
                Localisation loc = new Localisation { Key = record.GetKey().GetStringKey(), TranslationData = new TranslationData() };
                loc.TranslationData.TranslationHolder.Add(trans);
                data.LocalisationHolder.Add(loc);
            }
            return data;
        }
    }
}