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
    /// Class representing a drawn game object.
    /// Interfaces: 
    /// IWorldExistence, IMovable, IUpdatable.
    /// </summary>
    public abstract class GameObject : GameProp, Interfaces.IDrawable
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="Texture">Texture drawn for object</param>
        /// <param name="Colour">Colour that object is drawn</param>
        /// <param name="Effects">"effects" is actually "how it is flipped"</param>
        /// <param name="Visible">Whether or not it is drawn/visible</param>
        /// <param name="Location">Where the object is in the 2D game plane.</param>
        public GameObject(Texture2D Texture, Color? Colour = null, SpriteEffects Effects = SpriteEffects.None,
            bool Visible = true, Vector2 Location = default(Vector2)) : base(Location)
        {
            texture = Texture;
            color = Colour ?? Color.White;
            effects = Effects;
            visible = Visible;
        }

        /// <summary>
        /// Whether or not it is visible
        /// </summary>
        public bool visible = true;

        /// <summary>
        /// the spriteeffects or flipping applied to it
        /// </summary>
        private SpriteEffects effects = SpriteEffects.None;

        /// <summary>
        /// the spriteeffects or flipping applied to it
        /// </summary>
        public SpriteEffects Effects

        {
            get => effects;
            set
            {
                effects = value;
            }
        }

        /// <summary>
        /// The colour it is drawn
        /// </summary>
        private Color color;

        /// <summary>
        /// The colour it is drawn
        /// </summary>
        public Color Color
        {
            get => color;
            set
            {
                color = value;
            }
        }

        /// <summary>
        /// The texture, or the sprite that is drawn as the object
        /// </summary>
        private Texture2D texture;

        /// <summary>
        /// The texture, or the sprite that is drawn as the object
        /// </summary>
        public Texture2D Texture
        {
            get => texture;
        }

        //TODO: Add two extra arguments
        /// <summary>
        /// Draw the object to the screen
        /// </summary>
        /// <param name="spriteBatch">The spritebatch to be used for drawing.</param>
        /// <param name="camera">The camera that represents how the object and world is viewed.</param>
        /// <param name="gameTime">Timing Values</param>
        /// <param name="layerDepth">How deep on screen the object is to be drawn</param>
        public abstract void Draw(SpriteBatch spriteBatch, Camera camera, GameTime gameTime, float layerDepth);

    }
}
