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

        protected Dictionary<InputAction, string> boundActions = new Dictionary<InputAction, string>();
        protected Dictionary<string, bool> actionResults = new Dictionary<string, bool>();

        public bool getActionResult(string action) => actionResults[action];
    }
}
