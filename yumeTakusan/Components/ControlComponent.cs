using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yumeTakusan.Interfaces;

namespace yumeTakusan.Components
{
    public abstract class ControlComponent
    {
        public ControlComponent() : this(null) { }

        public ControlComponent(IMovable controlledObject)
        {
            controlled = controlledObject;
        }

        protected IMovable controlled;

        public abstract void Update();
    }
}
