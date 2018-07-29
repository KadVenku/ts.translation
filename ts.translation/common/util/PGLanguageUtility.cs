using System;
using ts.translation.common.typedefs;

namespace ts.translation.common.util
{
    internal static class PGLanguageUtility
    {
        internal static PGLanguages ToPGLanguage(string text)
        {
            return Enum.TryParse(text.ToUpper(), out PGLanguages pgLang) ? pgLang : PGLanguages.ENGLISH;
        }
    }
}
