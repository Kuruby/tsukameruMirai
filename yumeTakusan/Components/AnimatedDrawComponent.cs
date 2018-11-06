using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using yumeTakusan.Camera;
using yumeTakusan.Interfaces;

namespace yumeTakusan.Components
{
    public class AnimatedDrawComponent
    {
        public AnimatedDrawComponent() : this(null)
        {

        }
        public AnimatedDrawComponent(IAnimatable DrawnObject)
        {
            drawnObject = DrawnObject;
        }

        IAnimatable drawnObject;

        public IAnimatable DrawnObject
        {
            set
            {
                drawnObject = value;
            }
        }

        public void UpdateFrameRectangle()
        {
            drawnObject.frameLocation = new Rectangle(drawnObject.horizontalFrameNumber * drawnObject.frameWidth,
                drawnObject.verticalFrameNumber * drawnObject.frameHeight,
                drawnObject.frameWidth, drawnObject.frameHeight);
        }

        public void Draw(SpriteBatch spriteBatch, Camera.Camera camera, GameTime gameTime, float layerDepth)
        {
            spriteBatch.Draw(drawnObject.Texture, drawnObject.Location-camera.Location, drawnObject.frameLocation, drawnObject.Color, 0f, Vector2.Zero, 1f, drawnObject.Effects, layerDepth);
        }

    }
}
