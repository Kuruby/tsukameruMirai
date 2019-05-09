using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yumeTakusan.Interfaces;
using Microsoft.Xna.Framework;

namespace yumeTakusan.Components
{
    /// <summary>
    /// A component that controls movement for an object
    /// </summary>
    public abstract class ControlComponent
    {
        /// <summary>
        /// Creates a component controlling nothing
        /// </summary>
        public ControlComponent() : this(null) { }

        /// <summary>
        /// Creates a componennt controlling the object
        /// </summary>
        /// <param name="controlledObject">The object to be controlled</param>
        public ControlComponent(IMovable controlledObject)
        {
            controlled = controlledObject;
        }

        /// <summary>
        /// Move the object a certain amount
        /// </summary>
        /// <param name="dx">X movement</param>
        /// <param name="dy">Y movement</param>
        protected void applyMovementChange(float dx, float dy)
        {
            //maybe factor in a delta time?
            controlled.VelocityXComponent += dx;
            controlled.VelocityYComponent += dy;
        }

        /// <summary>
        /// The object that is controller
        /// </summary>
        public IMovable controlled { protected get; set; }

        /// <summary>
        /// Update method
        /// </summary>
        /// <param name="gameTime">Timing values</param>
        public abstract void Update(GameTime gameTime);
    }
}
