using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace yumeTakusan.Interfaces
{
    public interface IAnimatable : IDrawable
    {
        Rectangle frameLocation { get; set; }
        int frameHeight { get; }
        int frameWidth { get; }
        int verticalFrameNumber { get; }
        int horizontalFrameNumber { get; }
    }
}
