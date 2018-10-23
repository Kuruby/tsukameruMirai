using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using yumeTakusan.Extensions;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using yumeUI;

namespace yumeTakusan.ContentManagment
{
    public class ContentStorageManager
    {
        Dictionary<string, Texture2D> images = new Dictionary<string, Texture2D>();
        Dictionary<string, RootNode> UI = new Dictionary<string, RootNode>();
        public ContentStorageManager()
        {

        }

        public void LoadAllContent(ContentManager Content)
        {
            var descriptors = GetAllDescriptors();
            //load content for each descriptor
            foreach (Descriptor descriptor in descriptors)
            {
                //load the content based on what the datatype and what type it is
                //First, check if if is xnb (monogame) or xml/json/other (text) content
            }
        }

        private static List<Descriptor> GetAllDescriptors()
        {
            List<Descriptor> list = new List<Descriptor>();
            //check that the file path exists
            if(!Directory.Exists("descriptors"))
            {
                Directory.CreateDirectory("descriptors");
            }
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
