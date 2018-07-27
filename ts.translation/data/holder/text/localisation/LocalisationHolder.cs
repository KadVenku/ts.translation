using System.Collections.Generic;
using ts.translation.data.definitions.serializable;
using ts.translation.data.holder.text.translation;

namespace ts.translation.data.holder.text.localisation
{
    internal class LocalisationHolder
    {
        // Dictionary: key = Localisation, value = TranslationHolder
        private readonly Dictionary<Localisation, TranslationHolder> _dataDictionary;

        internal LocalisationHolder()
        {
            if (_dataDictionary == null)
            {
                _dataDictionary = new Dictionary<Localisation, TranslationHolder>();
            }
        }
    }
}
