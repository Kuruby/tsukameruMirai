using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yumeTakusan;

namespace yumeTakusan.Desktop
{
    public class YumeGameDesktop:YumeGame
    {
        /// <summary>
        /// Creates a yumeGame for desktop, with appropriate content storage management
        /// </summary>
        public YumeGameDesktop() : base()
        {
            content = new DesktopContentStorageManager(Content);
        }
    }
}
