using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace yumeTakusan.Interfaces
{
    /// <summary>
    /// IWorldExistence provides an interface that guarantees that an object will be able to exist in the world.
    /// </summary>
    public interface IWorldExistence
    {
        /// <summary>
        /// The location at which the object exists in the plane
        /// </summary>
        Vector2 Location { get; set; }
        /// <summary>
        /// The X Component of the location of the object
        /// </summary>
        float LocationXComponent { get; set; }
        /// <summary>
        /// The Y Component of the location of the object
        /// </summary>
        float LocationYComponent { get; set; }
    }
}
