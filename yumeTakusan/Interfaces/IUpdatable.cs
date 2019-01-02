using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace yumeTakusan.Interfaces
{
    /// <summary>
    /// Is able to update
    /// </summary>
    interface IUpdatable
    {
        /// <summary>
        /// Update something about object
        /// </summary>
        /// <param name="gameTime">Timing values</param>
        void Update(GameTime gameTime);
    }
}
