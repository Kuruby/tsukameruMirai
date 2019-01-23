using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using yumeTakusan.Interfaces;
using yumeTakusan.Extensions;
using Microsoft.Xna.Framework.Graphics;

namespace yumeTakusan.BaseObjects
{
    /// <summary>
    /// A game object implementing ICollidable as well as everything else in GameObject 
    /// (IDrawable, IWorldExistence, IMovable, IUpdatable)
    /// </summary>
    public abstract class CollideableGameObject : GameObject, ICollidable
    {
        /// <summary>
        /// Default Constructor for CollideableGameObject
        /// </summary>
        /// <param name="Texture">Texture to be displayed for the object</param>
        /// <param name="Hitbox">The hitbox of the object</param>
        /// <param name="Colour">Colour the object is displayed as.</param>
        /// <param name="Effects">How the object is flipped</param>
        /// <param name="Visible">Whether the object can be seen</param>
        /// <param name="Location">Where the object is</param>
        public CollideableGameObject(Texture2D Texture, Rectangle Hitbox, Color? Colour = null, SpriteEffects Effects = SpriteEffects.None,
            bool Visible = true, Vector2 Location = default(Vector2)) : base(Texture, Colour, Effects, Visible, Location)
        {
            hitbox = Hitbox;
        }


        /// <summary>
        /// A rectangle representing the space the object takes up
        /// </summary>
        protected Rectangle hitbox;


        /// <summary>
        /// The hitbox: A rectangle representing the space the object takes up
        /// </summary>
        public Rectangle Hitbox
        {
            get => hitbox;
            set { hitbox = value; recalculateWorldHitbox(); }
        }

        /// <summary>
        /// The space the object takes up in the 2D plane
        /// </summary>
        private Rectangle worldHitbox;

        /// <summary>
        /// The space the object takes up in the 2D plane
        /// </summary>
        public Rectangle WorldLocationHitbox => worldHitbox;


        /// <summary>
        /// Recalculates the world hitbox
        /// </summary>
        private void recalculateWorldHitbox()
        {
            worldHitbox = hitbox.RectangleAtPoint(Location);
        }

        /// <summary>
        /// Checks if this object is colliding with another one.
        /// </summary>
        /// <param name="otherObject">Object to check collision with</param>
        /// <returns>Whether the objects collide</returns>
        public bool CheckCollision(ICollidable otherObject) =>
            WorldLocationHitbox.Intersects(otherObject.WorldLocationHitbox);

        /// <summary>
        /// Checks if the other object is within this one.
        /// </summary>
        /// <param name="otherObject">Object to check collision with</param>
        /// <returns>Whether the other object is within this</returns>
        public bool ObjectWithin(ICollidable otherObject) =>
            WorldLocationHitbox.Contains(otherObject.WorldLocationHitbox);

        /// <summary>
        /// Checks if this object is inside the other one.
        /// </summary>
        /// <param name="otherObject">Object to check collision with</param>
        /// <returns>Whether this object is within the other one</returns>
        public bool WithinObject(ICollidable otherObject) =>
            otherObject.Hitbox.Contains(WorldLocationHitbox);


        /// <summary>
        /// Where this object exists.
        /// </summary>
        new public Vector2 Location
        {
            get => location;
            set { location = value; recalculateWorldHitbox(); }
        }

        /// <summary>
        /// The X component of the location vector
        /// </summary>
        new public float LocationXComponent
        {
            get => location.X;
            set { location.X = value; recalculateWorldHitbox(); }
        }

        /// <summary>
        /// the Y component of the location vector
        /// </summary>
        new public float LocationYComponent
        {
            get => location.Y;
            set { location.Y = value; recalculateWorldHitbox(); }
        }

    }
}
