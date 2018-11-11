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
        public yumeGameDesktop() : base()
        {
            content = new DesktopContentStorageManager(Content);
        }
    }
}
