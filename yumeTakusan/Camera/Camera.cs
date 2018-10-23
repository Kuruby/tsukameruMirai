using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using yumeTakusan.BaseObjects;
using yumeTakusan.Components;

namespace yumeTakusan.Camera
{
    public class Camera:GameProp
    {
        public Camera(CameraViewType ViewType)
        {
            viewType = ViewType;
            physicsComponent = new PhysicsComponent(this);
        }

        CameraViewType viewType;

        PhysicsComponent physicsComponent;


        public override void Update(GameTime gameTime)
        {
            physicsComponent.Update(gameTime);
        }

        public void SwitchViewType(CameraViewType switchTo,bool animateTransition=false)
        {
            //TODO: Add animated transition from one type to the other
            viewType = switchTo;
        }
    }
}
