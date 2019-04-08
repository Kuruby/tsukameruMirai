using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;

namespace yumeTakusan.Input.Patching
{
    public enum EventTiming
    {
        Off = 0b00,
        Press = 0b01,
        During = 0b11,
        Release = 0b10
    }
    public struct Event
    {
        /// <summary>
        /// Create an event for a keypress
        /// </summary>
        /// <param name="Key">Keypress to trigger on</param>
        /// <param name="Timing">When in the event lifecycle to trigger, default is on press</param>
        public Event(Keys Key, EventTiming Timing = EventTiming.Press)
        {
            //set key
            key = Key;
            //Set timing.
            timing = Timing;

            //Set unnecessary values to -1
            gamepadNumber = -1;
            button = (Buttons)(-1);
            //set mice to false
            interceptsMice = false;

        }

        /// <summary>
        /// Gamepad event constructor
        /// </summary>
        /// <param name="GamepadNumber"></param>
        /// <param name="Button"></param>
        /// <param name="Timing"></param>
        public Event(int GamepadNumber, Buttons Button, EventTiming Timing)
        {
            //Set gamepad number
            gamepadNumber = GamepadNumber;
            //Set gamepad button
            button = Button;
            //Set timing
            timing = Timing;
            //Set unnecessary values to false or -1
            key = (Keys)(-1);
            interceptsMice = false;
        }

        /// <summary>
        /// Event for mice. Warning: this is not a default parameterless constructor!
        /// Use false for making an 'empty' or null event.
        /// </summary>
        /// <param name="UseMice">Whether to make the event a mouse event</param>
        public Event(bool UseMice = true)
        {
            //Mice depends on what the creator wants
            interceptsMice = UseMice;
            //set unnecessary values to -1
            key = (Keys)(-1);
            gamepadNumber = -1;
            button = (Buttons)(-1);
            timing = (EventTiming)(-1);
        }

        //Mutually exclusive event types
        /// <summary>
        /// Key to trigger on, if it is a key event
        /// </summary>
        private Keys key;
        /// <summary>
        /// Number of gamepad to trigger to if it is a gamepad event
        /// </summary>
        private int gamepadNumber;
        /// <summary>
        /// Button to trigger to, if it is a gamepad event
        /// </summary>
        private Buttons button;
        /// <summary>
        /// If the event triggers on any mouse event.
        /// </summary>
        private bool interceptsMice;

        /// <summary>
        /// When in the event's lifecycle it triggers:
        /// Only valid for keys and gamepad events.
        /// </summary>
        EventTiming timing;

        public bool isTriggered(MasterInput input)
        {
            if ((int)key != -1)
            {
                //key path

                //binary logic
                int bleh = 0;
                bleh |= input.keyboardState.Past.IsKeyDown(key) ? 0b10 : 0;
                bleh |= input.keyboardState.Present.IsKeyDown(key) ? 0b01 : 0;
                int blurgh = bleh ^ (int)timing;
                if (blurgh == 0)
                {
                    return true;
                }
                return false;
            }

            if (gamepadNumber != -1)
            {
                //gamepad path

                //don't deal with disconnected gamepads
                if(!input.gamePadStates[gamepadNumber].Present.IsConnected || !input.gamePadStates[gamepadNumber].Past.IsConnected)
                {
                    return false;
                }

                //binary logic
                int bleh = 0;
                bleh |= input.gamePadStates[gamepadNumber].Past.IsButtonDown(button) ? 0b10 : 0;
                bleh |= input.gamePadStates[gamepadNumber].Present.IsButtonDown(button) ? 0b01 : 0;
                int blurgh = bleh ^ (int)timing;
                if (blurgh == 0)
                {
                    return true;
                }
                return false;
            }

            if (interceptsMice)
            {
                //mouse path:
                //return true because mouse handling is hard™ and thus must be handled by the receiver
                return true;
            }
            //this should never happen, but if it does it's a null event which CANNOT BE TRIGGERED
            //so false, duh!
            return false;
        }
    }
}
