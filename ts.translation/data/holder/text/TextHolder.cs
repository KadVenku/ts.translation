using System.Collections.Generic;
using System.Xml.Serialization;
using ts.translation.common.typedefs;
using ts.translation.common.util;
using ts.translation.data.definitions.serializable;

namespace ts.translation.data.holder.text
{
    internal class TextHolder
    {
        //Dictionary: key = TEXT_KEY, value = LocalisationHolder
        private readonly Dictionary<string, Dictionary<PGLanguages, Translation>> _dataDictionary;

        internal TextHolder(LocalisationData localisationData)
        {
            if (_dataDictionary == null)
            {
                _dataDictionary = new Dictionary<string, Dictionary<PGLanguages, Translation>>();
            }
            Import(localisationData);
        }

        internal void Import(LocalisationData localisationData)
        {
            foreach (Localisation localisation in localisationData.LocalisationHolder)
            {
                if (_dataDictionary.ContainsKey(localisation.Key))
                {
                    if (_dataDictionary[localisation.Key] != null)
                    {
                        foreach (Translation translation in localisation.TranslationData.TranslationHolder)
                        {
                            if (!_dataDictionary[localisation.Key].ContainsKey(PGLanguageUtility.ToPGLanguage(translation.Language)))
                            {
                                _dataDictionary[localisation.Key].Add(PGLanguageUtility.ToPGLanguage(translation.Language), translation);
                            }
                            else
                            {
                                _dataDictionary[localisation.Key][PGLanguageUtility.ToPGLanguage(translation.Language)] = translation;
                            }
                        }
                    }
                    else
                    {
                        Dictionary<PGLanguages, Translation> dic = new Dictionary<PGLanguages, Translation>();
                        foreach (Translation translation in localisation.TranslationData.TranslationHolder)
                        {
                            dic.Add(PGLanguageUtility.ToPGLanguage(translation.Language), translation);
                        }

                        _dataDictionary[localisation.Key] = dic;
                    }
                }
                else
                {
                    Dictionary<PGLanguages, Translation> dic = new Dictionary<PGLanguages, Translation>();
                    foreach (Translation translation in localisation.TranslationData.TranslationHolder)
                    {
                        dic.Add(PGLanguageUtility.ToPGLanguage(translation.Language), translation);
                    }
                    _dataDictionary.Add(localisation.Key, dic);
                }
            }
        }
    }
}
