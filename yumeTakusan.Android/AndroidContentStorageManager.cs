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
using Microsoft.Xna.Framework.Input;
using yumeTakusan.ContentManagment;
using Android.Content.Res;

namespace yumeTakusan.Android
{
    /// <summary>
    /// Storage manager for content on android
    /// </summary>
    class AndroidContentStorageManager:ContentStorageManager
    {
        /// <summary>
        /// Creates it with an android assetmanager
        /// </summary>
        /// <param name="Content">Contentmanager for the content in xna</param>
        /// <param name="AssetManager">for loading android content</param>
        public AndroidContentStorageManager(ContentManager Content,AssetManager AssetManager):base(Content)
        {
            assetManager = AssetManager;
        }

        /// <summary>
        /// Assetmanager for loading android content
        /// </summary>
        AssetManager assetManager;

        /// <summary>
        /// Gets all descriptors in the android descriptors file
        /// </summary>
        /// <returns>List of all content descriptors</returns>
        protected override List<Descriptor> GetAllDescriptors()
        {
            string jsonDescriptors = new StreamReader(assetManager.Open("descriptors/descriptors.lmjson")).ReadToEnd();
            return JsonConvert.DeserializeObject<Descriptor[]>($"[{jsonDescriptors}]").ToList();
        }

        /// <summary>
        /// Returns the XML content from a descriptor
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
            object data = xmlSerializer.Deserialize(assetManager.Open("Content" + Path.DirectorySeparatorChar + descriptor.path));

            switch (descriptor.type)
            {
                case "ui":
                    UIStore.Add(descriptor.identifier, (RootNode)data);
                    break;
            }
        }

        /// <summary>
        /// Returns the XNB content from a descriptor
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
