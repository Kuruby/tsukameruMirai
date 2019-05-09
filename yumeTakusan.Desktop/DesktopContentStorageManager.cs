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
using yumeTakusan.ContentManagment;

namespace yumeTakusan.Desktop
{
    /// <summary>
    /// Stores content using methods specifically do desktop
    /// </summary>
    public sealed class DesktopContentStorageManager : ContentStorageManager
    {
        /// <summary>
        /// Create a desktop storage manager
        /// </summary>
        /// <param name="Content"></param>
        public DesktopContentStorageManager(ContentManager Content) : base(Content) { }


        /// <summary>
        /// Gets all descriptors in the /descriptors/ folder and subfolders
        /// </summary>
        /// <returns>List of descriptors in the descriptors folder</returns>
        protected override List<Descriptor> getAllDescriptors()
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

        /// <summary>
        /// Gets XML content from a descriptor
        /// </summary>
        /// <param name="descriptor">Descriptor to get content from</param>
        protected override Content getXmlContentFromDescriptor(Descriptor descriptor)
        {
            if (descriptor.Datatype != "xml")
                throw new InvalidOperationException("bad datatype");

            Type type = typeof(void);
            switch (descriptor.Type)
            {
                case "ui":
                    type = typeof(RootNode);
                    //special UI serialization?
                    break;
                default:
                    throw new NotImplementedException($"Theres no such thing as a {descriptor.Type}");
            }

            XmlSerializer xmlSerializer = new XmlSerializer(type);
            object data = xmlSerializer.Deserialize(new FileStream("Content" + Path.DirectorySeparatorChar + descriptor.Path, FileMode.Open));

            return new Content(type, data, descriptor.Identifier, descriptor.Tags);
        }

        /// <summary>
        /// Gets a UI from a descriptor
        /// </summary>
        /// <param name="descriptor">Descriptor for UI</param>
        /// <returns>UI indicated by descriptor</returns>
        protected override Content getXmlUIContentFromDescriptor(Descriptor descriptor)
        {
            if (descriptor.Datatype != "xmlui" || descriptor.Type != "ui")
                throw new InvalidOperationException("bad datatype");
            return new Content(typeof(RootNode),
                RootNode.DeSerialize(File.ReadAllText("Content" + Path.DirectorySeparatorChar + descriptor.Path)),
                descriptor.Identifier,
                descriptor.Tags);
        }

        /// <summary>
        /// Gets XNB content from a descriptor
        /// </summary>
        /// <param name="descriptor">Descriptor to get content from</param>
        protected override Content getXnbContentFromDescriptor(Descriptor descriptor)
        {
            if (descriptor.Datatype != "xnb")
                throw new InvalidOperationException("bad datatype");

            string path = descriptor.Path;

            if (path.EndsWith(".xnb"))
                path = path.Substring(0, path.Length - 4);

            Type type = typeof(void);
            object data = null;
            switch (descriptor.Type)
            {
                case "tex2d":
                    type = typeof(Texture2D);
                    data = content.Load<Texture2D>(path);
                    break;
                default:
                    throw new NotImplementedException($"Theres no such thing as a {descriptor.Type}");
            }
            return new Content(type, data, descriptor.Identifier, descriptor.Tags);

        }
    }
}
