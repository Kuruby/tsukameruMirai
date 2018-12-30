using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;

namespace yumeTakusan.Input.InputActions
{
    public abstract class InputAction
    {
        static public implicit operator InputAction(Keys value)
        {
            return new KeyboardAction(value);
        }
    }
}
