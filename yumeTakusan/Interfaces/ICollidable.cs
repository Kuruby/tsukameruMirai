using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace yumeTakusan.Interfaces
{
    public interface ICollidable
    {
        Rectangle Hitbox { get; set; }
        Rectangle WorldLocationHitbox { get; }
        bool CheckCollision(ICollidable otherObject);
        bool WithinObject(ICollidable otherObject);
        bool ObjectWithin(ICollidable otherObject);
    }
}
