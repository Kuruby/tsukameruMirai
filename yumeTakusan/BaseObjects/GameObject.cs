using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using yumeTakusan.Interfaces;
using yumeTakusan.YumeCamera;

namespace yumeTakusan.BaseObjects
{
    /// <summary>
    /// IWorldExistence, IMovable
    /// </summary>
    public abstract class GameObject : GameProp, Interfaces.IDrawable
    {
        public GameObject(Texture2D Texture, Color? Colour = null, SpriteEffects Effects = SpriteEffects.None,
            bool Visible = true, Vector2 Location = default(Vector2)) : base(Location)
        {
            texture = Texture;
            color = Colour ?? Color.White;
            effects = Effects;
            visible = Visible;
        }

        public bool visible = true;

        private SpriteEffects effects = SpriteEffects.None;

        public SpriteEffects Effects

        {
            get => effects;
            set
            {
                effects = value;
            }
        }

        private Color color;

        public Color Color
        {
            get => color;
            set
            {
                color = value;
            }
        }

        private Texture2D texture;

        public Texture2D Texture
        {
            get => texture;
        }

        //TODO: Add two extra arguments
        public abstract void Draw(SpriteBatch spriteBatch, Camera camera, GameTime gameTime, float layerDepth);

    }
}
