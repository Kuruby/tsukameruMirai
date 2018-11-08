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
using System.Xml.Serialization;

namespace yumeTakusan.ContentManagment
{
    public class ContentStorageManager
    {
        private Dictionary<string, Texture2D> imageStore = new Dictionary<string, Texture2D>();
        private Dictionary<string, RootNode> UIStore = new Dictionary<string, RootNode>();


        public ContentStorageManager()
        {

        }


        public void LoadAllContent(ContentManager Content)
        {
            var descriptors = GetAllDescriptors();
            //load content for each descriptor
            foreach (Descriptor descriptor in descriptors)
            {
                LoadContentFromDescriptor(descriptor, Content);

            }
        }



        private static List<Descriptor> GetAllDescriptors()
        {
            List<Descriptor> list = new List<Descriptor>();
            //check that the file path exists
            if (!Directory.Exists("descriptors"))
            {
                Directory.CreateDirectory("descriptors");
            }

            string[] jsonDescriptorFilePaths = Directory.GetFiles("descriptors", "*.json", SearchOption.AllDirectories);
            string[] lmjsonDescriptorFilePaths = Directory.GetFiles("descriptors", "*.lmjson", SearchOption.AllDirectories);

            List<string> descriptorFilePaths = new List<string>();
            descriptorFilePaths.AddAll(jsonDescriptorFilePaths);
            descriptorFilePaths.AddAll(lmjsonDescriptorFilePaths);

            foreach (string path in descriptorFilePaths)
            {
                string str = File.ReadAllText(path);
                list.AddAll(JsonConvert.DeserializeObject<Descriptor[]>($"[{str}]"));
            }
            return list;
        }


        private void LoadContentFromDescriptor(Descriptor descriptor, ContentManager content)
        { //load the content based on what the datatype and what type it is
          //First, check if if is xnb (monogame) or xml/json/other (text) content
            switch ((string)descriptor.datatype)
            {
                case "xml"://Mostly UI: templated, lang data is set on ui creation
                    GetXmlContentFromDescriptor(descriptor);
                    break;
                case "xnb"://Various types wrapped in Monogame/XNA's content wrapper
                    GetXnbContentFromDescriptor(descriptor, content);
                    break;
                case "json":
                    throw new NotImplementedException("json support not yet added");
                case "text":
                    throw new NotImplementedException("text support not yet added");
            }
        }


        private void GetXmlContentFromDescriptor(Descriptor descriptor)
        {
            if (descriptor.datatype != "xml")
                throw new InvalidOperationException("bad datatype");

            Type type = typeof(Object);
            switch (descriptor.type)
            {
                case "ui":
                    type = typeof(RootNode);
                    break;
            }
            XmlSerializer xmlSerializer = new XmlSerializer(type);
            object data = xmlSerializer.Deserialize(new FileStream("Content" + Path.DirectorySeparatorChar + descriptor.path, FileMode.Open));
            switch (descriptor.type)
            {
                case "ui":
                    UIStore.Add(descriptor.identifier, (RootNode)data);
                    break;
            }
        }


        private void GetXnbContentFromDescriptor(Descriptor descriptor, ContentManager content)
        {
            if (descriptor.datatype != "xnb")
                throw new InvalidOperationException("bad datatype");

            string path = descriptor.path;

            if (path.EndsWith(".xnb"))
                path = path.Substring(0, path.Length - 4);

            switch (descriptor.type)
            {
                case "tex2d":
                    Texture2D texture = content.Load<Texture2D>(path);
                    //store
                    imageStore.Add(descriptor.identifier, texture);
                    break;
            }


        }
    }
}
