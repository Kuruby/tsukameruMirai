using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yumeTakusan.Interfaces;
using Microsoft.Xna.Framework;

namespace yumeTakusan.Components
{
    public abstract class ControlComponent
    {
        public ControlComponent() : this(null) { }

        public ControlComponent(IMovable controlledObject)
        {
            controlled = controlledObject;
        }

        protected void applyMovementChange(float dx, float dy)
        {
            //maybe factor in a delta time?
            controlled.VelocityXComponent += dx;
            controlled.VelocityYComponent += dy;
        }

        protected IMovable controlled;

        public abstract void Update(GameTime gameTime);
    }
}
