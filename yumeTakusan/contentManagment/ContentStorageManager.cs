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
    /// <summary>
    /// Stores content in an organized fashion, as well as enables reading it from config files.
    /// </summary>
    public abstract class ContentStorageManager
    {
        /// <summary>
        /// Creates a content storage manager using a content manager
        /// </summary>
        /// <param name="Content"></param>
        public ContentStorageManager(ContentManager Content)
        {
            content = Content;
        }

        /// <summary>
        /// Contentmanager to control loading the content where necessary
        /// </summary>
        protected ContentManager content;

        /// <summary>
        /// String access to all image content
        /// </summary>
        protected Dictionary<string, Texture2D> imageStore = new Dictionary<string, Texture2D>();

        /// <summary>
        /// String access to all the UI windows
        /// </summary>
        protected Dictionary<string, RootNode> UIStore = new Dictionary<string, RootNode>();

        /// <summary>
        /// Returns the content identified by the string and type.
        /// </summary>
        /// <typeparam name="T">Type of content to be returned</typeparam>
        /// <param name="identifier">The name of the content requested</param>
        /// <returns>Requested content</returns>
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
                    throw new NotImplementedException($"theres no such thing as a {type}");
            }
        }

        /// <summary>
        /// gets all the content descriptors
        /// </summary>
        /// <returns></returns>
        protected abstract List<Descriptor> GetAllDescriptors();

        /// <summary>
        /// loads a texture2d from a descriptor
        /// </summary>
        /// <param name="descriptor">Content to load</param>
        protected abstract void GetXnbContentFromDescriptor(Descriptor descriptor);

        /// <summary>
        /// Loads XML content from a descriptor
        /// </summary>
        /// <param name="descriptor">Content to load</param>
        protected abstract void GetXmlContentFromDescriptor(Descriptor descriptor);

        /// <summary>
        /// Loads all content from descriptors
        /// </summary>
        public void LoadAllContent()
        {
            var descriptors = GetAllDescriptors();
            //load content for each descriptor
            foreach (Descriptor descriptor in descriptors)
            {
                LoadContentFromDescriptor(descriptor);
            }
        }

        /// <summary>
        /// Loads content from a descriptor into the correct store
        /// </summary>
        /// <param name="descriptor">Content to load</param>
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
                default:
                    throw new NotImplementedException($"theres no such thing as a {descriptor.datatype}");
            }
        }
    }
}
