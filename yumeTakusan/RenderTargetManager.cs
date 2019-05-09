using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace yumeTakusan
{
    /// <summary>
    /// Manages render targets
    /// </summary>
    public static class RenderTargetManager
    {
        /// <summary>
        /// Graphics device for switching and creating render targets
        /// </summary>
        public static GraphicsDevice graphicsDevice { get; private set; }


        public static RenderTarget2D currentRenderTarget = null;

        private readonly static LinkedList<RenderTarget2D> renderTargetStack = new LinkedList<RenderTarget2D>();

        /// <summary>
        /// Sets up the graphics device
        /// </summary>
        /// <param name="device"></param>
        public static void Initialize(GraphicsDevice device)
        {
            graphicsDevice = device;
        }

        private static void setTarget(RenderTarget2D target)
        {
            graphicsDevice.SetRenderTarget(target);
            currentRenderTarget = target;
        }
        public static RenderTarget2D createAndSetScreenSizeTarget()
        {
            RenderTarget2D target = new RenderTarget2D(graphicsDevice, windowDimensions.Width, windowDimensions.Height);
            renderTargetStack.AddFirst(target);
            setTarget(target);
            return target;
        }
        public static RenderTarget2D createAndSetTarget(int width, int height)
        {
            RenderTarget2D target = new RenderTarget2D(graphicsDevice, width, height);
            renderTargetStack.AddFirst(target);
            setTarget(target);
            return target;
        }

        public static void setRenderTarget(RenderTarget2D target)
        {
            renderTargetStack.AddFirst(target);
            setTarget(target);
        }



        public static RenderTarget2D PopRenderTarget()
        {
            if (renderTargetStack.Count == 0)
            {
                return null;
            }
            RenderTarget2D target = renderTargetStack.First();
            unsetRenderTarget();
            return target;
        }

        public static void unsetRenderTarget()
        {
            if (renderTargetStack.Count <= 1)
            {
                if (renderTargetStack.Count == 1)
                    renderTargetStack.RemoveFirst();
                setTarget(null);
            }
            else
            {
                renderTargetStack.RemoveFirst();
                setTarget(renderTargetStack.First());
            }
        }

        public static Rectangle windowDimensions { get; set; }
    }
}
