using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using yumeTakusan.Interfaces;

namespace yumeTakusan.Interfaces
{
    public interface IMovable : IWorldExistence
    {
        Vector2 Velocity { get; set; }
        float VelocityXComponent { get; set; }
        float VelocityYComponent { get; set; }
        Vector2 Acceleration { get; set; }
        float AccelerationXComponent { get; set; }
        float AccelerationYComponent { get; set; }
    }
}
