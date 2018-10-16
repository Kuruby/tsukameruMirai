using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using System.Xml.Serialization;
using System.IO;

namespace yumeUI
{
    [XmlRoot("root")]
    class RootNode
    {
        [XmlElement]
        public ElementNode node;

        private Style style;

        [XmlAttribute("style")]
        public string styleString
        {
            get
            {
                return style.ToString();
            }
            set
            {
                style = style.FromString(value);
            }
        }

        public RootNode()
        {
            node = new ElementNode();
            style = default(Style);
            style.padding = 5;
            style.mainColor = Color.Cyan;
        }

        public string Serialize()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(RootNode));
            StringWriter stringWriter = new StringWriter();
            xmlSerializer.Serialize(stringWriter, this);
            return stringWriter.ToString();
        }

        public static RootNode DeSerialize(string xml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(RootNode));
            return (RootNode)xmlSerializer.Deserialize(new MemoryStream(Encoding.Unicode.GetBytes("\ufeff" + xml)));
        }
    }
}
