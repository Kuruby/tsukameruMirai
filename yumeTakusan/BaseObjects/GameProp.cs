using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using yumeTakusan.Interfaces;

namespace yumeTakusan.BaseObjects
{
    /// <summary>
    /// A game prop, which is a invisible part of the game
    /// </summary>
    public abstract class GameProp : IWorldExistence, IMovable, IUpdatable
    {
        /// <summary>
        /// Constructor for a game prop
        /// </summary>
        /// <param name="Location">Where the prop is.</param>
        public GameProp(Vector2 Location = default)
        {
            location = Location;
        }

        /// <summary>
        /// where the object is
        /// </summary>
        protected Vector2 location;

        /// <summary>
        /// The location of the object in the 2D plane
        /// </summary>
        public Vector2 Location
        {
            get => location;
            set { location = value; }
        }

        /// <summary>
        /// X Component of location
        /// </summary>
        public float LocationXComponent
        {
            get => location.X;
            set { location.X = value; }
        }

        /// <summary>
        /// Y Component of location
        /// </summary>
        public float LocationYComponent
        {
            get => location.Y;
            set { location.Y = value; }
        }


        /// <summary>
        /// How fast the object is moving
        /// </summary>
        protected Vector2 velocity = Vector2.Zero;

        /// <summary>
        /// How fast the object is moving
        /// </summary>
        public Vector2 Velocity
        {
            get => velocity;
            set { velocity = value; }
        }

        /// <summary>
        /// X Component of velocity
        /// </summary>
        public float VelocityXComponent
        {
            get => velocity.X;
            set { velocity.X = value; }
        }

        /// <summary>
        /// X Component of velocity
        /// </summary>
        public float VelocityYComponent
        {
            get => velocity.Y;
            set { velocity.Y = value; }
        }


        /// <summary>
        /// The change in velocity for the object
        /// </summary>
        protected Vector2 acceleration = Vector2.Zero;

        /// <summary>
        /// The change in velocity for the object
        /// </summary>
        public Vector2 Acceleration
        {
            get => acceleration;
            set { acceleration = value; }
        }

        /// <summary>
        /// X Component of Acceleration
        /// </summary>
        public float AccelerationXComponent
        {
            get => acceleration.X;
            set { acceleration.X = value; }
        }

        /// <summary>
        /// Y Component of Acceleration
        /// </summary>
        public float AccelerationYComponent
        {
            get => acceleration.Y;
            set { acceleration.Y = value; }
        }

        /// <summary>
        /// Perform an update on the object
        /// </summary>
        /// <param name="gameTime">Timing values</param>
        public abstract void Update(GameTime gameTime);
    }
}
