using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace yumeTakusan.Extensions
{
    public static class YumeExtensions
    {
        /// <summary>
        /// Creates a hex string from a colour
        /// </summary>
        /// <param name="color">Colour to convert</param>
        /// <returns>Hex string</returns>
        public static string HexColor(this Color color)
        {
            return "#" + color.R.ToString("X2") + color.G.ToString("X2") + color.B.ToString("X2") + color.A.ToString("X2");
        }

        /// <summary>
        /// Gets a colour from a hex string
        /// </summary>
        /// <param name="str">Hex colour string</param>
        /// <returns>Color in the hex</returns>
        public static Color GetColor(this string str)
        {
            if (str.StartsWith("#"))
            {
                str = str.Substring(1);
            }

            byte r = Convert.ToByte(str.Substring(0, 2), 16);
            byte g = Convert.ToByte(str.Substring(2, 2), 16);
            byte b = Convert.ToByte(str.Substring(4, 2), 16);
            byte alpha = Convert.ToByte(str.Substring(6, 2), 16);
            return new Color(r, g, b, alpha);
        }

        /// <summary>
        /// parses string to int
        /// </summary>
        /// <param name="str">string with int</param>
        /// <returns>int in string</returns>
        public static int GetInt(this string str)
        {
            return int.Parse(str);
        }

        /// <summary>
        /// Parses string to vector2
        /// </summary>
        /// <param name="str">String containing vector2</param>
        /// <returns>Vector2 in the string</returns>
        public static Vector2 GetVector2(this string str)
        {
            var components = str.Split(',');
            return new Vector2(int.Parse(components[0]), int.Parse(components[1]));
        }

        /// <summary>
        /// Gets an enum from a string
        /// </summary>
        /// <typeparam name="T">Type of enum to extract</typeparam>
        /// <param name="str">String to convert</param>
        /// <returns>Enum value for the string</returns>
        public static T GetEnum<T>(this string str)
        {
            return (T)Enum.Parse(typeof(T), str);
        }

        /// <summary>
        /// Adds all elements from an array to a list
        /// </summary>
        /// <typeparam name="T">Type of list and array</typeparam>
        /// <param name="list">List to add elements to</param>
        /// <param name="toAdd">Array of elements to add</param>
        public static void AddAll<T>(this List<T> list, T[] toAdd)
        {
            foreach (T item in toAdd)
            {
                list.Add(item);
            }
        }

        /// <summary>
        /// Gets a rectangle at a certain point
        /// </summary>
        /// <param name="rectangle">Rectangle to move to point</param>
        /// <param name="point">Point at which to put rectangle</param>
        /// <returns></returns>
        public static Rectangle RectangleAtPoint(this Rectangle rectangle, Vector2 point) =>
            new Rectangle(rectangle.X + (int)point.X, rectangle.Y + (int)point.Y, rectangle.Width, rectangle.Height);

    }
}
