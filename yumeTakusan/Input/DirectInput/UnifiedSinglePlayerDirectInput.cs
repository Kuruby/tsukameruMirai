using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;
using yumeTakusan.Input.InputActions;

namespace yumeTakusan.Input.DirectInput
{
    public sealed class UnifiedSinglePlayerDirectInput : DirectInput
    {

        public override void initialize()
        {
            //Initialize the keyboard and mouse state by getting them
            keyboardState = Keyboard.GetState();
            mouseState = Mouse.GetState();

            //Initialize gamepad state and if it was connected
            gamePadState = GamePad.GetState(gamepadnumber);
        }



        //Present and past state of keyboard
        KeyboardState keyboardState;
        KeyboardState pastKeyboardState;

        /// <summary>
        /// Present state of mouse
        /// </summary>
        MouseState mouseState;
        /// <summary>
        /// Past state of mouse
        /// </summary>
        MouseState pastMouseState;

        /// <summary>
        /// the number of the gamepad which is connected for a single player
        /// </summary>
        const int gamepadnumber = 0;

        /// <summary>
        /// Present & past state of gamepad
        /// </summary>
        GamePadState gamePadState, pastGamePadState;

        /// <summary>
        /// whether or not the gamepad is connected in the current state
        /// </summary>
        bool GamePadIsActive => gamePadState.IsConnected;

        /// <summary>
        /// keyboard keys for movement directions
        /// </summary>
        Keys leftKey, rightKey, upKey, downKey;

        public void SetDirectionalKeys(Keys left, Keys right, Keys up, Keys down)
        {
            leftKey = left;
            rightKey = right;
            upKey = up;
            downKey = down;
        }

        public override void Update()
        {
            //update keyboard state
            pastKeyboardState = keyboardState;
            keyboardState = Keyboard.GetState();

            //Update the state of the Mouse
            pastMouseState = mouseState;
            mouseState = Mouse.GetState();

            pastGamePadState = gamePadState;
            gamePadState = GamePad.GetState(gamepadnumber);

            //Perform the base update actions
            base.Update();
        }

        public override void UpdateAxes()
        {
            //Update the left/right and up/down keystates

            upDownMove = 0;
            leftRightMove = 0;

            if (keyboardState.IsKeyDown(leftKey))
            {
                leftRightMove -= 1;
            }
            if (keyboardState.IsKeyDown(rightKey))
            {
                leftRightMove += 1;
            }

            if (keyboardState.IsKeyDown(upKey))
            {
                upDownMove -= 1;
            }
            if (keyboardState.IsKeyDown(downKey))
            {
                upDownMove += 1;
            }

            //Gamepad has priority
            if (GamePadIsActive)
            {
                leftRightMove = gamePadState.ThumbSticks.Left.X;
                upDownMove = -gamePadState.ThumbSticks.Left.Y;
            }
        }

        public override void UpdateActions()
        {
            //Update values
            foreach (var pair in boundActions)
            {
                if (pair.Value is KeyboardAction)
                {
                    actionResults[pair.Key] = (pair.Value as KeyboardAction).isActionTriggered(keyboardState, pastKeyboardState);
                }
                if (pair.Value is MouseButtonAction)
                {
                    actionResults[pair.Key] = (pair.Value as MouseButtonAction).isActionTriggered(mouseState, pastMouseState);
                }

                if (pair.Value is ControllerButtonAction)
                {
                    actionResults[pair.Key] = (pair.Value as ControllerButtonAction).isActionTriggered(gamePadState, pastGamePadState);
                }

            }
            if (GamePadIsActive)
            {
                foreach (var pair in boundActions)
                {
                    if (pair.Value is ControllerButtonAction)
                    {
                        actionResults[pair.Key] = (pair.Value as ControllerButtonAction).isActionTriggered(gamePadState, pastGamePadState);
                    }
                }
            }
        }

    }
}
