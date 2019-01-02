using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using yumeTakusan.YumeCamera;
using yumeTakusan.Interfaces;

namespace yumeTakusan.Components
{
    /// <summary>
    /// Draws an animated sprite for an object
    /// </summary>
    public class AnimatedDrawComponent
    {
        /// <summary>
        /// Empty constructor, creates an animateddrawcomponent that draws nothing
        /// </summary>
        public AnimatedDrawComponent() : this(null) { }
        /// <summary>
        /// Creates and AnimatedDrawComponent drawing the specified object
        /// </summary>
        /// <param name="DrawnObject">Object to draw</param>
        public AnimatedDrawComponent(IAnimatable DrawnObject)
        {
            drawnObject = DrawnObject;
        }

        /// <summary>
        /// Drawn object
        /// </summary>
        IAnimatable drawnObject;

        /// <summary>
        /// The object that this component draws
        /// </summary>
        public IAnimatable DrawnObject
        {
            set
            {
                drawnObject = value;
            }
        }

        /// <summary>
        /// Recalculates the location on the spritesheet that the frame is
        /// </summary>
        public void UpdateFrameRectangle()
        {
            drawnObject.frameLocation = new Rectangle(drawnObject.horizontalFrameNumber * drawnObject.frameWidth,
                drawnObject.verticalFrameNumber * drawnObject.frameHeight,
                drawnObject.frameWidth, drawnObject.frameHeight);
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
            spriteBatch.Draw(drawnObject.Texture, drawnObject.Location-camera.Location, drawnObject.frameLocation, drawnObject.Color, 0f, Vector2.Zero, 1f, drawnObject.Effects, layerDepth);
        }

    }
}
