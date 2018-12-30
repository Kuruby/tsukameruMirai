using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yumeTakusan.Input.InputActions;
using yumeTakusan.Input.DirectInput;
using yumeTakusan.Components;
using yumeTakusan.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace yumeTakusan.Components.Controllers
{
    public class DesktopInputController : ControlComponent
    {
        const float pixelSpeed = 5;

        DesktopDirectInput input = new DesktopDirectInput();

        public DesktopInputController() : this(null) { }

        public DesktopInputController(IMovable controlledObject) : base(controlledObject)
        {
            input.SetDirectionalKeys(Keys.A, Keys.D, Keys.W, Keys.S);
            input.registerAction("a", Keys.Q);
        }


        public override void Update(GameTime gameTime)
        {
            input.Update();
            controlled.Velocity = Vector2.Zero;
            applyMovementChange(input.LeftRightMove * pixelSpeed, input.UpDownMove * pixelSpeed);
        }
    }
}
