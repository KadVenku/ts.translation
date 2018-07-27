using System.Collections.Generic;
using ts.translation.data.definitions.serializable;
using ts.translation.data.holder.text.localisation;

namespace ts.translation.data.holder.text
{
    internal class TextHolder
    {
        //Dictionary: key = TEXT_KEY, value = LocalisationHolder
        private readonly Dictionary<string, LocalisationHolder> _dataDictionary;
        private LocalisationData _localisationData;

        internal TextHolder(LocalisationData localisationData)
        {
            _localisationData = localisationData;
            if (_dataDictionary == null)
            {
                _dataDictionary = new Dictionary<string, LocalisationHolder>();
            }
        }
    }
}
