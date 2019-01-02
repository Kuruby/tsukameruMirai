using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;

namespace yumeTakusan.Input.InputActions
{
    /// <summary>
    /// Action on a controller button
    /// </summary>
    public sealed class ControllerButtonAction : InputAction
    {
        /// <summary>
        /// create a controller action for the button
        /// </summary>
        /// <param name="Button">Button pressed</param>
        /// <param name="CanHold">Whether it can repeat</param>
        /// <param name="TriggerState">State that button is in that triggers it</param>
        public ControllerButtonAction(Buttons Button, bool CanHold = false, ButtonState TriggerState = ButtonState.Pressed)
        {
            button = Button;
            canHold = CanHold;
            triggerState = TriggerState;
        }

        /// <summary>
        /// Creates controller button action
        /// </summary>
        /// <param name="Button">Button pressed</param>
        /// <param name="TriggerState">State that button is in that triggers it</param>
        /// <param name="CanHold">Whether it can repeat</param>
        public ControllerButtonAction(Buttons Button, ButtonState TriggerState, bool CanHold = false) : this(Button, CanHold, TriggerState) { }


        /// <summary>
        /// The button to check for the action on
        /// </summary>
        Buttons button;

        /// <summary>
        /// Whether the action can repeat
        /// </summary>
        bool canHold;

        /// <summary>
        /// State to watch for
        /// </summary>
        ButtonState triggerState;


        /// <summary>
        /// Checks for the action triggering
        /// </summary>
        /// <param name="gamePadState">State of gamepad this frame</param>
        /// <param name="pastGamePadState">State of gamepad last frame</param>
        /// <returns>Whether the action is triggered this frame</returns>
        public bool isActionTriggered(GamePadState gamePadState, GamePadState pastGamePadState)
        {
            if (gamePadState.IsConnected &&
                ((triggerState == ButtonState.Pressed && gamePadState.IsButtonDown(button))
                || (triggerState == ButtonState.Released && gamePadState.IsButtonUp(button))))
            {

            }
            else
            {
                return false;
            }

            if (canHold)
            {
                return true;
            }

            if (!pastGamePadState.IsConnected
                || (triggerState == ButtonState.Pressed && pastGamePadState.IsButtonUp(button))
                || (triggerState == ButtonState.Released && pastGamePadState.IsButtonDown(button)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
