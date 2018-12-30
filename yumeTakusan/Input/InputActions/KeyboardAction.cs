using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;

namespace yumeTakusan.Input.InputActions
{
    class KeyboardAction : InputAction
    {
        Keys key;

        bool canHold;
        /// <summary>
        /// event triggers upon entering the state if not held and if in the state if held
        /// </summary>
        KeyState triggerState;
    }
}
