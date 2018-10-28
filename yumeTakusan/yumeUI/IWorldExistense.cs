using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace yumeTakusan.Interfaces
{
    /// <summary>
    /// IWorldExistence provides an interface that guarantees that an object will be able to exist in the world.
    /// </summary>
    public interface IWorldExistence
    {
        Vector2 Location { get; set; }
        float LocationXComponent { get; set; }
        float LocationYComponent { get; set; }
    }
}
