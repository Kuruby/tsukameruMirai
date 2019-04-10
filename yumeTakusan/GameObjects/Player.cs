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
using yumeTakusan.Input.Patching;

namespace yumeTakusan.GameObjects
{
    /// <summary>
    /// Represents a game player
    /// </summary>
    class Player : CollideableGameObject
    {
        /// <summary>
        /// Creates a player
        /// </summary>
        /// <param name="Texture">Texture to be displayed for the object</param>
        /// <param name="Hitbox">The hitbox of the object</param>
        /// <param name="Colour">Colour the object is displayed as.</param>
        /// <param name="Effects">How the object is flipped</param>
        /// <param name="Visible">Whether the object can be seen</param>
        /// <param name="Location">Where the object is</param>
        public Player(Texture2D Texture, Rectangle Hitbox, MasterInput input = null, Color? Colour = null, SpriteEffects Effects = SpriteEffects.None,
            bool Visible = true, Vector2 Location = default(Vector2)) : base(Texture, Hitbox, Colour, Effects, Visible, Location)
        {
            drawComponent = new DrawComponent(this);
            physicsComponent = new PhysicsComponent(this);
            if (input != null)
                controlComponent = new DesktopInputController(this, input);
        }

        /// <summary>
        /// Component to draw the player
        /// </summary>
        DrawComponent drawComponent;
        /// <summary>
        /// Component to perform physics calculations on the player
        /// </summary>
        PhysicsComponent physicsComponent;
        /// <summary>
        /// Component controlling the player
        /// </summary>
        ControlComponent controlComponent;

        /// <summary>
        /// updates the player and position thereof
        /// </summary>
        /// <param name="gameTime">Timing values</param>
        public override void Update(GameTime gameTime)
        {
            controlComponent.Update(gameTime);
            physicsComponent.Update(gameTime);
        }

        /// <summary>
        /// Draws the player
        /// </summary>
        /// <param name="spriteBatch">The spritebatch to be used for drawing.</param>
        /// <param name="camera">The camera that represents how the object and world is viewed.</param>
        /// <param name="gameTime">Timing Values</param>
        /// <param name="layerDepth">How deep on screen the object is to be drawn</param>
        public override void Draw(SpriteBatch spriteBatch, Camera camera, GameTime gameTime, float layerDepth)
        {
            drawComponent.Draw(spriteBatch, camera, gameTime, layerDepth);
        }
    }
}
