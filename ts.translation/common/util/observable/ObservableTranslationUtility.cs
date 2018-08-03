using System.Collections.ObjectModel;
using ts.translation.common.data;
using ts.translation.common.typedefs;
using ts.translation.data.holder.observables;

namespace ts.translation.common.util.observable
{
    public static class ObservableTranslationUtility
    {
        public static ObservableCollection<ObservableTranslationData> GetTranslationDataAsObservable(PGLanguage lang = PGLanguage.ENGLISH)
        {
            return GlobalDataHolder.TextHolder.ToObservableCollection(lang);
        }
        public static void InitTranslationDataAsObservable(ObservableCollection<ObservableTranslationData> dataToUpdate, PGLanguage lang = PGLanguage.ENGLISH)
        {
            ObservableCollection<ObservableTranslationData> newData = GetTranslationDataAsObservable(lang);
            foreach (ObservableTranslationData observableTranslationData in newData)
            {
                dataToUpdate.Add(observableTranslationData);
            }
        }
    }
}
