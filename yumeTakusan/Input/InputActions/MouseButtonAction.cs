using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;
using yumeTakusan.Input.InputActions.shims;

namespace yumeTakusan.Input.InputActions
{
    /// <summary>
    /// Action on mouse button
    /// </summary>
    public sealed class MouseButtonAction : InputAction
    {
        /// <summary>
        /// Creates mouse button action on specified button
        /// </summary>
        /// <param name="Button">Mouse button to watch for</param>
        /// <param name="CanHold">Whether the action repeats</param>
        /// <param name="TriggerState">State in which the action triggers</param>
        public MouseButtonAction(MouseButtons Button, bool CanHold = false, ButtonState TriggerState = ButtonState.Pressed)
        {
            button = Button;
            canHold = CanHold;
            triggerState = TriggerState;
        }

        /// <summary>
        /// Creates mouse button action on specified button
        /// </summary>
        /// <param name="Button">Mouse button to watch for</param>
        /// <param name="TriggerState">State in which the action triggers</param>
        /// <param name="CanHold">Whether the action repeats</param>
        public MouseButtonAction(MouseButtons Button, ButtonState TriggerState, bool CanHold = false) : this(Button, CanHold, TriggerState) { }

        /// <summary>
        /// Button to watch for action on
        /// </summary>
        MouseButtons button;

        /// <summary>
        /// Whether the action repeats
        /// </summary>
        bool canHold;

        /// <summary>
        /// State in which the action triggers: On entering if not repeating, in state if repeats
        /// </summary>
        ButtonState triggerState;

        /// <summary>
        /// Checks if the action was triggered this frame
        /// </summary>
        /// <param name="mouseState">Mouse state this frame</param>
        /// <param name="pastMouseState">Mouse state last frame</param>
        /// <returns>Whether the action was triggered this frame</returns>
        public bool IsActionTriggered(MouseState mouseState, MouseState pastMouseState)
        {
            ButtonState currentState = ButtonState.Released;
            ButtonState pastState = ButtonState.Released;

            //Get the state of the button described by the action through a switch
            switch (button)
            {
                case MouseButtons.Left:
                    currentState = mouseState.LeftButton;
                    pastState = pastMouseState.LeftButton;
                    break;
                case MouseButtons.Middle:
                    currentState = mouseState.MiddleButton;
                    pastState = pastMouseState.MiddleButton;
                    break;
                case MouseButtons.Right:
                    currentState = mouseState.RightButton;
                    pastState = pastMouseState.RightButton;
                    break;
                case MouseButtons.XButton1:
                    currentState = mouseState.XButton1;
                    pastState = pastMouseState.XButton1;
                    break;
                case MouseButtons.XButton2:
                    currentState = mouseState.XButton2;
                    pastState = pastMouseState.XButton2;
                    break;
                default:
                    throw new Exception("unknown type of mouse button");
            }

            //Check if the current state is triggered
            if (triggerState == currentState)
            {

            }
            else
            {
                //if it's not currently in the state return false
                return false;
            }

            //if the action can be held the condition is already met for it to trigger
            if (canHold)
            {
                return true;
            }

            //If it's changed, it meets the condition for triggering.
            if (triggerState != pastState)
            {
                return true;
            }
            else
            //Without a change there is no trigger
            {
                return false;
            }
        }
    }
}
