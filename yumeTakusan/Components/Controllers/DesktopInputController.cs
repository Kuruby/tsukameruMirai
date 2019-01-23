using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yumeTakusan.Input.InputActions;
using yumeTakusan.Input.DirectInput;
using yumeTakusan.Components;
using yumeTakusan.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using yumeTakusan.Input.InputActions.shims;

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
        const float pixelSpeed = 5;

        /// <summary>
        /// The input controller
        /// </summary>
        UnifiedSinglePlayerDirectInput input = new UnifiedSinglePlayerDirectInput();

        /// <summary>
        /// Empty constructor: controls no object
        /// </summary>
        public DesktopInputController() : this(null) { }

        /// <summary>
        /// Default Constructor, creates a controller controlling the specified object
        /// </summary>
        /// <param name="controlledObject">Object to be controlled</param>
        public DesktopInputController(IMovable controlledObject) : base(controlledObject)
        {
            input.SetDirectionalKeys(Keys.A, Keys.D, Keys.W, Keys.S);
            input.RegisterAction("a", Keys.Q);
            input.RegisterAction("b", MouseButtons.Left);
            input.RegisterAction("c", Buttons.X);
        }

        /// <summary>
        /// Update the state of the controller and move the component depending on that
        /// </summary>
        /// <param name="gameTime">Timing values</param>
        public override void Update(GameTime gameTime)
        {
            input.Update();
            controlled.Velocity = Vector2.Zero;
            applyMovementChange(input.LeftRightMove * pixelSpeed, input.UpDownMove * pixelSpeed);
            if (input.GetActionResult("a"))
            {
                Console.WriteLine("Q");
            }
            if (input.GetActionResult("b"))
            {
                Console.WriteLine("Left");
            }
            if (input.GetActionResult("c"))
            {
                Console.WriteLine("X");
            }
        }
    }
}
