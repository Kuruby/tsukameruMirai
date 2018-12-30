using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;

namespace yumeTakusan.Input.DirectInput
{
    public sealed class DesktopDirectInput : DirectInput
    {

        public override void initialize()
        {
            keyboardState = Keyboard.GetState();
            mouseState = Mouse.GetState();
        }
        KeyboardState keyboardState;
        KeyboardState pastKeyboardState;

        MouseState mouseState;
        MouseState pastMouseState;

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


            //Update values
            foreach (var idkwhatthisisuntilidebug in boundActions)
            {

            }
        }

    }
}
