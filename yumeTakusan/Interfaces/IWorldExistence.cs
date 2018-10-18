using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace yumeUI
{
    /// <summary>
    /// IWorldExistence provides an interface that guarantees that an object will be able to exist in the world.
    /// </summary>
    interface IWorldExistense
    {
        Vector2 Location { get; set; }
        float LocationXComponent { get; set; }
        float LocationYComponent { get; set; }
    }
}
