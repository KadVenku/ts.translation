using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using ts.translation.common.typedefs;
using ts.translation.common.util.generic;
using ts.translation.common.util.petroglyph;
using ts.translation.common.util.ts;
using ts.translation.data.definitions.petroglyph.formats.dat;
using ts.translation.data.definitions.serializable;
using ts.translation.data.helper.conversion.dat;
using ts.translation.data.holder.observables;

namespace ts.translation.data.holder.text
{
    internal class TextHolder
    {
        private Dictionary<string, Dictionary<PGLanguage, Translation>> _dataDictionary;
        private List<PGLanguage> _loadedLanguages;

        internal TextHolder(LocalisationData localisationData)
        {
            if (_dataDictionary == null)
            {
                _dataDictionary = new Dictionary<string, Dictionary<PGLanguage, Translation>>();
            }
            if (_loadedLanguages == null)
            {
                _loadedLanguages = new List<PGLanguage>();
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
                            AddLoadedLanguage(PGLanguageUtility.ToPGLanguage(translation.Language));
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
                        Dictionary<PGLanguage, Translation> dic = new Dictionary<PGLanguage, Translation>();
                        foreach (Translation translation in localisation.TranslationData.TranslationHolder)
                        {
                            AddLoadedLanguage(PGLanguageUtility.ToPGLanguage(translation.Language));
                            dic.Add(PGLanguageUtility.ToPGLanguage(translation.Language), translation);
                        }

                        _dataDictionary[localisation.Key] = dic;
                    }
                }
                else
                {
                    Dictionary<PGLanguage, Translation> dic = new Dictionary<PGLanguage, Translation>();
                    foreach (Translation translation in localisation.TranslationData.TranslationHolder)
                    {
                        AddLoadedLanguage(PGLanguageUtility.ToPGLanguage(translation.Language));
                        dic.Add(PGLanguageUtility.ToPGLanguage(translation.Language), translation);
                    }
                    _dataDictionary.Add(localisation.Key, dic);
                }
            }
        }

        private void AddLoadedLanguage(PGLanguage lang)
        {
            if (!_loadedLanguages.Contains(lang))
            {
                _loadedLanguages.Add(lang);
            }
        }

        internal void Merge(TextHolder dataToMerge)
        {
            if (dataToMerge?._dataDictionary == null)
            {
                return;
            }

            if (_dataDictionary == null)
            {
                _dataDictionary = dataToMerge._dataDictionary ?? new Dictionary<string, Dictionary<PGLanguage, Translation>>();
            }

            foreach (KeyValuePair<string, Dictionary<PGLanguage, Translation>> keyValuePair in dataToMerge._dataDictionary)
            {
                if (_dataDictionary.ContainsKey(keyValuePair.Key))
                {
                    foreach (KeyValuePair<PGLanguage, Translation> translation in keyValuePair.Value)
                    {
                        if (_dataDictionary[keyValuePair.Key].ContainsKey(translation.Key))
                        {
                            _dataDictionary[keyValuePair.Key][translation.Key] = translation.Value;
                        }
                        else
                        {
                            _dataDictionary[keyValuePair.Key].Add(translation.Key, translation.Value);
                        }
                    }
                }
                else
                {
                    _dataDictionary.Add(keyValuePair.Key, keyValuePair.Value);
                }
            }

        }

        internal LocalisationData ToLocalisationData()
        {
            LocalisationData localisationData = new LocalisationData();

            foreach (KeyValuePair<string, Dictionary<PGLanguage, Translation>> keyValuePair in _dataDictionary)
            {
                Localisation localisation = new Localisation {Key = keyValuePair.Key};
                foreach (KeyValuePair<PGLanguage, Translation> translation in keyValuePair.Value)
                {
                    localisation.TranslationData.TranslationHolder.Add(translation.Value);
                }
                localisationData.LocalisationHolder.Add(localisation);
            }

            return localisationData;
        }

        internal string GetText(string textKey, PGLanguage language = PGLanguage.ENGLISH)
        {
            string retString = $"MISSING: {textKey}";
            if (!_dataDictionary.ContainsKey(textKey)) return retString;
            if (_dataDictionary[textKey] == null) return retString;
            if (!_dataDictionary[textKey].ContainsKey(language)) return retString;
            if (_dataDictionary[textKey][language] == null) return retString;
            retString = _dataDictionary[textKey][language].Text;
            return retString;
        }

        internal void AddText(string textKey, string newText, PGLanguage language = PGLanguage.ENGLISH)
        {
            AddLoadedLanguage(language);
            if (_dataDictionary.ContainsKey(textKey))
            {
                UpdateText(textKey, newText, language);
            }
            Translation translation = new Translation {Language = PGLanguageUtility.ToString(language), Text = newText};
            AddLoadedLanguage(PGLanguageUtility.ToPGLanguage(translation.Language));
            _dataDictionary.Add(textKey, new Dictionary<PGLanguage, Translation> {{language, translation}});


        }

        internal void UpdateText(string textKey, string newText, PGLanguage language = PGLanguage.ENGLISH)
        {
            AddLoadedLanguage(language);
            if (!_dataDictionary.ContainsKey(textKey))
            {
                AddText(textKey, newText, language);
                return;
            }

            if (_dataDictionary[textKey] == null)
            {
                _dataDictionary[textKey] = new Dictionary<PGLanguage, Translation> {{language, new Translation {Language = PGLanguageUtility.ToString(language), Text = newText}}};
                return;
            }

            if (_dataDictionary[textKey].ContainsKey(language))
            {
                _dataDictionary[textKey][language] = new Translation {Language = PGLanguageUtility.ToString(language), Text = newText};
            }
            else
            {
                _dataDictionary[textKey].Add(language, new Translation { Language = PGLanguageUtility.ToString(language), Text = newText });
            }
        }

        internal PGDatType ToPGDatType(PGLanguage language = PGLanguage.ENGLISH)
        {
            List<TranslationHelper> tempExportTable = new List<TranslationHelper>();
            foreach (KeyValuePair<string, Dictionary<PGLanguage, Translation>> keyValuePair in _dataDictionary)
            {
                if (keyValuePair.Value == null || !keyValuePair.Value.ContainsKey(language) || keyValuePair.Value[language] == null) continue;
                TranslationHelper hlp = new TranslationHelper(keyValuePair.Key, Crc32Utility.Crc32(keyValuePair.Key), keyValuePair.Value[language].Text);
                tempExportTable.Add(hlp);
            }
            tempExportTable.Sort();
            return PGDatTypeUtility.Create(tempExportTable, language);
        }

        internal List<PGDatType> GetAllDatFiles()
        {
            return EnumUtility<PGLanguage>.GetValues().Select(ToPGDatType).ToList();
        }

        internal List<PGLanguage> GetLoadedLanguages()
        {
            return _loadedLanguages;
        }

        public ObservableCollection<ObservableTranslationData> ToObservableCollection(PGLanguage lang = PGLanguage.ENGLISH)
        {
            ObservableCollection<ObservableTranslationData> returnList = new ObservableCollection<ObservableTranslationData>();
            foreach (KeyValuePair<string, Dictionary<PGLanguage, Translation>> keyValuePair in _dataDictionary)
            {
                if (keyValuePair.Value == null) continue;
                if (!keyValuePair.Value.ContainsKey(lang)) continue;
                if (keyValuePair.Value[lang] == null) continue;
                returnList.Add(new ObservableTranslationData(keyValuePair.Key, keyValuePair.Value[lang].Text));
            }

            return returnList;
        }
    }
}
