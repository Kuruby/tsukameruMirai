using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using yumeTakusan.Interfaces;

namespace yumeTakusan
{
    class PhysicsComponent : IUpdatable
    {
        public PhysicsComponent(IMovable Controlled)
        {

        }

        IMovable controlled;

        public void Update(GameTime gameTime)
        {

        }
    }
}
