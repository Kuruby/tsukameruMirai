﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;

namespace yumeTakusan.Input.InputActions
{
    public class KeyboardAction : InputAction
    {

        public KeyboardAction(Keys Key, bool CanHold = false, KeyState TriggerState = KeyState.Down)
        {
            key = Key;
            canHold = CanHold;
            triggerState = TriggerState;
        }

        public KeyboardAction(Keys Key, KeyState TriggerState, bool CanHold = false) : this(Key, CanHold, TriggerState) { }

        Keys key;

        bool canHold;
        /// <summary>
        /// event triggers upon entering the state if not held and if in the state if held
        /// </summary>
        KeyState triggerState;

        /// <summary>
        /// Given the past and present keyboard states, determine if the action has been triggered
        /// </summary>
        /// <param name="keyboardState"></param>
        /// <param name="pastKeyboardState"></param>
        /// <returns></returns>
        public bool isActionTriggered(KeyboardState keyboardState, KeyboardState pastKeyboardState)
        {

            //If the key is currently in the correct state, do nothing
            if ((triggerState == KeyState.Down && keyboardState.IsKeyDown(key))
                || (triggerState == KeyState.Up && keyboardState.IsKeyUp(key)))
            {

            }
            //if it is not currently in the correct state return false
            else
            {
                return false;
            }

            //If the key can be held since the first frame pressed immediately return true
            if (canHold)
            {
                return true;
            }
            else
            {
                //Check if the past state is the opposite of the present one.
                if ((triggerState == KeyState.Down && pastKeyboardState.IsKeyUp(key))
                || (triggerState == KeyState.Up && pastKeyboardState.IsKeyDown(key)))
                {
                    //If it is, return that it has been triggered.
                    return true;
                }
                //If it hasn't changed it's not triggered.
                else
                {
                    return false;
                }
            }
        }

    }
}