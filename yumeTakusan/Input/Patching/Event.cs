using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;

namespace yumeTakusan.Input.Patching
{
    /// <summary>
    /// Timing values for events (bitfields yes)
    /// </summary>
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
        public Keys key { get; private set; }
        /// <summary>
        /// Number of gamepad to trigger to if it is a gamepad event
        /// </summary>
        public int gamepadNumber { get; private set; }
        /// <summary>
        /// Button to trigger to, if it is a gamepad event
        /// </summary>
        public Buttons button { get; private set; }
        /// <summary>
        /// If the event triggers on any mouse event.
        /// </summary>
        public bool interceptsMice { get; private set; }

        /// <summary>
        /// When in the event's lifecycle it triggers:
        /// Only valid for keys and gamepad events.
        /// </summary>
        EventTiming timing;


        /// <summary>
        /// Whether the event is currently triggered
        /// </summary>
        /// <param name="input">the input to use to check</param>
        /// <returns></returns>
        public bool isTriggered(MasterInput input)
        {
            if ((int)key != -1)
            {
                //key path
                return matchesTiming(input.keyboardState.Past.IsKeyDown(key),
                    input.keyboardState.Present.IsKeyDown(key));
            }

            if (gamepadNumber != -1)
            {
                //gamepad path

                //don't deal with disconnected gamepads
                if (!input.gamePadStates[gamepadNumber].Present.IsConnected
                    || !input.gamePadStates[gamepadNumber].Past.IsConnected)
                {
                    return false;
                }

                return matchesTiming(input.gamePadStates[gamepadNumber].Past.IsButtonDown(button),
                    input.gamePadStates[gamepadNumber].Present.IsButtonDown(button));
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

        /// <summary>
        /// Returns whether the past and present states match the timing values in the object
        /// </summary>
        /// <param name="past">past value</param>
        /// <param name="present">present value</param>
        /// <returns>whether the past and present states match the timing</returns>
        private bool matchesTiming(bool past, bool present)
            => matchesTiming(past, present, timing);


        /// <summary>
        /// Returns whether the past and present states match the timing value
        /// </summary>
        /// <param name="past">past value</param>
        /// <param name="present">present value</param>
        /// <param name="timing">which timing to trigger on</param>
        /// <returns>whether the past and present states match the timing</returns>
        private static bool matchesTiming(bool past, bool present, EventTiming timing)
        {
            //binary logic
            int flagsFromInput = 0;
            //set bit falgs
            flagsFromInput |= past ? 0b10 : 0;
            flagsFromInput |= present ? 0b01 : 0;
            //xor with bit flags in the timing
            int result = flagsFromInput ^ (int)timing;
            //0 means they're identical
            return result == 0;
        }

        /// <summary>
        /// Returns if the left button matches the given timing.
        /// </summary>
        /// <param name="input">Input to check against</param>
        /// <param name="timing">Timing to compare button presses to</param>
        /// <returns>Whether the left button matches the timing</returns>
        public static bool IsLeftMouseTriggered(MasterInput input, EventTiming timing = EventTiming.Press)
            => matchesTiming(input.mouseState.Past.LeftButton == ButtonState.Pressed,
                input.mouseState.Present.LeftButton == ButtonState.Pressed, timing);

        /// <summary>
        /// Returns if the middle button matches the given timing.
        /// </summary>
        /// <param name="input">Input to check against</param>
        /// <param name="timing">Timing to compare button presses to</param>
        /// <returns>Whether the middle button matches the timing</returns>
        public static bool IsMiddleMouseTriggered(MasterInput input, EventTiming timing = EventTiming.Press)
            => matchesTiming(input.mouseState.Past.MiddleButton == ButtonState.Pressed,
                input.mouseState.Present.MiddleButton == ButtonState.Pressed, timing);

        /// <summary>
        /// Returns if the right button matches the given timing.
        /// </summary>
        /// <param name="input">Input to check against</param>
        /// <param name="timing">Timing to compare button presses to</param>
        /// <returns>Whether the right button matches the timing</returns>
        public static bool IsRightMouseTriggered(MasterInput input, EventTiming timing = EventTiming.Press)
            => matchesTiming(input.mouseState.Past.RightButton == ButtonState.Pressed,
                input.mouseState.Present.RightButton == ButtonState.Pressed, timing);
    }
}
