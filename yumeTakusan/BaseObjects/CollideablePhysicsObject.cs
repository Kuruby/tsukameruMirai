using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using yumeTakusan.Interfaces;
using yumeTakusan.Extensions;

namespace yumeTakusan.BaseObjects
{
    //PhysicsGameObject, ICollidable
    public abstract class CollideablePhysicsObject : PhysicsGameObject, ICollidable
    {
        private Rectangle hitbox;
        public Rectangle Hitbox
        {
            get => hitbox;
            set { hitbox = value; worldHitbox = hitbox.RectangleAtPoint(Location); }
        }

        private Rectangle worldHitbox;
        public Rectangle WorldLocationHitbox => worldHitbox;


        public bool CheckCollision(ICollidable otherObject) =>
            WorldLocationHitbox.Intersects(otherObject.WorldLocationHitbox);


        public bool ObjectWithin(ICollidable otherObject) =>
            WorldLocationHitbox.Contains(otherObject.WorldLocationHitbox);


        public bool WithinObject(ICollidable otherObject) =>
            otherObject.Hitbox.Contains(WorldLocationHitbox);

    }
}
