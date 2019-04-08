using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using yumeTakusan.Interfaces;
using yumeTakusan.Events;

namespace yumeTakusan.Input.Patching
{
    public class MasterInput : IUpdatable
    {
        const int MaxXInputGamepads = 4;

        public MasterInput()
        {
            for (int i = 0; i < MaxXInputGamepads; i++)
            {
                gamePadStates[i] = new PastPresent<GamePadState>();
            }
        }

        Dictionary<Event, List<PassThroughHandler>> EventListeners = new Dictionary<Event, List<PassThroughHandler>>();

        public Rectangle MouseTip { get; private set; }
        public Vector2 MousePosition { get; private set; }

        internal PastPresent<KeyboardState> keyboardState = new PastPresent<KeyboardState>(Keyboard.GetState());

        internal PastPresent<MouseState> mouseState = new PastPresent<MouseState>(Mouse.GetState());

        internal PastPresent<GamePadState>[] gamePadStates = new PastPresent<GamePadState>[MaxXInputGamepads];


        /// <summary>
        /// Sends the trigger through the connected listeners
        /// </summary>
        /// <param name="sender">The object to act on</param>
        public void eventTriggerAndFilter(Event triggeredEvent)
        {
            foreach (PassThroughHandler listener in EventListeners[triggeredEvent])
            {
                if (listener(triggeredEvent))
                {
                    break;
                }
            }
        }

        public void Update(GameTime gameTime)
        {
            //update the state of devices
            keyboardState.Present = Keyboard.GetState();
            mouseState.Present = Mouse.GetState();

            //Update all gamepads (only 4 xinput ones usable)
            for (int i = 0; i < MaxXInputGamepads; i++)
            {
                gamePadStates[i].Present = GamePad.GetState(i);
            }

            //TODO: check events and pass them through to the listeners
            foreach (Event Event in EventListeners.Keys)
            {
                //change true to checking the event
                //also, make the event type...
                if (Event.isTriggered(this))
                {
                    eventTriggerAndFilter(Event);
                }
            }
        }
    }
}
