using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yumeTakusan.Components;
using yumeTakusan.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using yumeTakusan.Input.Patching;

namespace yumeTakusan.Components.Controllers
{
    /// <summary>
    /// Controls an object using input available on desktop: Mouse, Keyboard, Controllers, or Touchscreen
    /// </summary>
    public class DesktopInputController : ControlComponent
    {
        /// <summary>
        /// Speed per frame, in pixels
        /// </summary>
        const float PixelSpeed = 5;

        /// <summary>
        /// Event handler for the directional input keys
        /// </summary>
        /// <param name="param">Event to check</param>
        /// <returns>Whether not to continue.</returns>
        bool onDirectionalKey(object param)
        {
            if (!(param is Event))
            {
                return false;
            }

            Event e = (Event)(param);

            if((int)e.key==-1)
            {
                return false;
            }


            Keys Key = e.key;
            if (Key == Up)
            {
                VelocityTransient.Y -= PixelSpeed;
            }
            else if (Key == Down)
            {
                VelocityTransient.Y += PixelSpeed;
            }
            else if (Key == Left)
            {
                VelocityTransient.X -= PixelSpeed;
            }
            else if (Key == Right)
            {
                VelocityTransient.X += PixelSpeed;
            }
            else
            {
                return false;
            }


            return true;
        }

        Keys Up, Down, Left, Right;
        Vector2 VelocityTransient = Vector2.Zero;

        /// <summary>
        /// Empty constructor: controls no object
        /// </summary>
        public DesktopInputController(MasterInput input) : this(null,input) { }

        /// <summary>
        /// Default Constructor, creates a controller controlling the specified object
        /// </summary>
        /// <param name="controlledObject">Object to be controlled</param>
        public DesktopInputController(IMovable controlledObject,MasterInput input) : base(controlledObject)
        {
            //register directional keys
            Up = Keys.W;
            Left = Keys.A;
            Down = Keys.S;
            Right = Keys.D;

            //creates events for directional keys
            Event[] events = (from key in new Keys[]{ Up,Down,Left,Right}
                                select new Event(key))
                                .Concat(
                                    from key in new Keys[] { Up, Down, Left, Right }
                                        select new Event(key, EventTiming.During)
                                )
                                .ToArray();
            //add event listeners for those
            input.AddEventListeners(events, onDirectionalKey);

        }

        /// <summary>
        /// Update the state of the controller and move the component depending on that
        /// </summary>
        /// <param name="gameTime">Timing values</param>
        public override void Update(GameTime gameTime)
        {
            controlled.Velocity = VelocityTransient;
            //this is the last step
            VelocityTransient = Vector2.Zero;
        }
    }
}
