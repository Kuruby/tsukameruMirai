using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using System.Xml.Serialization;
using System.IO;
using Microsoft.Xna.Framework.Graphics;

namespace yumeTakusan.yumeUI
{
    /// <summary>
    /// The root node for a UI structure
    /// </summary>
    [XmlRoot("root")]
    public class RootNode
    {
        /// <summary>
        /// The first node inside this one
        /// </summary>
        [XmlElement]
        public ElementNode node;

        /// <summary>
        /// Style for the root node
        /// </summary>
        [XmlAttribute("style")]
        private Style style = new Style(5, 0, 0, Positions._static);

        /// <summary>
        /// String of style for XML encoding
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

        /// <summary>
        /// Pixel for drawing
        /// </summary>
        [XmlIgnore]
        public static Texture2D pixel;

        /// <summary>
        /// creates and empty root node
        /// </summary>
        public RootNode()
        {
            node = new ElementNode(style);
        }

        /// <summary>
        /// Turns this UI structure into a string
        /// </summary>
        /// <returns>XML version of this UI structure</returns>
        public string Serialize()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(RootNode));
            StringWriter stringWriter = new StringWriter();
            xmlSerializer.Serialize(stringWriter, this);
            return stringWriter.ToString();
        }

        /// <summary>
        /// Gets a UI structure from XML string
        /// </summary>
        /// <param name="xml">XML as string</param>
        /// <returns>UI structure in the xml</returns>
        public static RootNode DeSerialize(string xml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(RootNode));
            return (RootNode)xmlSerializer.Deserialize(new MemoryStream(Encoding.Unicode.GetBytes("\ufeff" + xml)));
        }

        /// <summary>
        /// Draws this UI
        /// </summary>
        /// <param name="gameTime">Timing values</param>
        /// <param name="spriteBatch">Sprite batch to use for drawing</param>
        public void Draw(SpriteBatch spriteBatch)
        {
            Texture2D texture = node.Draw(spriteBatch);
            if (texture == null)
                return;
            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend, SamplerState.PointClamp);
            spriteBatch.Draw(texture, style.location, texture.Bounds, Color.White, 0f, Vector2.Zero, Vector2.One, SpriteEffects.None, 0f);
            spriteBatch.End();
        }
    }
}
