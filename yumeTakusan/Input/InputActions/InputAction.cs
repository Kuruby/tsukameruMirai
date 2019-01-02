using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;
using yumeTakusan.Input.InputActions.shims;

namespace yumeTakusan.Input.InputActions
{
    public abstract class InputAction
    {
        static public implicit operator InputAction(Keys value)
        {
            return new KeyboardAction(value);
        }

        static public implicit operator InputAction(MouseButtons value)
        {
            return new MouseButtonAction(value);
        }

        static public implicit operator InputAction(Buttons value)
        {
            return new ControllerButtonAction(value);
        }
    }
}
