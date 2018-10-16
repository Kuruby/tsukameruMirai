using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using yumeTakusan.yumeExtensions;

namespace yumeUI
{
    public struct Style
    {
        public Style(int Padding = 0, int Border = 0, Color? BorderColor = default(Color?),
            Color? BackGroundColor = default(Color?), Color? MainColor = default(Color?))
        {
            padding = Padding;
            border = Border;
            borderColor = (BorderColor ?? Color.Transparent);
            backgroundColor = (BackGroundColor ?? Color.Transparent);
            mainColor = (MainColor ?? Color.White);
        }

        public int padding;

        public int border;

        public Color borderColor;

        public Color backgroundColor;

        public Color mainColor;

        private bool hasBorder => border > 0;

        public Style FromString(string styleString)
        {
            //Turns this Style into the style specified by the string.

            List<string> list = styleString.Split(new char[]{ ';' },StringSplitOptions.RemoveEmptyEntries).ToList();
            foreach (string item in list)
            {
                string text = item.Split(':')[0];
                string str = item.Split(':')[1];
                switch (text)
                {
                    case "padding":
                        padding = str.GetInt();
                        break;
                    case "border":
                        border = str.GetInt();
                        break;
                    case "border-color":
                        borderColor = str.GetColor();
                        break;
                    case "background-color":
                        backgroundColor = str.GetColor();
                        break;
                    case "color":
                        mainColor = str.GetColor();
                        break;
                }
            }
            return this;

        }
        public static Style StyleFromString(string styleString)
        {
            return new Style().FromString(styleString);
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (padding != 0)
            {
                stringBuilder.Append($"padding:{padding};");
            }
            if (border != 0)
            {
                stringBuilder.Append($"border:{border};");
            }
            if (borderColor != Color.Transparent)
            {
                stringBuilder.Append("border-color:" + borderColor.HexColor() + ";");
            }
            if (backgroundColor != Color.Transparent)
            {
                stringBuilder.Append("background-color:" + backgroundColor.HexColor() + ";");
            }
            if (mainColor != Color.White)
            {
                stringBuilder.Append("color:" + mainColor.HexColor() + ";");
            }
            return stringBuilder.ToString();
        }
    }
}
