using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yumeTakusan.contentManagment
{
    public struct Descriptor
    {
        private string type;

        private string store;

        private string path;

        private string identifier;

        public Descriptor(string Type, string Store, string Path, string Identifier)
        {
            type = Type;
            store = Store;
            path = Path;
            identifier = Identifier;
        }
    }

}
