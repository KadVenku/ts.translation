using System.Xml.Serialization;

namespace ts.translation.data.definitions.serializable.v1
{
    [XmlRoot(ElementName = "LocalisationHolder")]
    public class Localisation
    {
        [XmlElement(ElementName = "TranslationData")]
        public TranslationData TranslationData { get; set; }

        [XmlAttribute(AttributeName = "Key")]
        public string Key { get; set; }

        public Localisation()
        {
            if (TranslationData == null)
            {
                TranslationData = new TranslationData();
            }
        }
    }
}