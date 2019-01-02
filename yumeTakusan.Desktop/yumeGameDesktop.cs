using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yumeTakusan;

namespace yumeTakusan.Desktop
{
    public class yumeGameDesktop:yumeGame
    {
        /// <summary>
        /// Creates a yumeGame for desktop, with appropriate content storage management
        /// </summary>
        public yumeGameDesktop() : base()
        {
            content = new DesktopContentStorageManager(Content);
        }
    }
}
