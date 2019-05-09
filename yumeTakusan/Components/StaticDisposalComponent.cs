using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using yumeTakusan.Interfaces;

namespace yumeTakusan.Components
{
    /// <summary>
    /// Checks and disposes
    /// </summary>
    internal static class StaticDisposalComponent
    {
        /// <summary>
        /// Updates a list of updateable components
        /// </summary>
        /// <typeparam name="T">Type of thing to update</typeparam>
        /// <param name="Ts">List of Ts to update</param>
        /// <param name="gameTime">Timing parameter</param>
        public static void Update<T>(List<T> Ts, GameTime gameTime) where T : IUpdatable
        {
            foreach (T t in Ts)
            {
                t.Update(gameTime);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T">Type to check disposal on</typeparam>
        /// <param name="Ts"></param>
        public static void CheckDispose<T>(List<T> Ts) where T : IDisposalFlag
        {
            List<T> DisposalList = new List<T>();
            foreach (T t in Ts)
            {
                if (t.disposed)
                {
                    DisposalList.Add(t);
                }
            }
            foreach (T t in DisposalList)
            {
                Ts.Remove(t);
            }
        }

        /// <summary>
        /// Checks and disposes Ts marked for disposal
        /// </summary>
        /// <param name="Ts">list to check in</param>
        /// <param name="gameTime">Timing parameter</param>
        public static void UpdateAndCheckDispose<T>(List<T> Ts, GameTime gameTime) where T : IUpdatable, IDisposalFlag
        {
            List<T> DisposalList = new List<T>();
            foreach (T t in Ts)
            {
                t.Update(gameTime);
                if (t.disposed)
                {
                    DisposalList.Add(t);
                }
            }
            foreach (T t in DisposalList)
            {
                Ts.Remove(t);
            }
        }
    }
}
