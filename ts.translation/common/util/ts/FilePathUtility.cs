using System.IO;
using ts.translation.common.typedefs;
using ts.translation.common.util.petroglyph;

namespace ts.translation.common.util.ts
{
    internal static class FilePathUtility
    {
        private const string TEXT_FILE_BASE_NAME = "mastertextfile";
        private const string TEXT_FILE_FILE_TYPE = "dat";
        private const string TRANSLATION_MANIFEST_FILE_NAME = "TranslationManifest.xml";

        internal static bool FileExists(string filePath)
        {
            return File.Exists(filePath);
        }

        internal static string GetTranlsationFileName(PGLanguage lang)
        {
            return $"{TEXT_FILE_BASE_NAME}_{PGLanguageUtility.ToString(lang)}.{TEXT_FILE_FILE_TYPE}".ToLower();
        }

        public static string GetTranlsationFilePath(string path, PGLanguage lang)
        {
            return Path.Combine(path, GetTranlsationFileName(lang));
        }

        public static string GetTranlsationManifestFileName(string path)
        {
            return Path.Combine(path, TRANSLATION_MANIFEST_FILE_NAME);
        }

        public static string GetFileName(string path)
        {
            return Path.GetFileName(path);
        }
    }
}