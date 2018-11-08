using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using tsukameruCore;

namespace tsukameruMiraiAndroid
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Main : TsukameruGame
    {

        public Main()
        {
            graphics.IsFullScreen = true;
            //Do not set graphics size; tsukameruGame autodetects and will be able to adapt based on this
            graphics.SupportedOrientations = DisplayOrientation.LandscapeLeft | DisplayOrientation.LandscapeRight;
        }

    }
}
