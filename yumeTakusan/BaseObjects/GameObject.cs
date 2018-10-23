using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using yumeTakusan.Interfaces;

namespace yumeTakusan.BaseObjects
{
    /// <summary>
    /// IWorldExistence, IMovable
    /// </summary>
    public abstract class GameObject : GameProp, Interfaces.IDrawable
    {
        public bool visible = true;

        public abstract void Draw(SpriteBatch spriteBatch, GameTime gameTime);

    }
}
