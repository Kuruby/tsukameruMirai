using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using yumeTakusan.Interfaces;

namespace yumeTakusan.Components
{
    public class PhysicsComponent : IUpdatable
    {
        public PhysicsComponent() : this(null) { }

        public PhysicsComponent(IMovable Controlled)
        {
            controlled = Controlled;
        }

        IMovable controlled;

        public IMovable Controlled
        {
            set
            {
                controlled = value;
            }
        }

        public void Update(GameTime gameTime)
        {
            controlled.Velocity += controlled.Acceleration;
            controlled.Location += controlled.Velocity;

            controlled.Acceleration = Vector2.Zero;
        }
    }
}
