using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using yumeTakusan.YumeCamera;

namespace yumeTakusan.Interfaces
{
    /// <summary>
    /// Represents a drawable object
    /// </summary>
    public interface IDrawable : IWorldExistence
    {
        /// <summary>
        /// Spriteeffects applied to the object when drawn
        /// </summary>
        SpriteEffects Effects { get; set; }
        /// <summary>
        /// The colour the object is drawn
        /// </summary>
        Color Color { get; set; }
        /// <summary>
        /// The texture to draw for the object
        /// </summary>
        Texture2D Texture { get; }

        /// <summary>
        /// Draws the object to screen
        /// </summary>
        /// <param name="spriteBatch">The spritebatch to be used for drawing.</param>
        /// <param name="camera">The camera that represents how the object and world is viewed.</param>
        /// <param name="gameTime">Timing Values</param>
        /// <param name="layerDepth">How deep on screen the object is to be drawn</param>
        void Draw(SpriteBatch spriteBatch, Camera camera, GameTime gameTime, float layerDepth);
    }
}
