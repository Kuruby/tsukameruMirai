using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using yumeTakusan.BaseObjects;
using yumeTakusan.Components;

namespace yumeTakusan.YumeCamera
{
    /// <summary>
    /// Camera is a view of the game world
    /// </summary>
    public class Camera : GameProp
    {
        /// <summary>
        /// Creates a camera with the specified viewtype
        /// </summary>
        /// <param name="ViewType">The type of view</param>
        /// <param name="InitialLocation">Position where the camera is</param>
        public Camera(CameraViewType ViewType, Vector2 InitialLocation = default(Vector2)) : base(InitialLocation)
        {
            viewType = ViewType;
            physicsComponent = new PhysicsComponent(this);

        }

        /// <summary>
        /// The type of view the camera provides
        /// </summary>
        CameraViewType viewType;

        /// <summary>
        /// Physics component for the camera
        /// </summary>
        PhysicsComponent physicsComponent;


        /// <summary>
        /// Updates the camera
        /// </summary>
        /// <param name="gameTime">Timing values</param>
        public override void Update(GameTime gameTime)
        {
            physicsComponent.Update(gameTime);
        }

        /// <summary>
        /// Changes the view type to a different one
        /// </summary>
        /// <param name="switchTo">View type to switch to</param>
        /// <param name="animateTransition">Whether it should be animated</param>
        public void SwitchViewType(CameraViewType switchTo, bool animateTransition = false)
        {
            if (switchTo == viewType)
            {
                //Do nothing if we are already in that view
                return;
            }
            //TODO: Add animated transition from one type to the other
            viewType = switchTo;
        }
    }
}
