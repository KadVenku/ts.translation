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
        public void Write(string path, LocalisationData writable)
        {
            using (Utf8StringWriter stringWriter = new Utf8StringWriter())
            {
                using (stringWriter)
                {
                    using (XmlWriter xmlWriter = XmlWriter.Create(stringWriter))
                    {
                        path = FilePathUtility.GetTranlsationManifestFileName(path);
                        XmlSerializer serializer = new XmlSerializer(typeof(LocalisationData));
                        serializer.Serialize(xmlWriter, GlobalDataHolder.TextHolder.ToLocalisationData());
                        File.WriteAllText(path, XDocument.Parse(stringWriter.ToString()).ToString());
                    }
                }
            }
        }

        public void Dispose()
        {
        }

        private sealed class Utf8StringWriter : StringWriter
        {
            public override Encoding Encoding => Encoding.UTF8;
        }
    }
}