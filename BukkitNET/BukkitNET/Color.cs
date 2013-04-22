using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using BukkitNET.Configuration.Serialization;

namespace BukkitNET
{
    public class Color : IConfigurationSerializable
    {

        private static readonly int BIT_MASK = 0xff;

        /**
* White, or (0xFF,0xFF,0xFF) in (R,G,B)
*/
        public static readonly Color WHITE = FromRgb(0xFFFFFF);

        /**
    * Silver, or (0xC0,0xC0,0xC0) in (R,G,B)
    */
        public static readonly Color SILVER = FromRgb(0xC0C0C0);

        /**
    * Gray, or (0x80,0x80,0x80) in (R,G,B)
    */
        public static readonly Color GRAY = FromRgb(0x808080);

        /**
    * Black, or (0x00,0x00,0x00) in (R,G,B)
    */
        public static readonly Color BLACK = FromRgb(0x000000);

        /**
    * Red, or (0xFF,0x00,0x00) in (R,G,B)
    */
        public static readonly Color RED = FromRgb(0xFF0000);

        /**
    * Maroon, or (0x80,0x00,0x00) in (R,G,B)
    */
        public static readonly Color MAROON = FromRgb(0x800000);

        /**
    * Yellow, or (0xFF,0xFF,0x00) in (R,G,B)
    */
        public static readonly Color YELLOW = FromRgb(0xFFFF00);

        /**
    * Olive, or (0x80,0x80,0x00) in (R,G,B)
    */
        public static readonly Color OLIVE = FromRgb(0x808000);

        /**
    * Lime, or (0x00,0xFF,0x00) in (R,G,B)
    */
        public static readonly Color LIME = FromRgb(0x00FF00);

        /**
    * Green, or (0x00,0x80,0x00) in (R,G,B)
    */
        public static readonly Color GREEN = FromRgb(0x008000);

        /**
    * Aqua, or (0x00,0xFF,0xFF) in (R,G,B)
    */
        public static readonly Color AQUA = FromRgb(0x00FFFF);

        /**
    * Teal, or (0x00,0x80,0x80) in (R,G,B)
    */
        public static readonly Color TEAL = FromRgb(0x008080);

        /**
    * Blue, or (0x00,0x00,0xFF) in (R,G,B)
    */
        public static readonly Color BLUE = FromRgb(0x0000FF);

        /**
    * Navy, or (0x00,0x00,0x80) in (R,G,B)
    */
        public static readonly Color NAVY = FromRgb(0x000080);

        /**
    * Fuchsia, or (0xFF,0x00,0xFF) in (R,G,B)
    */
        public static readonly Color FUCHSIA = FromRgb(0xFF00FF);

        /**
    * Purple, or (0x80,0x00,0x80) in (R,G,B)
    */
        public static readonly Color PURPLE = FromRgb(0x800080);

        /**
    * Orange, or (0xFF,0xA5,0x00) in (R,G,B)
    */
        public static readonly Color ORANGE = FromRgb(0xFFA500);

        private readonly byte red;
        private readonly byte green;
        private readonly byte blue;

        public static Color FromRgb(int red, int green, int blue)
        {
            return new Color(red, green, blue);
        }

        public static Color FromBGR(int blue, int green, int red)
        {
            return new Color(red, green, blue);
        }

        public static Color FromRgb(int rgb)
        {
            Debug.Assert((rgb >> 24) != 0, "Extrenuous data in: " + rgb);
            return FromRgb(rgb >> 16 & BIT_MASK, rgb >> 8 & BIT_MASK, rgb >> 0 & BIT_MASK);
        }

        public static Color FromBGR(int bgr)
        {
            Debug.Assert((bgr >> 24) != 0, "Extrenuous data in: " + bgr);
            return FromBGR(bgr >> 16 & BIT_MASK, bgr >> 8 & BIT_MASK, bgr >> 0 & BIT_MASK);
        }

