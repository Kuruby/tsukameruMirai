using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;
using yumeTakusan.Input.InputActions;

namespace yumeTakusan.Input.DirectInput
{
    /// <summary>
    /// Multiple input methods for singleplayer
    /// </summary>
    public sealed class UnifiedSinglePlayerDirectInput : DirectInput
    {
        /// <summary>
        /// Prepares the initial state
        /// </summary>
        public override void initialize()
        {
            //Initialize the keyboard and mouse state by getting them
            keyboardState = Keyboard.GetState();
            mouseState = Mouse.GetState();

            //Initialize gamepad state
            gamePadState = GamePad.GetState(gamepadnumber);
        }



        /// <summary>
        /// Present state of keyboard
        /// </summary>
        KeyboardState keyboardState;
        /// <summary>
        /// Past state of keyboard
        /// </summary>
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
        /// the number of the gamepad which is connected for a single player: by default compile 0, the first one
        /// </summary>
        const int gamepadnumber = 0;

        /// <summary>
        /// Current gamepad state
        /// </summary>
        GamePadState gamePadState;
        /// <summary>
        /// Past gamepad state
        /// </summary>
        GamePadState pastGamePadState;

        /// <summary>
        /// whether or not the gamepad is connected in the current state
        /// </summary>
        bool GamePadIsActive => gamePadState.IsConnected;

        /// <summary>
        /// keyboard keys for movement directions
        /// </summary>
        Keys leftKey, rightKey, upKey, downKey;

        /// <summary>
        /// Sets the keys for the axes
        /// </summary>
        /// <param name="left">Key pressed for left</param>
        /// <param name="right">Key pressed for right</param>
        /// <param name="up">Key pressed for up</param>
        /// <param name="down">Key pressed for down</param>
        public void SetDirectionalKeys(Keys left, Keys right, Keys up, Keys down)
        {
            leftKey = left;
            rightKey = right;
            upKey = up;
            downKey = down;
        }

        /// <summary>
        /// Updates the input
        /// </summary>
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

        /// <summary>
        /// Updates the state of the axes using controller and keys
        /// </summary>
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

        /// <summary>
        /// Updates the actions for keyboard, mouse and controller
        /// </summary>
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
        }

    }
}
