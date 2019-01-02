using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using yumeTakusan.Interfaces;

namespace yumeTakusan.Interfaces
{
    /// <summary>
    /// A object that is able to move
    /// </summary>
    public interface IMovable : IWorldExistence
    {
        /// <summary>
        /// How fast the object is moving and in what direction
        /// </summary>
        Vector2 Velocity { get; set; }
        /// <summary>
        /// X Component of velocity
        /// </summary>
        float VelocityXComponent { get; set; }
        /// <summary>
        /// Y Component of velocity
        /// </summary>
        float VelocityYComponent { get; set; }
        /// <summary>
        /// Change in acceleration wrt time
        /// </summary>
        Vector2 Acceleration { get; set; }
        /// <summary>
        /// X Component of acceleration
        /// </summary>
        float AccelerationXComponent { get; set; }
        /// <summary>
        /// Y Component of acceleration
        /// </summary>
        float AccelerationYComponent { get; set; }
    }
}
