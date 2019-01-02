using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using yumeTakusan.Interfaces;
using yumeTakusan.YumeCamera;

namespace yumeTakusan.Components
{
    /// <summary>
    /// Draws a static image for an object
    /// </summary>
    public class DrawComponent
    {
        /// <summary>
        /// Creates a draw component drawing nothing
        /// </summary>
        public DrawComponent() : this(null) { }

        /// <summary>
        /// Creates a draw component to draw the specified objects
        /// </summary>
        /// <param name="DrawnObject"></param>
        public DrawComponent(Interfaces.IDrawable DrawnObject)
        {
            drawnObject = DrawnObject;
        }

        /// <summary>
        /// The object that is drawn
        /// </summary>
        Interfaces.IDrawable drawnObject;

        /// <summary>
        /// The object that is drawn
        /// </summary>
        public Interfaces.IDrawable DrawnObject
        {
            set
            {
                drawnObject = value;
            }
        }

        /// <summary>
        /// Draws the object to screen
        /// </summary>
        /// <param name="spriteBatch">The spritebatch to be used for drawing.</param>
        /// <param name="camera">The camera that represents how the object and world is viewed.</param>
        /// <param name="gameTime">Timing Values</param>
        /// <param name="layerDepth">How deep on screen the object is to be drawn</param>
        public void Draw(SpriteBatch spriteBatch, Camera camera, GameTime gameTime, float layerDepth)
        {
            spriteBatch.Draw(drawnObject.Texture, drawnObject.Location-camera.Location, null, drawnObject.Color, 0f, Vector2.Zero, 1f, drawnObject.Effects, layerDepth);
        }
    }
}
