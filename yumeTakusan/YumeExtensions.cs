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
        public static string HexColor(this Color color)
        {
            return "#" + color.R.ToString("X2") + color.G.ToString("X2") + color.B.ToString("X2") + color.A.ToString("X2");
        }

        public static Color GetColor(this string str)
        {
            str = str.Substring(1);
            byte r = Convert.ToByte(str.Substring(0, 2), 16);
            byte g = Convert.ToByte(str.Substring(2, 2), 16);
            byte b = Convert.ToByte(str.Substring(4, 2), 16);
            byte alpha = Convert.ToByte(str.Substring(6, 2), 16);
            return new Color(r, g, b, alpha);
        }

        public static int GetInt(this string str)
        {
            return int.Parse(str);
        }

        public static void AddAll<T>(this List<T> list, T[] toAdd)
        {
            foreach (T item in toAdd)
            {
                list.Add(item);
            }
        }

        public static Rectangle RectangleAtPoint(this Rectangle rectangle, Vector2 point)=>
            new Rectangle(rectangle.X + (int)point.X, rectangle.Y + (int)point.Y, rectangle.Width, rectangle.Height);
        
    }
}
