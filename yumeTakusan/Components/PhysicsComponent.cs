using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using yumeTakusan.Interfaces;

namespace yumeTakusan.Components
{
    /// <summary>
    /// Performs physics operations on the controlled component
    /// </summary>
    public class PhysicsComponent : IUpdatable
    {
        /// <summary>
        /// Create a physics component controlling nothing
        /// </summary>
        public PhysicsComponent() : this(null) { }

        /// <summary>
        /// Creates a physics component controlling the object
        /// </summary>
        /// <param name="Controlled">Object to be controlled</param>
        public PhysicsComponent(IMovable Controlled)
        {
            controlled = Controlled;
        }

        /// <summary>
        /// Controlled Object
        /// </summary>
        IMovable controlled;

        /// <summary>
        /// Controlled Object
        /// </summary>
        public IMovable Controlled
        {
            set
            {
                controlled = value;
            }
        }

        /// <summary>
        /// Performs physics calculations to update the object
        /// </summary>
        /// <param name="gameTime">Timing values</param>
        public void Update(GameTime gameTime)
        {
            controlled.Velocity += controlled.Acceleration;
            controlled.Location += controlled.Velocity;

            controlled.Acceleration = Vector2.Zero;
        }
    }
}
