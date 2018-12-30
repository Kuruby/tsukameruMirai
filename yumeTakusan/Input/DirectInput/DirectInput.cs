using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yumeTakusan.Input.InputActions;

namespace yumeTakusan.Input.DirectInput
{
    public abstract class DirectInput
    {
        public abstract void initialize();
        public abstract void Update();

        protected float leftRightMove;
        protected float upDownMove;

        public float LeftRightMove => leftRightMove;
        public float UpDownMove => upDownMove;

        protected Dictionary<string, InputAction> boundActions = new Dictionary<string, InputAction>();
        protected Dictionary<string, bool> actionResults = new Dictionary<string, bool>();

        public bool getActionResult(string action) => actionResults[action];

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

        public void removeAction(string name)
        {
            if (actionResults.ContainsKey(name))
                actionResults.Remove(name);
            if (boundActions.ContainsKey(name))
                boundActions.Remove(name);
        }
    }
}
