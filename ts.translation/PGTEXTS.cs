using ts.translation.common.typedefs;

namespace ts.translation
{
    public static class PGTEXTS
    {
        /// <summary>
        /// Sets the text for a given text key for the default language.
        /// </summary>
        /// <param name="textKey">The text key.</param>
        /// <param name="newText">The new text.</param>
        public static void SetText(string textKey, string newText)
        {

        }

        /// <summary>
        /// Sets the text for a given text key for the given language.
        /// </summary>
        /// <param name="textKey">The text key.</param>
        /// <param name="language">The language.</param>
        /// <param name="newText">The new text.</param>
        public static void SetText(string textKey, PGLanguages language, string newText)
        {

        }

        /// <summary>
        /// Adds a new translation identified by a text key for the default language.
        /// </summary>
        /// <param name="textKey">The text key.</param>
        /// <param name="newText">The new text.</param>
        public static void AddText(string textKey, string newText)
        {

        }

        /// <summary>
        /// Adds a new translation identified by a text key for the given language.
        /// </summary>
        /// <param name="textKey">The text key.</param>
        /// <param name="language">The language.</param>
        /// <param name="newText">The new text.</param>
        public static void AddText(string textKey, PGLanguages language, string newText)
        {

        }

        /// <summary>
        /// Gets the text for a given key in the default language.
        /// </summary>
        /// <param name="textKey">The text key.</param>
        /// <returns></returns>
        public static string GetText(string textKey)
        {
            return "";
        }

        /// <summary>
        /// Gets the text for a given key in the given language.
        /// </summary>
        /// <param name="textKey">The text key.</param>
        /// <param name="language">The language.</param>
        /// <returns></returns>
        public static string GetText(string textKey, PGLanguages language)
        {
            return "";
        }

        /// <summary>
        /// Loads from file.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <param name="fileType">Type of the file.</param>
        public static void LoadFromFile(string filePath, TSFileTypes fileType)
        {

        }

        /// <summary>
        /// Saves to file.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <param name="fileType">Type of the file.</param>
        public static void SaveToFile(string filePath, TSFileTypes fileType)
        {

        }
    }
}
