using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using Newtonsoft.Json;
using yumeTakusan.Extensions;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using yumeTakusan.yumeUI;
using System.Xml.Serialization;

namespace yumeTakusan.ContentManagment
{
    public abstract class ContentStorageManager
    {
        public ContentStorageManager(ContentManager Content)
        {
            content = Content;
        }

        protected ContentManager content;

        protected Dictionary<string, Texture2D> imageStore = new Dictionary<string, Texture2D>();
        protected Dictionary<string, RootNode> UIStore = new Dictionary<string, RootNode>();

        public object getContent<T>(string identifier)
        {
            string type = typeof(T).ToString();
            switch (type)
            {
                case "Microsoft.Xna.Framework.Graphics.Texture2D":
                    return imageStore[identifier];
                case "yumeTakusan.yumeUI.RootNode":
                    return UIStore[identifier];
                default:
                    throw new Exception($"theres no such thing as a {type}");
            }
        }

        protected abstract List<Descriptor> GetAllDescriptors();

        protected abstract void GetXnbContentFromDescriptor(Descriptor descriptor);

        protected abstract void GetXmlContentFromDescriptor(Descriptor descriptor);

        public void LoadAllContent()
        {
            var descriptors = GetAllDescriptors();
            //load content for each descriptor
            foreach (Descriptor descriptor in descriptors)
            {
                LoadContentFromDescriptor(descriptor);
            }
        }

        protected void LoadContentFromDescriptor(Descriptor descriptor)
        { //load the content based on what the datatype and what type it is
          //First, check if if is xnb (monogame) or xml/json/other (text) content
            switch (descriptor.datatype)
            {
                case "xml"://Mostly UI: templated, lang data is set on ui creation
                    GetXmlContentFromDescriptor(descriptor);
                    break;
                case "xnb"://Various types wrapped in Monogame/XNA's content wrapper
                    GetXnbContentFromDescriptor(descriptor);
                    break;
                case "json":
                    throw new NotImplementedException("json support not yet added");
                case "text":
                    throw new NotImplementedException("text support not yet added");
            }
        }
    }
}
