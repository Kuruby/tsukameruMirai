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
    /// An action taken on input
    /// </summary>
    public abstract class InputAction
    {
        /// <summary>
        /// Creates an input action from a keyboard key
        /// </summary>
        /// <param name="value">Key for the action to be on</param>
        static public implicit operator InputAction(Keys value)
        {
            return new KeyboardAction(value);
        }

        /// <summary>
        /// Creates an input action from a mouse button
        /// </summary>
        /// <param name="value">Button for the action to be on</param>
        static public implicit operator InputAction(MouseButtons value)
        {
            return new MouseButtonAction(value);
        }

        /// <summary>
        /// Creates an input action from a controller button
        /// </summary>
        /// <param name="value">Button for the action to be on</param>
        static public implicit operator InputAction(Buttons value)
        {
            return new ControllerButtonAction(value);
        }
    }
}
