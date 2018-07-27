using System;
using System.Xml;
using System.Xml.Serialization;

namespace ts.translation.data.definitions.serializable
{

    [XmlRoot(ElementName = "TranslationHolder")]
    public class Translation
    {
        [XmlAttribute(AttributeName = "Language")]
        public string Language { get; set; }
        [XmlIgnore]
        public string Text { get; set; }
        [XmlText]
        public XmlNode[] CDataContent
        {
            get
            {
                XmlDocument dummy = new XmlDocument();
                return new XmlNode[] { dummy.CreateCDataSection(Text) };
            }
            set
            {
                if (value == null)
                {
                    Text = "[MISSING]";
                    return;
                }

                if (value.Length != 1)
                {
                    throw new InvalidOperationException($"Invalid array length {value.Length}");
                }

                Text = value[0].Value;
            }
        }
    }
}
