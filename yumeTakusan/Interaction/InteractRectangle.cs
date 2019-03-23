using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using yumeTakusan.Events;

namespace yumeTakusan.Interaction
{
    /// <summary>
    /// A rectangle for  user interaction
    /// </summary>
    public class InteractRectangle
    {
        /// <summary>
        /// Create a interactrectangle using rectangle parameters
        /// </summary>
        /// <param name="x">x location of rectangle</param>
        /// <param name="y">y location of rectangle</param>
        /// <param name="width">width of rectangle</param>
        /// <param name="height">height of rectangle</param>
        public InteractRectangle(int x, int y, int width, int height) : this(new Rectangle(x, y, width, height))
        { }

        /// <summary>
        /// Create a interactrectangle using rectangle parameters an a event
        /// </summary>
        /// <param name="x">x location of rectangle</param>
        /// <param name="y">y location of rectangle</param>
        /// <param name="width">width of rectangle</param>
        /// <param name="height">height of rectangle</param>
        /// <param name="eventHandler">Event called on click</param>
        public InteractRectangle(int x, int y, int width, int height, YTEventHandler eventHandler) : this(new Rectangle(x, y, width, height), eventHandler)
        { }

        /// <summary>
        /// create an interactrectangle using a rectangle
        /// </summary>
        /// <param name="rectangle">rectangle to create an interact rectangle from</param>
        public InteractRectangle(Rectangle rectangle)
        {
            this.rectangle = rectangle;
        }

        /// <summary>
        /// Create an interactrectangle using a rectangle and an event
        /// </summary>
        /// <param name="rectangle">rectangle to create an interactrectangle from</param>
        /// <param name="eventHandler">Event called on click</param>
        public InteractRectangle(Rectangle rectangle, YTEventHandler eventHandler)
        {
            this.rectangle = rectangle;
            Action += eventHandler;
        }
        /// <summary>
        /// The (onscreen) location of the interact rectangle
        /// </summary>
        public Rectangle rectangle { get; private set; }

        /// <summary>
        /// Event for handling the interact rectangle being clicked
        /// </summary>
        public event YTEventHandler Action = delegate { };

    }
}
