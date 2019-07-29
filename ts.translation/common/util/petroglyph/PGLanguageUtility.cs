using System;
using System.Linq;
using ts.translation.common.typedefs;
using ts.translation.common.util.ts;

namespace ts.translation.common.util.petroglyph
{
    internal static class PGLanguageUtility
    {
        internal static PGLanguage ToPGLanguage(string text)
        {
            return Enum.TryParse(text.ToUpper(), out PGLanguage pgLang) ? pgLang : PGLanguage.ENGLISH;
        }

        public static string ToString(PGLanguage language)
        {
            return language.ToString("G").ToUpper();
        }

        public static PGLanguage GetLanguageFromFileName(string fileName)
        {
            return EnumUtility<PGLanguage>.GetValues().FirstOrDefault(language => fileName.Equals(FilePathUtility.GetTranlsationFileName(language), StringComparison.InvariantCultureIgnoreCase));
        }
    }
}