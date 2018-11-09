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
using yumeUI;
using System.Xml.Serialization;
using Microsoft.Xna.Framework.Input;
using yumeTakusan.ContentManagment;
using Android.Content.Res;

namespace tsukameruMiraiAndroid
{

    class AndroidContentStorageManager:ContentStorageManager
    {
        public AndroidContentStorageManager(ContentManager Content,AssetManager AssetManager):base(Content)
        {
            assetManager = AssetManager;
        }

        AssetManager assetManager;


        protected override List<Descriptor> GetAllDescriptors()
        {
            string jsonDescriptors = new StreamReader(assetManager.Open("descriptors/descriptors.lmjson")).ReadToEnd();
            return JsonConvert.DeserializeObject<Descriptor[]>($"[{jsonDescriptors}]").ToList();
        }

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
