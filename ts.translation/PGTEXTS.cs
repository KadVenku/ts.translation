﻿using System;
using System.Collections.Generic;
using ts.translation.common.data;
using ts.translation.common.exceptions;
using ts.translation.common.typedefs;
using ts.translation.common.util.ts;
using ts.translation.services.holder;

namespace ts.translation
{
    /// <summary>
    /// Static Text Provider for Petroglyph *.DAT files.
    /// </summary>
    public static class PGTEXTS
    {
        /// <summary>
        /// Sets the text for a given text key for the default language.
        /// </summary>
        /// <param name="textKey">The text key.</param>
        /// <param name="newText">The new text.</param>
        /// <param name="language">The language.</param>
        /// <exception cref="TextHolderNotInitilaisedException"></exception>
        public static void SetText(string textKey, string newText, PGLanguage language = PGLanguage.ENGLISH)
        {
            if (GlobalDataHolder.TextHolder == null) throw new TextHolderNotInitilaisedException();
            GlobalDataHolder.TextHolder.UpdateText(textKey, newText, language);
        }

        /// <summary>
        /// Adds a new translation identified by a text key for the default language.
        /// </summary>
        /// <param name="textKey">The text key.</param>
        /// <param name="newText">The new text.</param>
        /// <param name="language">The language.</param>
        /// <exception cref="TextHolderNotInitilaisedException"></exception>
        public static void AddText(string textKey, string newText, PGLanguage language = PGLanguage.ENGLISH)
        {
            if (GlobalDataHolder.TextHolder == null) throw new TextHolderNotInitilaisedException();
            GlobalDataHolder.TextHolder.AddText(textKey, newText, language);
        }

        /// <summary>
        /// Gets the text for a given key in the given language.
        /// </summary>
        /// <param name="textKey">The text key.</param>
        /// <param name="language">The language.</param>
        /// <returns></returns>
        public static string GetText(string textKey, PGLanguage language = PGLanguage.ENGLISH)
        {
            return GlobalDataHolder.TextHolder == null ? $"MISSING: {textKey}" : GlobalDataHolder.TextHolder.GetText(textKey, language);
        }

        /// <summary>
        /// Loads from file.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <param name="fileType">Type of the file.</param>
        /// <exception cref="ArgumentOutOfRangeException">fileType - null</exception>
        public static void LoadFromFile(string filePath, TSFileTypes fileType = TSFileTypes.FileTypeXml)
        {
            switch (fileType)
            {
                case TSFileTypes.FileTypeXml:
                    TextHolderProcessService.LoadFromXml(filePath);
                    break;
                case TSFileTypes.FileTypeDat:
                    TextHolderProcessService.LoadFromDat(filePath);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(fileType), fileType, null);
            }
        }


        /// <summary>
        /// Saves to file.
        /// </summary>
        /// <param name="filePath">The file path: Path to the directory to save the file to. The file name is auto-generated.</param>
        /// <param name="fileType">Type of the file.</param>
        public static void SaveToFile(string filePath, TSFileTypes fileType = TSFileTypes.FileTypeXml)
        {
            switch (fileType)
            {
                case TSFileTypes.FileTypeXml:
                    TextHolderProcessService.SaveToXmlFile(filePath);
                    break;
                case TSFileTypes.FileTypeDat:
                    TextHolderProcessService.SaveToDatFile(filePath);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(fileType), fileType, null);
            }
        }

        public static IEnumerable<PGLanguage> GetLoadedLanguages()
        {
            return GlobalDataHolder.TextHolder?.GetLoadedLanguages();
        }

        public static IEnumerable<PGLanguage> GetAvailableLanguages()
        {
            return EnumUtility<PGLanguage>.GetValues();
        }
    }
}
