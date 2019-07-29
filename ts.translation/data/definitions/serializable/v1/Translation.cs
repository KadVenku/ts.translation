using System;
using System.Security;
using System.Xml;
using System.Xml.Serialization;
using ts.translation.common.util.generic;

namespace ts.translation.data.definitions.serializable.v1
{
    [XmlRoot(ElementName = "TranslationHolder")]
    public class Translation
    {
        private string _text;

        [XmlAttribute(AttributeName = "Language")]
        public string Language { get; set; }

        [XmlIgnore]
        public string Text
        {
            get => _text;
            set => _text = StringUtility.Validate(value);
        }

        [XmlText]
        public XmlNode[] CDataContent
        {
            get
            {
                XmlDocument dummy = new XmlDocument();
                return new XmlNode[] { dummy.CreateCDataSection(XmlUtility.EscapeXml(Text)) };
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
                SecurityElement s = new SecurityElement("a", value[0].Value);
                Text = XmlUtility.UnescapeXml(s.Text);
            }
        }
    }
}