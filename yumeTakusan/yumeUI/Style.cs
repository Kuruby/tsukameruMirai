using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using yumeTakusan.Extensions;

namespace yumeTakusan.yumeUI
{
    /// <summary>
    /// Styling for elements
    /// </summary>
    public struct Style
    {
        /// <summary>
        /// Creates a style
        /// </summary>
        /// <param name="Padding">amount of space inside element before content</param>
        /// <param name="Border">Thickness of border</param>
        /// <param name="Margin">Amount of space outside element</param>
        /// <param name="Position">How the element relates in position to other elements</param>
        /// <param name="Location">Where the element is</param>
        /// <param name="BorderColor">Color of the border</param>
        /// <param name="BackGroundColor">Color of the background</param>
        /// <param name="MainColor">Color for text, etc.</param>
        public Style(int Padding = 0, int Border = 0, int Margin = 0, Positions Position = Positions._relative, Vector2 Location = default,
            Color? BorderColor = default, Color? BackGroundColor = default, Color? MainColor = default)
        {
            padding = Padding;
            border = Border;
            borderColor = (BorderColor ?? Color.Transparent);
            backgroundColor = (BackGroundColor ?? Color.Transparent);
            mainColor = (MainColor ?? Color.White);
            margin = Margin;
            position = Position;
            location = Location;
        }

        /// <summary>
        /// Relation style to other elements
        /// </summary>
        public Positions position;

        /// <summary>
        /// Where the element is
        /// </summary>
        public Vector2 location;

        /// <summary>
        /// Space outside of this element
        /// </summary>
        public int margin;

        /// <summary>
        /// Spacing inside of this element
        /// </summary>
        public int padding;

        /// <summary>
        /// How thick the border is
        /// </summary>
        public int border;

        /// <summary>
        /// Color of the border
        /// </summary>
        public Color borderColor;

        /// <summary>
        /// Background color of the element
        /// </summary>
        public Color backgroundColor;

        /// <summary>
        /// main color of the element for text,e tc
        /// </summary>
        public Color mainColor;


        public int InnerExtra => border * 2 + padding * 2;

        /*/// <summary>
        /// If the element has a border
        /// </summary>
        private bool hasBorder => border > 0;*/

        /*/// <summary>
        /// if the element has padding
        /// </summary>
        private bool hasPadding => padding > 0;*/

        /*/// <summary>
        /// if the element has a margin
        /// </summary>
        private bool hasMargin => margin > 0;*/

        /// <summary>
        /// Creates a style from the string
        /// </summary>
        /// <param name="styleString">String containing a style</param>
        /// <returns>Style specified by the string</returns>
        public Style FromString(string styleString)
        {
            //Turns this Style into the style specified by the string.

            List<string> list = styleString.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            foreach (string item in list)
            {
                string text = item.Split(':')[0];
                string str = item.Split(':')[1];
                switch (text)
                {
                    case "margin":
                        margin = str.GetInt();
                        break;
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
                    case "location":
                        location = str.GetVector2();
                        break;
                    case "position":
                        position = str.GetEnum<Positions>();
                        break;
                }
            }
            return this;

        }

        /// <summary>
        /// Creates a style from a string
        /// </summary>
        /// <param name="styleString">String with style</param>
        /// <returns>Style specified by string</returns>
        public static Style StyleFromString(string styleString)
        {
            return new Style().FromString(styleString);
        }

        /// <summary>
        /// Creates a string from the style
        /// </summary>
        /// <returns>String representing this style</returns>
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