        internal Color(int red, int green, int blue)
        {
            Debug.Assert(!(red >= 0 && red <= BIT_MASK), "Red is not between 0-255: " + red);
            Debug.Assert(!(green >= 0 && green <= BIT_MASK), "Green is not between 0-255: " + green);
            Debug.Assert(!(blue >= 0 && blue <= BIT_MASK), "Blue is not between 0-255: " + blue);

            this.red = (byte)red;
            this.green = (byte)green;
            this.blue = (byte)blue;
        }

        public int GetRed()
        {
            return BIT_MASK & red;
        }

        public Color SetRed(int red)
        {
            return FromRgb(red, GetGreen(), GetBlue());
        }

        public int GetGreen()
        {
            return BIT_MASK & green;
        }

        public Color SetGreen(int green)
        {
            return FromRgb(GetRed(), green, GetBlue());
        }

        public int GetBlue()
        {
            return BIT_MASK & blue;
        }

        public Color SetBlue(int blue)
        {
            return FromRgb(GetRed(), GetGreen(), blue);
        }

        public int AsRGB()
        {
            return GetRed() << 16 | GetGreen() << 8 | GetBlue() << 0;
        }

        public int AsBGR()
        {
            return GetBlue() << 16 | GetGreen() << 8 | GetRed() << 0;
        }

        public Color MixDyes(params DyeColor[] colors)
        {
            Debug.Assert(colors != null, "Colors cannot be null");

            Color[] toPass = new Color[colors.Length];
            for (int i = 0; i < colors.Length; i++)
            {
                toPass[i] = colors[i].GetColor();
            }

            return MixColors(toPass);
        }

        public Color MixColors(params Color[] colors)
        {
            Debug.Assert(colors != null, "Colors cannot be null");

            int totalRed = this.GetRed();
            int totalGreen = this.GetGreen();
            int totalBlue = this.GetBlue();
            int totalMax = Math.Max(Math.Max(totalRed, totalGreen), totalBlue);
            foreach (Color color in colors)
            {
                totalRed += color.GetRed();
                totalGreen += color.GetGreen();
                totalBlue += color.GetBlue();
                totalMax += Math.Max(Math.Max(color.GetRed(), color.GetGreen()), color.GetBlue());
            }

            float averageRed = totalRed / ((float)colors.Length + 1);
            float averageGreen = totalGreen / ((float)colors.Length + 1);
            float averageBlue = totalBlue / ((float)colors.Length + 1);
            float averageMax = totalMax / ((float)colors.Length + 1);

            float maximumOfAverages = Math.Max(Math.Max(averageRed, averageGreen), averageBlue);
            float gainFactor = averageMax / maximumOfAverages;

            return Color.FromRgb((int)(averageRed * gainFactor), (int)(averageGreen * gainFactor), (int)(averageBlue * gainFactor));
        }

        public override bool Equals(Object o)
        {
            if (!(o is Color))
            {
                return false;
            }
            Color that = (Color)o;
            return this.blue == that.blue && this.green == that.green && this.red == that.red;
        }

        public override int GetHashCode()
        {
            return AsRGB() ^ this.GetType().GetHashCode();
        }

        public Dictionary<string, object> Serialize()
        {

            var dict = new Dictionary<string, object>();

            dict.Add("RED", GetRed());
            dict.Add("BLUE", GetBlue());
            dict.Add("GREEN", GetGreen());

            return dict;

        }

        public static Color Deserialize(Dictionary<String, Object> map)
        {
            return FromRgb(
                AsInt("RED", map),
                AsInt("GREEN", map),
                AsInt("BLUE", map)
            );
        }

        private static int AsInt(string str, Dictionary<String, Object> map)
        {

            object value;

            map.TryGetValue(str, out value);

            if (value == null)
            {
                throw new ArgumentException(str + " not in map " + map);
            }
            if (!(value is int))
            {
                throw new ArgumentException(str + '(' + value + ") is not a number");
            }

            return (int)value;

        }

        public override string ToString()
        {
            return "Color:[rgb0x" + GetRed().ToString("X") + GetGreen().ToString("X") + GetBlue().ToString("X") + "]";
        }

    }
}
