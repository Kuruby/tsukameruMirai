using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Microsoft.Xna.Framework.Graphics;

namespace yumeTakusan.yumeUI
{
    /// <summary>
    /// UI Element as a node
    /// </summary>
    public class ElementNode
    {
        /// <summary>
        /// Creates a element node
        /// </summary>
        /// <param name="Style">Style to be applied to this element</param>
        /// <param name="type">The type of element node that it should be</param>
        public ElementNode(Style? Style = null, InternalNode InternalNode = null)
        {
            style = Style ?? new Style();
            internalNode = InternalNode;
        }

        /// <summary>
        /// creates an empty node
        /// </summary>
        private ElementNode()
        {
            style = new Style();
        }

        /// <summary>
        /// The node that is internally this element
        /// </summary>
        [XmlElement()]
        InternalNode internalNode;

        /// <summary>
        /// The type of node this is
        /// </summary>
        [XmlAttribute("type")]
        string nodeType => typeof(InternalNode).ToString();

        /// <summary>
        /// The nodes contained within this element
        /// </summary>
        [XmlElement("node")]
        public List<ElementNode> containedNodes = new List<ElementNode>();

        /// <summary>
        /// A single white pixel used for drawing UI
        /// </summary>
        [XmlIgnore]
        public static Texture2D pixel;

        /// <summary>
        /// Style of the element
        /// </summary>
        [XmlIgnore]
        Style style = new Style();

        /// <summary>
        /// String of the style for xmlification
        /// </summary>
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
