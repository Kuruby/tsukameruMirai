using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yumeTakusan.Components;
using yumeTakusan.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

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

        //TODO: add an onInput event here

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
            //shim directional keys?
        }

        /// <summary>
        /// Update the state of the controller and move the component depending on that
        /// </summary>
        /// <param name="gameTime">Timing values</param>
        public override void Update(GameTime gameTime)
        {
        }
    }
}
