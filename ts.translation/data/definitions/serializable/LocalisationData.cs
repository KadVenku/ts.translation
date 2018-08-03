using System.Collections.Generic;
using System.Xml.Serialization;

namespace ts.translation.data.definitions.serializable
{
    [XmlRoot(ElementName = "LocalisationData")]
    public class LocalisationData
    {
        [XmlElement(ElementName = "Localisation")]
        public List<Localisation> LocalisationHolder { get; set; }

        public LocalisationData()
        {
            if (LocalisationHolder == null)
            {
                LocalisationHolder = new List<Localisation>();
            }
        }
    }
}
