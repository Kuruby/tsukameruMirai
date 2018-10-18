using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace yumeTakusan.Interfaces
{
    interface IPhysicsObject : IMovable
    {
        float Temperature { get; set; }
        float Mass { get; set; }
        //gravity, etc.
        Vector2 ForceConstant { get; set; }
        float ForceConstantXComponent { get; set; }
        float ForceConstantYComponent { get; set; }
        Vector2 Force { get; set; }
        float ForceXComponent { get; set; }
        float ForceYComponent { get; set; }
    }
}
