using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using ts.translation.common.data;
using ts.translation.common.util.ts;
using ts.translation.data.definitions.serializable;

namespace ts.translation.services.writer.serializable
{
    public class TranslationManifestWriter : IWriter<LocalisationData>
    {
        private static readonly Utf8StringWriter STRINGWRITER = new Utf8StringWriter();
        private readonly XmlWriter _xmlWriter = XmlWriter.Create(STRINGWRITER);
        public void Write(string path, LocalisationData writable)
        {
            path = FilePathUtility.GetTranlsationManifestFileName(path);
            XmlSerializer serializer = new XmlSerializer(typeof(LocalisationData));
            serializer.Serialize(_xmlWriter, GlobalDataHolder.TextHolder.ToLocalisationData());
            File.WriteAllText(path, XDocument.Parse(STRINGWRITER.ToString()).ToString());
        }

        public void Dispose()
        {
            STRINGWRITER?.Close();
            STRINGWRITER?.Dispose();
            _xmlWriter?.Close();
            _xmlWriter?.Dispose();
        }

        private sealed class Utf8StringWriter : StringWriter
        {
            public override Encoding Encoding => Encoding.UTF8;
        }
    }
}