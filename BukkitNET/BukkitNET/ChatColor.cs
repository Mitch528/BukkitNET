using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using BukkitNET.Attributes;
using BukkitNET.Extensions;

namespace BukkitNET
{

    public enum ChatColor
    {

        [ChatColorInfo('0', 0x00)]
        Black,

        [ChatColorInfo('1', 0x1)]
        DarkBlue,

        [ChatColorInfo('2', 0x2)]
        DarkGreen,

        [ChatColorInfo('3', 0x3)]
        DarkAqua,

        [ChatColorInfo('4', 0x4)]
        DarkRed,

        [ChatColorInfo('5', 0x5)]
        DarkPurple,

        [ChatColorInfo('6', 0x6)]
        Gold,

        [ChatColorInfo('7', 0x7)]
        Gray,

        [ChatColorInfo('8', 0x8)]
        DarkGray,

        [ChatColorInfo('9', 0x9)]
        Blue,

        [ChatColorInfo('a', 0xA)]
        Green,

        [ChatColorInfo('b', 0xB)]
        Aqua,

        [ChatColorInfo('c', 0xC)]
        Red,

        [ChatColorInfo('d', 0xD)]
        LightPurple,

        [ChatColorInfo('e', 0xE)]
        Yellow,

        [ChatColorInfo('f', 0xF)]
        White,

        [ChatColorInfo('k', 0x10, true)]
        Magic,

        [ChatColorInfo('l', 0x11, true)]
        Bold,

        [ChatColorInfo('m', 0x12, true)]
        StrikeThrough,

        [ChatColorInfo('n', 0x13, true)]
        Underline,

        [ChatColorInfo('o', 0x14, true)]
        Italic,

        [ChatColorInfo('r', 0x15)]
        Reset

    }

    public static class ChatColorHelper
    {

        public const char COLOR_CHAR = '\u00A7';
        private static Regex STRIP_COLOR_PATTERN = new Regex("(?i)" + COLOR_CHAR.ToString() + "[0-9A-FK-OR]", RegexOptions.Compiled);

        public static string TranslateAlternateColorCodes(char altColorChar, string textToTranslate)
        {
            char[] b = textToTranslate.ToCharArray();
            for (int i = 0; i < b.Length - 1; i++)
            {
                if (b[i] == altColorChar && "0123456789AaBbCcDdEeFfKkLlMmNnOoRr".IndexOf(b[i + 1]) > -1)
                {
                    b[i] = COLOR_CHAR;
                    b[i + 1] = char.ToLower(b[i + 1]);
                }
            }
            return new string(b);
        }

        public static string StripColor(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return null;
            }

            return STRIP_COLOR_PATTERN.Replace(input, "");

        }

    }

    public static class ChatColorExtensions
    {

        private static Dictionary<int, ChatColor> BY_ID = new Dictionary<int, ChatColor>();
        private static Dictionary<char, ChatColor> BY_CHAR = new Dictionary<char, ChatColor>();

        static ChatColorExtensions()
        {
            foreach (ChatColor color in Enum.GetValues(typeof(ChatColor)))
            {

                var attrib = GetAttribute(color);

                BY_ID.Add(attrib.IntCode, color);
                BY_CHAR.Add(attrib.Character, color);
            
            }
        }

        public static char GetChar(this ChatColor color)
        {
            return GetAttribute(color).Character;
        }

        public static bool IsFormat(this ChatColor color)
        {
            return GetAttribute(color).IsFormat;
        }

        public static bool IsColor(this ChatColor color)
        {
            var attrib = GetAttribute(color);
            return !attrib.IsFormat && color != ChatColor.Reset;
        }

        public static ChatColor GetByChar(char code)
        {
            return BY_CHAR[code];
        }

        public static ChatColor GetByChar(string code)
        {
            Debug.Assert(!string.IsNullOrEmpty(code), "Code cannot be null");
            Debug.Assert(code.Length > 0, "Code must have at least one char");

            return BY_CHAR[code[0]];
        }

        private static ChatColorInfoAttribute GetAttribute(ChatColor color)
        {
            return color.GetAttribute<ChatColorInfoAttribute>();
        }

    }

}
