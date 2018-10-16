using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using yumeTakusan.yumeExtensions;

namespace yumeTakusan.contentManagment
{
    class ContentManager
    {
        public ContentManager()
        {

        }

        private static List<Descriptor> getAllDescriptors()
        {
            List<Descriptor> list = new List<Descriptor>();
            string[] descriptorFilePaths = Directory.GetFiles("descriptors", "*.lmjson", SearchOption.AllDirectories);
            foreach (string path in descriptorFilePaths)
            {
                string str = File.ReadAllText(path);
                list.AddAll(JsonConvert.DeserializeObject<Descriptor[]>($"[{str}]"));
            }
            return list;
        }
    }
}
