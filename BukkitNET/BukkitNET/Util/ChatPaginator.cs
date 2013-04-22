using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using BukkitNET.Extensions;

namespace BukkitNET.Util
{
    public class ChatPaginator
    {

        public const int GUARANTEED_NO_WRAP_CHAT_PAGE_WIDTH = 55;
        public const int AVERAGE_CHAT_PAGE_WIDTH = 65;
        public const int UNBOUNDED_PAGE_WIDTH = int.MaxValue;
        public const int OPEN_CHAT_PAGE_HEIGHT = 20;
        public const int CLOSED_CHAT_PAGE_HEIGHT = 10;
        public const int UNBOUNDED_PAGE_HEIGHT = int.MaxValue;

        public static ChatPage Paginate(string unpaginatedString, int pageNumber)
        {
            return Paginate(unpaginatedString, pageNumber, GUARANTEED_NO_WRAP_CHAT_PAGE_WIDTH, CLOSED_CHAT_PAGE_HEIGHT);
        }

        public static ChatPage Paginate(string unpaginatedString, int pageNumber, int lineLength, int pageHeight)
        {
            String[] lines = WordWrap(unpaginatedString, lineLength);

            int totalPages = lines.Length / pageHeight + (lines.Length % pageHeight == 0 ? 0 : 1);
            int actualPageNumber = pageNumber <= totalPages ? pageNumber : totalPages;

            int from = (actualPageNumber - 1) * pageHeight;
            int to = from + pageHeight <= lines.Length ? from + pageHeight : lines.Length;
            String[] selectedLines = lines.Arrays_copyOfRange(from, to);

            return new ChatPage(selectedLines, actualPageNumber, totalPages);
        }

        public static string[] WordWrap(String rawString, int lineLength)
        {
            // A null string is a single line
            if (rawString == null)
            {
                return new string[] { "" };
            }

            // A string shorter than the lineWidth is a single line
            if (rawString.Legnth <= lineLength && !rawString.Contains("\n"))
            {
                return new string[] { rawString };
            }

            char[] rawChars = (rawString + ' ').ToCharArray(); // add a trailing space to trigger pagination
            StringBuilder word = new StringBuilder();
            StringBuilder line = new StringBuilder();
            var lines = new List<string>();
            int lineColorChars = 0;

            for (int i = 0; i < rawChars.Length; i++)
            {
                char c = rawChars[i];

                if (c == ChatColor.COLOR_CHAR)
                {
                    word.Append(ChatColor.getByChar(rawChars[i + 1]));
                    lineColorChars += 2;
                    i++;
                    continue;
                }

                if (c == ' ' || c == '\n')
                {
                    if (line.Length == 0 && word.Length > lineLength)
                    {
                        foreach (string partialWord in Regex.Split(word.ToString(), "(?<=\\G.{" + lineLength + "})"))
                        {
                            lines.Add(partialWord);
                        }
                    }
                    else if (line.Length + word.Length - lineColorChars == lineLength)
                    {
                        line.Append(word);
                        lines.Add(line.ToString());
                        line = new StringBuilder();
                        lineColorChars = 0;
                    }
                    else if (line.Length + 1 + word.Length - lineColorChars > lineLength)
                    {
                        foreach (string partialWord in Regex.Split(word.ToString(), "(?<=\\G.{" + lineLength + "})"))
                        {
                            lines.Add(line.ToString());
                            line = new StringBuilder(partialWord);
                        }
                        lineColorChars = 0;
                    }
                    else
                    {
                        if (line.Length > 0)
                        {
                            line.Append(' ');
                        }
                        line.Append(word);
                    }
                    word = new StringBuilder();

                    if (c == '\n')
                    { // Newline forces the line to flush
                        lines.Add(line.ToString());
                        line = new StringBuilder();
                    }
                }
                else
                {
                    word.Append(c);
                }
            }

            if (line.Length > 0)
            {
                lines.Add(line.ToString());
            }

            if (lines[0].Length == 0 || lines[0][0] != ChatColor.COLOR_CHAR)
            {
                lines[0] = ChatColor.WHITE + lines[0];
            }

            for (int i = 1; i < lines.Count; i++)
            {
                string pLine = lines[i - 1];
                string subLine = lines[i];

                char color = pLine[pLine.LastIndexOf(ChatColor.COLOR_CHAR) + 1];
                if (subLine.Length == 0 || subLine[0] != ChatColor.COLOR_CHAR)
                {
                    lines[i] = ChatColor.GetByChar(color) + subLine;
                }
            }

            return lines.ToArray();
        }

    }

    public class ChatPage
    {

        private string[] lines;
        private int pageNumber;
        private int totalPages;

        public int PageNumber
        {
            get
            {
                return pageNumber;
            }
        }

        public int TotalPages
        {
            get
            {
                return totalPages;
            }
        }

        public string[] Lines
        {
            get
            {
                return lines;
            }
        }

        public ChatPage(string[] lines, int pageNumber, int totalPages)
        {
            this.lines = lines;
            this.pageNumber = pageNumber;
            this.totalPages = totalPages;
        }

    }

}
