﻿using System;
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
        protected override List<Descriptor> GetAllDescriptors()
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
        protected override void GetXmlContentFromDescriptor(Descriptor descriptor)
        {
            if (descriptor.datatype != "xml")
                throw new InvalidOperationException("bad datatype");

            Type type = typeof(object);
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

        /// <summary>
        /// Gets XNB content from a descriptor
        /// </summary>
        /// <param name="descriptor">Descriptor to get content from</param>
        protected override void GetXnbContentFromDescriptor(Descriptor descriptor)
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
