using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yumeTakusan.BaseObjects;

namespace yumeTakusan.Camera
{
    public class Camera:GameObject
    {
        public Camera(CameraViewType ViewType)
        {
            viewType = ViewType;
        }

        CameraViewType viewType;

        public void SwitchViewType(CameraViewType switchTo)
        {
            //add extra fancy transition, maybe?
            viewType = switchTo;
        }
    }
}
