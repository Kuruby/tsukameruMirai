using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using yumeTakusan.BaseObjects;
using yumeTakusan.Components;
using yumeTakusan.YumeCamera;
using yumeTakusan.Components.Controllers;

namespace yumeTakusan.GameObjects
{
    class Player : CollideableGameObject
    {

        public Player(Texture2D Texture, Rectangle Hitbox, Color? Colour = null, SpriteEffects Effects = SpriteEffects.None,
            bool Visible = true, Vector2 Location = default(Vector2)) : base(Texture, Hitbox, Colour, Effects, Visible, Location)
        {
            drawComponent = new DrawComponent(this);
            physicsComponent = new PhysicsComponent(this);
            controlComponent = new DesktopInputController(this);
        }

        DrawComponent drawComponent;
        PhysicsComponent physicsComponent;
        ControlComponent controlComponent;


        public override void Update(GameTime gameTime)
        {
            controlComponent.Update(gameTime);
            physicsComponent.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch, Camera camera, GameTime gameTime, float layerDepth)
        {
            drawComponent.Draw(spriteBatch, camera, gameTime, layerDepth);
        }
    }
}
