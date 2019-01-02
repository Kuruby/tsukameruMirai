using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yumeTakusan.Input.InputActions;

namespace yumeTakusan.Input.DirectInput
{
    /// <summary>
    /// Represents input directly received from a device or devices
    /// </summary>
    public abstract class DirectInput
    {
        /// <summary>
        /// Initializes the input component
        /// </summary>
        public abstract void initialize();

        /// <summary>
        /// Updates the state of the input
        /// </summary>
        public virtual void Update()
        {
            UpdateActions();
            UpdateAxes();
        }

        /// <summary>
        /// update the movement axes
        /// </summary>
        public abstract void UpdateAxes();

        /// <summary>
        /// Update actions
        /// </summary>
        public abstract void UpdateActions();


        /// <summary>
        /// Amount moved left and right
        /// </summary>
        protected float leftRightMove;
        /// <summary>
        /// Amount moved up and down
        /// </summary>
        protected float upDownMove;

        /// <summary>
        /// Amount moved left and right
        /// </summary>
        public float LeftRightMove => leftRightMove;
        /// <summary>
        /// Amount moved up and down
        /// </summary>
        public float UpDownMove => upDownMove;

        /// <summary>
        /// Actions with a string key representing them
        /// </summary>
        protected Dictionary<string, InputAction> boundActions = new Dictionary<string, InputAction>();
        /// <summary>
        /// Action names with their results from the last frame
        /// </summary>
        protected Dictionary<string, bool> actionResults = new Dictionary<string, bool>();

        /// <summary>
        /// Gets the result of an action
        /// </summary>
        /// <param name="action">name of the action</param>
        /// <returns>Whether the action was executed on the last update</returns>
        public bool getActionResult(string action) => actionResults[action];

        /// <summary>
        /// Adds an action to the actions checked for
        /// </summary>
        /// <param name="name">name of the action</param>
        /// <param name="action">Action that is checked for</param>
        /// <returns>whether it was correctly registered</returns>
        public bool registerAction(string name, InputAction action)
        {
            //If there's a collision for either value return failure
            if (boundActions.ContainsKey(name) || boundActions.ContainsValue(action))
            {
                return false;
            }

            //If it's not a collision add it to the collection and return success
            boundActions.Add(name, action);
            actionResults.Add(name, false);
            return true;
        }

        /// <summary>
        /// Removes an action
        /// </summary>
        /// <param name="name">Name of action to remove</param>
        public void removeAction(string name)
        {
            if (actionResults.ContainsKey(name))
                actionResults.Remove(name);
            if (boundActions.ContainsKey(name))
                boundActions.Remove(name);
        }
    }
}
