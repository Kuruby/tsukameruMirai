using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace yumeTakusan.Interfaces
{
    /// <summary>
    /// A collidable object
    /// </summary>
    public interface ICollidable
    {
        /// <summary>
        /// The location relative to the position of the object where it is
        /// </summary>
        Rectangle Hitbox { get; set; }
        /// <summary>
        /// The absolute location of the hitbox in world coordinates
        /// </summary>
        Rectangle WorldLocationHitbox { get; }
        /// <summary>
        /// Checks if this object is colliding with another object
        /// </summary>
        /// <param name="otherObject">Object to check collision with</param>
        /// <returns>Whether the objects collide</returns>
        bool CheckCollision(ICollidable otherObject);
        /// <summary>
        /// Checks if this object is inside another object
        /// </summary>
        /// <param name="otherObject">Object to check containment with</param>
        /// <returns>Whether this object is within the other object</returns>
        bool WithinObject(ICollidable otherObject);
        /// <summary>
        /// Checks if another object is inside this object
        /// </summary>
        /// <param name="otherObject">Object to check containment with</param>
        /// <returns>Whether the other object is inside this object</returns>
        bool ObjectWithin(ICollidable otherObject);
    }
}
