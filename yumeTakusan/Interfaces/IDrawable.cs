﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace yumeTakusan.Interfaces
{
    public interface IDrawable : IWorldExistense
    {
        SpriteEffects Effects { get; set; }
        Color Color { get; set; }
        Texture2D Texture { get; }

        void Draw(SpriteBatch spriteBatch, Camera.Camera camera, GameTime gameTime, float layerDepth);
    }
}
