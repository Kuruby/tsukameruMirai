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
    public class DrawComponent
    {
        public DrawComponent() : this(null)
        {

        }
        public DrawComponent(Interfaces.IDrawable DrawnObject)
        {
            drawnObject = DrawnObject;
        }

        Interfaces.IDrawable drawnObject;

        public Interfaces.IDrawable DrawnObject
        {
            set
            {
                drawnObject = value;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Camera camera, GameTime gameTime, float layerDepth)
        {
            spriteBatch.Draw(drawnObject.Texture, drawnObject.Location-camera.Location, null, drawnObject.Color, 0f, Vector2.Zero, 1f, drawnObject.Effects, layerDepth);
        }
    }
}
