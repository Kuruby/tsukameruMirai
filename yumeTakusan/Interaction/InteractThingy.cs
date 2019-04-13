using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using yumeTakusan.Input.Patching;

namespace yumeTakusan.Interaction
{
    /// <summary>
    /// interact thingy
    /// needs a better name
    /// </summary>
    public class InteractThingy
    {
        public InteractThingy(Texture2D OnePixelWhiteSquare, MasterInput MasterInput)
        {
            pixel = OnePixelWhiteSquare;
            input = MasterInput;
            //TODO: register handling method for clicks
            MasterInput.AddEventListener(new Event(true), handleClickIntoInteract, 0);
        }

        /// <summary>
        /// Stored input
        /// </summary>
        MasterInput input;

        public bool handleClickIntoInteract(object clickEvent)
        {
            //if the mouse isn't clicked don't care
            if (!Event.IsLeftMouseTriggered(input))
            {
                return false;
            }

            //check for an interaction with every rect
            foreach (InteractRectangle InteractItem in interactItems)
            {
                if (InteractItem.rectangle.Intersects(input.MouseTip))
                {
                    InteractItem.DoAction();
                    return true;
                }
            }
            return false;
        }


        /// <summary>
        /// 1x1 white pixel for drawing rectangles
        /// </summary>
        private Texture2D pixel;

        /// <summary>
        /// The interact items that can be interacted with
        /// </summary>
        private List<InteractRectangle> interactItems = new List<InteractRectangle>();

        /// <summary>
        /// don't want to call this every frame...
        /// </summary>
        public Rectangle[] InteractItems =>
            (from item in interactItems
             select item.rectangle).ToArray();

        /// <summary>
        /// Adds a interact rectangle below all the others.
        /// </summary>
        /// <param name="interactRectangle">interact rectangle to add</param>
        public void AddBelowAll(InteractRectangle interactRectangle)
        {
            interactItems.Add(interactRectangle);

        }


        /// <summary>
        /// Adds an interact rectangle above all others.
        /// </summary>
        /// <param name="interactRectangle">interact rectangle to add</param>
        public void AddAboveAll(InteractRectangle interactRectangle)
        {
            interactItems.Insert(0, interactRectangle);
        }

        /// <summary>
        /// Adds an interact rectangle at a specified index
        /// </summary>
        /// <param name="interactRectangle">interact rectangle to add</param>
        /// <param name="location">index to insert into</param>
        public void AddAt(InteractRectangle interactRectangle, int location)
        {
            interactItems.Insert(location, interactRectangle);
        }

        /// <summary>
        /// Removes an interact rectangle
        /// </summary>
        /// <param name="interactRectangle">rectangle to remove</param>
        public void remove(InteractRectangle interactRectangle)
        {
            interactItems.Remove(interactRectangle);
        }

        /// <summary>
        /// Colours to use for debug drawing of interact thingy
        /// </summary>
        private Color[] drawColors = { Color.MediumPurple, Color.MidnightBlue, Color.PaleVioletRed, Color.GreenYellow };

        /// <summary>
        /// Draws the interact rectangles onscreen
        /// </summary>
        /// <param name="spriteBatch">spritebatch to use to draw</param>
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend, SamplerState.PointClamp);
            int iterator = 0;
            foreach (var interactItem in interactItems)
            {
                spriteBatch.Draw(pixel, interactItem.rectangle, null, drawColors[iterator % drawColors.Length], 0f, Vector2.Zero, SpriteEffects.None, .0001f * iterator);
                iterator++;
            }
            spriteBatch.End();
        }
    }
}
