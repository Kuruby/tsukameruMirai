using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace yumeTakusan.yumeUI
{
    /// <summary>
    /// Represents an internal node of an element
    /// </summary>
    public abstract class InternalNode
    {
        abstract internal Texture2D Draw(SpriteBatch spriteBatch, Texture2D[] internalRenderedElements);
    }
}
