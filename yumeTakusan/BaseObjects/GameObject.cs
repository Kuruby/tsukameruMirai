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

        SpriteEffects effects = SpriteEffects.None;

        public SpriteEffects Effects

        {
            get => effects;
            set
            {
                effects = value;
            }
        }

        Color color;

        public Color Color
        {
            get => color;
            set
            {
                color = value;
            }
        }

        Texture2D texture;

        public Texture2D Texture
        {
            get => texture;
        }

        public abstract void Draw(SpriteBatch spriteBatch, GameTime gameTime);

    }
}
