using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using yumeTakusan;

namespace yumeTakusan.Android
{
    public class yumeGameAndroid:yumeGame
    {
        public yumeGameAndroid() : base()
        {
            graphics.IsFullScreen = true;
            //Do not set graphics size; tsukameruGame autodetects and will be able to adapt based on this
            graphics.SupportedOrientations = DisplayOrientation.LandscapeLeft | DisplayOrientation.LandscapeRight;
            content = new AndroidContentStorageManager(Content, Activity.Assets);
        }
    }
}