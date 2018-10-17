using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yumeTakusan.contentManagment
{
    public struct Descriptor
    {
        private string datatype;

        private string type;

        private string path;

        private string identifier;

        public Descriptor(string Datatype, string Type, string Path, string Identifier)
        {
            datatype = Datatype;
            type = Type;
            path = Path;
            identifier = Identifier;
        }
    }

}
