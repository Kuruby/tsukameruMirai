using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using tsukameruCore;
using yumeTakusan.ContentManagment;

namespace tsukameruMirai
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Main : TsukameruGame
    {
        public Main():base()
        {
            content = new DesktopContentStorageManager(Content);
        }
    }
}
