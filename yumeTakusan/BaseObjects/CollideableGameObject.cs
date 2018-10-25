using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using yumeTakusan.Interfaces;
using yumeTakusan.Extensions;
using Microsoft.Xna.Framework.Graphics;

namespace yumeTakusan.BaseObjects
{
    //PhysicsGameObject, ICollidable
    public abstract class CollideableGameObject : GameObject, ICollidable
    {

        public CollideableGameObject(Texture2D Texture,Rectangle Hitbox, Color? Colour = null, SpriteEffects Effects = SpriteEffects.None,
            bool Visible = true, Vector2 Location = default(Vector2)) : base(Texture,Colour,Effects,Visible,Location)
        {
            hitbox = Hitbox;
        }


        protected Rectangle hitbox;

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
