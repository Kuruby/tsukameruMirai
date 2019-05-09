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
        /// Stores all content
        /// </summary>
        protected Dictionary<string, Content> contentStore = new Dictionary<string, Content>();



        /// <summary>
        /// Returns the content identified by the string
        /// </summary>
        /// <param name="identifier">The name of the content requested</param>
        /// <returns>Requested content</returns>
        public object GetContent(string identifier)
        {
            return contentStore[identifier]._Content;
        }

        /// <summary>
        /// Gets all content that has a certain tag
        /// </summary>
        /// <typeparam name="T">Type of the content that has it</typeparam>
        /// <param name="tag">The tag requested</param>
        /// <returns>Requested content</returns>
        public object[] GetTaggedContent<T>(string tag)
        {
            var TaggedContent = from keyValuePair in contentStore
                                where keyValuePair.Value.Tags.Contains(tag)
                                where keyValuePair.Value.T == typeof(T)
                                select keyValuePair.Value._Content;
            return TaggedContent.ToArray();
        }

        public Content[] GetTaggedContentWithMetadata<T>(string tag)
        {
            var TaggedContent = from keyValuePair in contentStore
                                where keyValuePair.Value.Tags.Contains(tag)
                                where keyValuePair.Value.T == typeof(T)
                                select keyValuePair.Value;
            return TaggedContent.ToArray();
        }

        /// <summary>
        /// gets all the content descriptors
        /// </summary>
        /// <returns></returns>
        protected abstract List<Descriptor> getAllDescriptors();

        /// <summary>
        /// loads a texture2d from a descriptor
        /// </summary>
        /// <param name="descriptor">Content to load</param>
        protected abstract Content getXnbContentFromDescriptor(Descriptor descriptor);

        /// <summary>
        /// Loads XML content from a descriptor
        /// </summary>
        /// <param name="descriptor">Content to load</param>
        protected abstract Content getXmlContentFromDescriptor(Descriptor descriptor);

        /// <summary>
        /// Gets XNB content from a descriptor
        /// </summary>
        /// <param name="descriptor">Descriptor to get content from</param>
        protected abstract Content getXmlUIContentFromDescriptor(Descriptor descriptor);

        /// <summary>
        /// Loads all content from descriptors
        /// </summary>
        public void LoadAllContent()
        {
            var descriptors = getAllDescriptors();
            //load content for each descriptor
            foreach (Descriptor descriptor in descriptors)
            {
                loadContentFromDescriptor(descriptor);
            }
        }

        /// <summary>
        /// Loads content from a descriptor into the correct store
        /// </summary>
        /// <param name="descriptor">Content to load</param>
        protected void loadContentFromDescriptor(Descriptor descriptor)
        { //load the content based on what the datatype and what type it is
          //First, check if if is xnb (monogame) or xml/json/other (text) content
            switch (descriptor.Datatype)
            {
                case "xml":
                    contentStore.Add(descriptor.Identifier, getXmlContentFromDescriptor(descriptor));
                    break;
                case "xmlui"://this is ui
                    contentStore.Add(descriptor.Identifier, getXmlUIContentFromDescriptor(descriptor));
                    break;
                case "xnb"://Various types wrapped in Monogame/XNA's content wrapper
                    contentStore.Add(descriptor.Identifier, getXnbContentFromDescriptor(descriptor));
                    break;
                case "json":
                    throw new NotImplementedException("json support not yet added");
                case "text":
                    throw new NotImplementedException("text support not yet added");
                default:
                    throw new NotImplementedException($"theres no such thing as a {descriptor.Datatype}");
            }
        }
    }
}
