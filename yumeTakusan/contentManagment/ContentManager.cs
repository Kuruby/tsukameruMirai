using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using yumeTakusan.yumeExtensions;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using yumeUI;

namespace yumeTakusan.contentManagment
{
    public class ContentManager
    {
        Dictionary<string, Texture2D> images = new Dictionary<string, Texture2D>();
        Dictionary<string, RootNode> UI = new Dictionary<string, RootNode>();
        public ContentManager()
        {

        }

        public void LoadAllContent()
        {
            var descriptors = getAllDescriptors();
            //load content for each descriptor
            foreach (Descriptor descriptor in descriptors)
            {
                //load the content based on what the datatype and what type it is
                //First, check if if is xnb (monogame) or xml/json/other (text) content
            }
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
