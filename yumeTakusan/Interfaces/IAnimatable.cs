using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace yumeTakusan.Interfaces
{
    /// <summary>
    /// Interface for animatable objects
    /// </summary>
    public interface IAnimatable : IDrawable
    {
        /// <summary>
        /// Location of the frame on the spritesheet
        /// </summary>
        Rectangle frameLocation { get; set; }
        /// <summary>
        /// Height of one frame on the spritesheet
        /// </summary>
        int frameHeight { get; }
        /// <summary>
        /// Width of one frame on the spritesheet
        /// </summary>
        int frameWidth { get; }
        /// <summary>
        /// The number of the frame vertically (zero-indexed)
        /// </summary>
        int verticalFrameNumber { get; }
        /// <summary>
        /// The number of the frame horizontally (zero-indexed)
        /// </summary>
        int horizontalFrameNumber { get; }
    }
}
