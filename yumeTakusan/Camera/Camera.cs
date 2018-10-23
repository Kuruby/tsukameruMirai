using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using yumeTakusan.BaseObjects;

namespace yumeTakusan.Camera
{
    public class Camera:GameProp
    {
        public Camera(CameraViewType ViewType)
        {
            viewType = ViewType;
        }

        CameraViewType viewType;
        PhysicsComponent physicsComponent = new PhysicsComponent();


        public override void Update(GameTime gameTime)
        {

        }

        public void SwitchViewType(CameraViewType switchTo)
        {
            //add extra fancy transition, maybe?
            viewType = switchTo;
        }
    }
}
