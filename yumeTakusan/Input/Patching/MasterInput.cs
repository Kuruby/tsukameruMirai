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
        /// <summary>
        /// Constant: Maximum number of gamepads allowed by XInput
        /// </summary>
        const int MaxXInputGamepads = 4;

        /// <summary>
        /// Constructor, initializes stuff
        /// </summary>
        public MasterInput()
        {
            for (int i = 0; i < MaxXInputGamepads; i++)
            {
                gamePadStates[i] = new PastPresent<GamePadState>();
            }
        }

        /// <summary>
        /// Adds the events all witht he same handler
        /// </summary>
        /// <param name="Events">Events to add the handler for</param>
        /// <param name="handler">Handler to add for all the events</param>
        public void AddEventListeners(Event[] Events, PassThroughHandler handler, bool first = false)
        {
            foreach (Event e in Events)
            {
                //add the event listener at index 0 if inserted first or last if not
                AddEventListener(e, handler, first ? 0 : -1);
            }
        }

        /// <summary>
        /// Advanced adding for Events with an event, handler, and optional slot
        /// </summary>
        /// <param name="Events">Array of event handling data</param>
        public void AddEventListeners(params (Event, PassThroughHandler, int?)[] Events)
        {
            AddEventListeners(Events);
        }

        /// <summary>
        /// Advanced adding for Events with an event, handler, and optional slot
        /// </summary>
        /// <param name="Events">List of event handling data</param>
        public void AddEventListeners(List<(Event, PassThroughHandler, int?)> Events)
        {
            foreach ((Event, PassThroughHandler, int?) HandlingInformation in Events)
            {
                if (HandlingInformation.Item3.HasValue)
                {
                    AddEventListener(HandlingInformation.Item1, HandlingInformation.Item2, HandlingInformation.Item3.Value);
                }
                else
                {
                    AddEventListener(HandlingInformation.Item1, HandlingInformation.Item2);
                }
            }
        }

        /// <summary>
        /// Adds a single event listener
        /// </summary>
        /// <param name="e">Event to listen for</param>
        /// <param name="handler">Handler method called</param>
        /// <param name="slot">Where to put it in the array (-1 means at the end)</param>
        public void AddEventListener(Event e, PassThroughHandler handler, int slot = -1)
        {
            if (!EventListeners.ContainsKey(e))
            {
                EventListeners.Add(e, new List<PassThroughHandler>());
            }
            if (slot < 0)
            {
                EventListeners[e].Add(handler);
            }
            else
            {
                EventListeners[e].Insert(slot, handler);
            }
        }

        /// <summary>
        /// Event listeners (and also all the events)
        /// </summary>
        Dictionary<Event, List<PassThroughHandler>> EventListeners = new Dictionary<Event, List<PassThroughHandler>>();

        /// <summary>
        /// The location where the mouse tip is. (Rectangle)
        /// </summary>
        public Rectangle MouseTip { get; private set; }
        /// <summary>
        /// The location where the mouse is
        /// </summary>
        public Vector2 MousePosition { get; private set; }

        /// <summary>
        /// The past/present state of the keyboard
        /// </summary>
        internal PastPresent<KeyboardState> keyboardState = new PastPresent<KeyboardState>(Keyboard.GetState());

        /// <summary>
        /// the past/present state of the mouse
        /// </summary>
        internal PastPresent<MouseState> mouseState = new PastPresent<MouseState>(Mouse.GetState());

        /// <summary>
        /// the past/present states for the gamepads
        /// </summary>
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

        /// <summary>
        /// Updates the handlers
        /// </summary>
        /// <param name="gameTime">Timing values</param>
        public void Update(GameTime gameTime)
        {
            //update the state of devices
            keyboardState.Present = Keyboard.GetState();
            mouseState.Present = Mouse.GetState();

            //update mouse position
            MousePosition = new Vector2(mouseState.Present.X, mouseState.Present.Y);
            MouseTip = new Rectangle(mouseState.Present.X, mouseState.Present.Y, 1, 1);

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
