using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yumeTakusan.Interfaces;
using yumeTakusan.Extensions;
using Microsoft.Xna.Framework;

namespace yumeTakusan.BaseObjects
{
    /// <summary>
    /// A Zone defines a region of space in the 2D game plane.
    /// </summary>
    public abstract class Zone : GameProp, ICollidable
    {
        /// <summary>
        /// Default Constructor for a Zone
        /// </summary>
        /// <param name="Hitbox">The rectangle that defines how large the zone is</param>
        /// <param name="Location">Where the zone is in the world</param>
        public Zone(Rectangle Hitbox, Vector2 Location = default(Vector2)) : base(Location)
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
            set { hitbox = value; RecalculateWorldHitbox(); }
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
        private void RecalculateWorldHitbox()
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
            set { location = value; RecalculateWorldHitbox(); }
        }

        /// <summary>
        /// The X component of the location vector
        /// </summary>
        new public float LocationXComponent
        {
            get => location.X;
            set { location.X = value; RecalculateWorldHitbox(); }
        }

        /// <summary>
        /// the Y component of the location vector
        /// </summary>
        new public float LocationYComponent
        {
            get => location.Y;
            set { location.Y = value; RecalculateWorldHitbox(); }
        }
    }
}
