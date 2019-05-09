using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

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
        readonly InternalNode internalNode;

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

        public Texture2D Draw(SpriteBatch spriteBatch)
        {
            List<Texture2D> internalElementRenders = new List<Texture2D>();
            //Generate textures from the contained nodes
            foreach (ElementNode node in containedNodes)
            {
                Texture2D texture = node.Draw(spriteBatch);
                if (texture != null)
                {
                    internalElementRenders.Add(texture);
                }
            }


            if (internalNode == null)
            {
                int renderedHeight = 1;
                int renderedWidth = 1;
                //Estimate the final rendered size
                if (internalElementRenders.Count != 0)
                {
                    renderedHeight = internalElementRenders.Sum(tex => tex.Bounds.Height) + style.InnerExtra;
                    renderedWidth = internalElementRenders.Max(tex => tex.Bounds.Width) + style.InnerExtra;
                }
                else
                {
                    if (style.InnerExtra == 0)
                    {
                        return null;
                    }
                    renderedHeight = style.InnerExtra;
                    renderedWidth = style.InnerExtra;
                }
                RenderTargetManager.createAndSetTarget(renderedWidth, renderedHeight);
                //draw the textures directly from the contained nodes
                spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend, SamplerState.PointClamp);
                //Create the offsets
                int leftOffset = 0;
                int topOffset = 0;
                int rightOffset = 0;
                int bottomOffset = 0;
                Rectangle offsetRectangle() => new Rectangle(leftOffset, topOffset, renderedWidth - rightOffset, renderedHeight - bottomOffset);
                //Draw border
                spriteBatch.Draw(pixel, offsetRectangle(), null, style.borderColor, 0f, Vector2.Zero, SpriteEffects.None, 1f);
                leftOffset += style.border;
                topOffset += style.border;
                rightOffset += style.border;
                bottomOffset += style.border;
                //draw background
                spriteBatch.Draw(pixel, offsetRectangle(), null, style.backgroundColor, 0f, Vector2.Zero, SpriteEffects.None, .999f);

                spriteBatch.End();
                return RenderTargetManager.PopRenderTarget();
            }
            else
            {
                //If there is a internal node have it draw the contained nodes
                return internalNode.Draw(spriteBatch, new Texture2D[] { });
            }

        }
    }
}
