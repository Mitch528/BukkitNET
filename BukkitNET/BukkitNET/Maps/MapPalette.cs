using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;

namespace BukkitNET.Maps
{
    public sealed class MapPalette
    {

        private MapPalette() { }

        private static System.Drawing.Color c(int r, int g, int b)
        {
            return System.Drawing.Color.FromArgb(r, g, b);
        }

        private static double GetDistance(System.Drawing.Color c1, System.Drawing.Color c2)
        {
            double rmean = (c1.R + c2.R) / 2.0;
            double r = c1.R - c2.R;
            double g = c1.G - c2.G;
            int b = c1.B - c2.B;
            double weightR = 2 + rmean / 256.0;
            double weightG = 4.0;
            double weightB = 2 + (255 - rmean) / 256.0;
            return weightR * r * r + weightG * g * g + weightB * b * b;
        }

        private static System.Drawing.Color[] colors = {
            System.Drawing.Color.FromArgb(0, 0, 0, 0) , System.Drawing.Color.FromArgb(0, 0, 0, 0),
            System.Drawing.Color.FromArgb(0, 0, 0, 0), System.Drawing.Color.FromArgb(0, 0, 0,0),
            c(89,125,39), c(109,153,48), c(27,178,56), c(109,153,48),
            c(174,164,115), c(213,201,140), c(247,233,163), c(213,201,140),
            c(117,117,117), c(144,144,144), c(167,167,167), c(144,144,144),
            c(180,0,0), c(220,0,0), c(255,0,0), c(220,0,0),
            c(112,112,180), c(138,138,220), c(160,160,255), c(138,138,220),
            c(117,117,117), c(144,144,144), c(167,167,167), c(144,144,144),
            c(0,87,0), c(0,106,0), c(0,124,0), c(0,106,0),
            c(180,180,180), c(220,220,220), c(255,255,255), c(220,220,220),
            c(115,118,129), c(141,144,158), c(164,168,184), c(141,144,158),
            c(129,74,33), c(157,91,40), c(183,106,47), c(157,91,40),
            c(79,79,79), c(96,96,96), c(112,112,112), c(96,96,96),
            c(45,45,180), c(55,55,220), c(64,64,255), c(55,55,220),
            c(73,58,35), c(89,71,43), c(104,83,50), c(89,71,43)
        };

        public static byte TRANSPARENT = 0;
        public static byte LIGHT_GREEN = 4;
        public static byte LIGHT_BROWN = 8;
        public static byte GRAY_1 = 12;
        public static byte RED = 16;
        public static byte PALE_BLUE = 20;
        public static byte GRAY_2 = 24;
        public static byte DARK_GREEN = 28;
        public static byte WHITE = 32;
        public static byte LIGHT_GRAY = 36;
        public static byte BROWN = 40;
        public static byte DARK_GRAY = 44;
        public static byte BLUE = 48;
        public static byte DARK_BROWN = 52;

        public static Image ResizeImage(Image image)
        {
            Image result = new Bitmap(128, 128, PixelFormat.Format32bppArgb);
            using (Graphics graphics = Graphics.FromImage(result))
            {
                graphics.DrawImage(image, 0, 0, 128, 128);
            }
            return result;
        }

        public static byte[] ImageToBytes(Image image)
        {

            MemoryStream ms = new MemoryStream();
            image.Save(ms, ImageFormat.Gif);

            byte[] data = ms.ToArray();

            ms.Dispose();

            return data;

        }

        public static byte MatchColor(int r, int g, int b)
        {
            return MatchColor(System.Drawing.Color.FromArgb(r, g, b));
        }

        public static byte MatchColor(System.Drawing.Color color)
        {
            if (color.A < 128) return 0;

            int index = 0;
            double best = -1;

            for (int i = 4; i < colors.Length; i++)
            {
                double distance = GetDistance(color, colors[i]);
                if (distance < best || best == -1)
                {
                    best = distance;
                    index = i;
                }
            }

            return (byte)index;
        }

        public static System.Drawing.Color GetColor(byte index)
        {
            if (index < 0 || index >= colors.Length)
            {
                throw new IndexOutOfRangeException();
            }
            else
            {
                return colors[index];
            }
        }

    }
}
