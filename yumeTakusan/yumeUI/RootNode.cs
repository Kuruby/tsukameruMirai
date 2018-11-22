﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using System.Xml.Serialization;
using System.IO;
using Microsoft.Xna.Framework.Graphics;

namespace yumeTakusan.yumeUI
{
    [XmlRoot("root")]
    public class RootNode
    {
        [XmlElement]
        public ElementNode node;

        [XmlAttribute("style")]
        private Style style = new Style(5,0,0,Positions._static);

        [XmlAttribute("style")]
        public string styleString
        {
            get
            {
                return style.ToString();
            }
            set
            {
                style = style.FromString(value);
            }
        }

        [XmlIgnore]
        public static Texture2D pixel;

        public RootNode()
        {
            node = new ElementNode(style);
        }

        public string Serialize()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(RootNode));
            StringWriter stringWriter = new StringWriter();
            xmlSerializer.Serialize(stringWriter, this);
            return stringWriter.ToString();
        }


        public static RootNode DeSerialize(string xml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(RootNode));
            return (RootNode)xmlSerializer.Deserialize(new MemoryStream(Encoding.Unicode.GetBytes("\ufeff" + xml)));
        }

        public void Draw(GameTime gameTime,SpriteBatch spriteBatch)
        {
            
        }
    }
}
