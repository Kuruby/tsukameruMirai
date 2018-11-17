using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Microsoft.Xna.Framework.Graphics;

namespace yumeTakusan.yumeUI
{
    public class ElementNode
    {
        public ElementNode(Style? Style = null, NodeType type = NodeType.node)
        {
            nodeType = type;
            style = Style ?? new Style();
        }

        private ElementNode()
        {
            style = new Style(0, 0, null, null, null);
        }

        [XmlAttribute("type")]
        NodeType nodeType = NodeType.node;

        [XmlElement("node")]
        public List<ElementNode> containedNodes = new List<ElementNode>();

        [XmlIgnore]
        public static Texture2D pixel;

        Style style = new Style();

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
    }
}
