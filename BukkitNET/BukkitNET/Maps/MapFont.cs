using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BukkitNET.Maps
{
    public class MapFont
    {

        private Dictionary<char, CharacterSprite> chars = new Dictionary<char, CharacterSprite>();
        private int height = 0;
        protected bool malleable = true;

        public int Height
        {
            get
            {
                return height;
            }
        }

        public void SetChar(char ch, CharacterSprite sprite)
        {
            if (!malleable)
            {
                throw new Exception("this font is not malleable");
            }

            if (!chars.ContainsKey(ch))
                chars.Add(ch, sprite);
            else
                chars[ch] = sprite;

            if (sprite.Height > height)
            {
                height = sprite.Height;
            }
        }

        public CharacterSprite GetChar(char ch)
        {
            return chars[ch];
        }

        public int GetgWidth(string text)
        {
            if (!IsValid(text))
            {
                throw new Exception("text contains invalid characters");
            }

            int result = 0;
            for (int i = 0; i < text.Length; ++i)
            {
                result += chars[text[i]].Width;
            }
            return result;
        }

        public bool IsValid(string text)
        {
            for (int i = 0; i < text.Length; ++i)
            {
                char ch = text[i];
                if (ch == '\u00A7' || ch == '\n') continue;
                if (chars[ch] == null) return false;
            }
            return true;
        }

        public class CharacterSprite
        {

            private int width;
            private int height;
            private bool[] data;

            public int Width
            {
                get
                {
                    return width;
                }
            }

            public int Height
            {
                get
                {
                    return height;
                }
            }

            public CharacterSprite(int width, int height, bool[] data)
            {
                this.width = width;
                this.height = height;
                this.data = data;

                if (data.Length != width * height)
                {
                    throw new ArgumentException("size of data does not match dimensions");
                }
            }

            public bool Get(int row, int col)
            {
                if (row < 0 || col < 0 || row >= height || col >= width) return false;
                return data[row * width + col];
            }


        }

    }
}
