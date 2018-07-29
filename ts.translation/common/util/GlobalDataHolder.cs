using ts.translation.data.definitions.serializable;
using ts.translation.data.holder.text;

namespace ts.translation.common.util
{
    internal static class GlobalDataHolder
    {
        private static LocalisationData _localisationDataHolder;

        internal static void SetLocalisationData(LocalisationData data)
        {
            _localisationDataHolder = data;
        }

        internal static LocalisationData GetLocalisationData()
        {
            return _localisationDataHolder;
        }

        internal static TextHolder TextHolder { get; set; }
    }
}
