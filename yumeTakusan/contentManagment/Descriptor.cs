using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yumeTakusan.ContentManagment
{
    public struct Descriptor
    {
        public string datatype;

        public string type;

        public string path;

        public string identifier;
        
        public string locale;


        public Descriptor(string Datatype, string Type, string Path, string Identifier, string Locale = null)
        {
            datatype = Datatype;
            type = Type;
            path = Path;
            identifier = Identifier;
            locale = Locale ?? "neutral";
        }
    }

}
