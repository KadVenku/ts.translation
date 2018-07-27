using System.Collections.Generic;
using ts.translation.common.typedefs;
using ts.translation.data.definitions.serializable;

namespace ts.translation.data.holder.text.translation
{
    internal class TranslationHolder
    {
        // Dictionary key = language; value = content.
        private readonly Dictionary<PGLanguages, Translation> _dataDictionary;

        internal TranslationHolder()
        {
            if (_dataDictionary == null)
            {
                _dataDictionary = new Dictionary<PGLanguages, Translation>();
            }
        }
    }
}
