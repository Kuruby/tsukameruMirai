using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using yumeTakusan.BaseObjects;
using yumeTakusan.Components;
using yumeTakusan.Camera;

namespace tsukameruCore
{
    class Player : CollideableGameObject
    {

        public Player(Texture2D Texture, Rectangle Hitbox, Color? Colour = null, SpriteEffects Effects = SpriteEffects.None,
            bool Visible = true, Vector2 Location = default(Vector2)) : base(Texture,Hitbox,Colour,Effects,Visible,Location)
        {
            drawComponent = new DrawComponent(this);
            physicsComponent = new PhysicsComponent(this);
        }

        DrawComponent drawComponent;
        PhysicsComponent physicsComponent;
        

        public override void Update(GameTime gameTime)
        {
            physicsComponent.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch,Camera camera, GameTime gameTime,float layerDepth)
        {
            drawComponent.Draw(spriteBatch,camera, gameTime,layerDepth);
        }
    }
}
