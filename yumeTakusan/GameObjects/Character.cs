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
using yumeTakusan.Interfaces;

namespace yumeTakusan.GameObjects
{
    /// <summary>
    /// Represents a character of some sort in the game (Player, NPC, enemy.)
    /// </summary>
    public class Character : CollideableGameObject, IDisposalFlag, IKillable
    {

        /// <summary>
        /// Creates a character
        /// </summary>
        /// <param name="Texture">Texture to be displayed for the object</param>
        /// <param name="Hitbox">The hitbox of the object</param>
        /// <param name="Colour">Colour the object is displayed as.</param>
        /// <param name="Effects">How the object is flipped</param>
        /// <param name="Visible">Whether the object can be seen</param>
        /// <param name="Location">Where the object is</param>
        public Character(Texture2D Texture, Rectangle Hitbox, ControlComponent control, Color? Colour = null, SpriteEffects Effects = SpriteEffects.None,
            bool Visible = true, Vector2 Location = default) : base(Texture, Hitbox, Colour, Effects, Visible, Location)
        {
            drawComponent = new DrawComponent(this);
            physicsComponent = new PhysicsComponent(this);
            controlComponent = control;
            controlComponent.controlled = this;

        }

        /// <summary>
        /// Component to draw the character
        /// </summary>
        readonly DrawComponent drawComponent;
        /// <summary>
        /// Component to perform physics calculations on the character
        /// </summary>
        readonly PhysicsComponent physicsComponent;
        /// <summary>
        /// Component controlling movement and ai for the character
        /// </summary>
        readonly ControlComponent controlComponent;

        /// <summary>
        /// updates the character
        /// </summary>
        /// <param name="gameTime">Timing values</param>
        public override void Update(GameTime gameTime)
        {
            controlComponent.Update(gameTime);
            physicsComponent.Update(gameTime);
        }

        /// <summary>
        /// Happens when the character dies
        /// </summary>
        public void Die()
        {
            disposed = true;
        }

        /// <summary>
        /// Whether or not the character is to be disposed
        /// </summary>
        public bool disposed { get; protected set; }

        /// <summary>
        /// Draws the character
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
