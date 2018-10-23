using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using yumeTakusan.Interfaces;

namespace yumeTakusan.BaseObjects
{
    public abstract class GameProp:Interfaces.IWorldExistence,IMovable,IUpdatable
    {


        private Vector2 location = Vector2.Zero;

        public Vector2 Location
        {
            get => location;
            set { location = value; }
        }

        public float LocationXComponent
        {
            get => location.X;
            set { location.X = value; }
        }

        public float LocationYComponent
        {
            get => location.Y;
            set { location.Y = value; }
        }


        private Vector2 velocity = Vector2.Zero;

        public Vector2 Velocity
        {
            get => velocity;
            set { velocity = value; }
        }

        public float VelocityXComponent
        {
            get => velocity.X;
            set { velocity.X = value; }
        }

        public float VelocityYComponent
        {
            get => velocity.Y;
            set { velocity.Y = value; }
        }


        private Vector2 acceleration = Vector2.Zero;

        public Vector2 Acceleration
        {
            get => acceleration;
            set { acceleration = value; }
        }

        public float AccelerationXComponent
        {
            get => acceleration.X;
            set { acceleration.X = value; }
        }

        public float AccelerationYComponent
        {
            get => acceleration.Y;
            set { acceleration.Y = value; }
        }


        public abstract void Update(GameTime gameTime);
    }
}
