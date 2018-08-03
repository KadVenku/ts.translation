using System.Collections.Generic;
using System.Xml.Serialization;

namespace ts.translation.data.definitions.serializable
{
    [XmlRoot(ElementName = "TranslationData")]
    public class TranslationData
    {
        [XmlElement(ElementName = "Translation")]
        public List<Translation> TranslationHolder { get; set; }

        public TranslationData()
        {
            if (TranslationHolder == null)
            {
                TranslationHolder = new List<Translation>();
            }
        }
    }
}