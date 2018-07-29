using System.IO;
using System.Xml.Serialization;
using ts.translation.common.exceptions;
using ts.translation.data.definitions.serializable;

namespace ts.translation.services.reader.serializable
{
    internal class TranslationManifestReader : IReader<LocalisationData>
    {
        private StreamReader _reader;
        private readonly XmlSerializer _xmlSerializer = new XmlSerializer(typeof(LocalisationData));
        public LocalisationData Read(string path)
        {
            _reader = new StreamReader(path);
            if (!(_xmlSerializer.Deserialize(_reader) is LocalisationData localisationData)) throw new TranslationManifestMalformedException();
            return localisationData;
        }

        public void Dispose()
        {
            _reader?.Close();
            _reader?.Dispose();
        }
    }
}