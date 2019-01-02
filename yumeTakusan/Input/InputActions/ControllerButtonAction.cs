using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;

namespace yumeTakusan.Input.InputActions
{
    public sealed class ControllerButtonAction : InputAction
    {
        public ControllerButtonAction(Buttons Button, bool CanHold = false, ButtonState TriggerState = ButtonState.Pressed)
        {
            button = Button;
            canHold = CanHold;
            triggerState = TriggerState;
        }

        public ControllerButtonAction(Buttons Button, ButtonState TriggerState, bool CanHold = false) : this(Button, CanHold, TriggerState) { }

        Buttons button;

        bool canHold;

        ButtonState triggerState;

        public bool isActionTriggered(GamePadState gamePadState, GamePadState pastGamePadState)
        {
            if ((triggerState == ButtonState.Pressed && gamePadState.IsButtonDown(button))
                || (triggerState == ButtonState.Released && gamePadState.IsButtonUp(button)))
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
