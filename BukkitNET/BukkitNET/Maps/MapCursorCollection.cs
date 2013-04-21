using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BukkitNET.Maps
{
    public sealed class MapCursorCollection
    {

        private List<MapCursor> cursors = new List<MapCursor>();

        public int Size
        {
            get
            {
                return cursors.Count;
            }
        }

        public MapCursor GetCursor(int index)
        {
            return cursors[index];
        }

        public bool RemoveCursor(MapCursor cursor)
        {
            return cursors.Remove(cursor);
        }

        public MapCursor AddCursor(MapCursor cursor)
        {
            cursors.Add(cursor);
            return cursor;
        }

        public MapCursor AddCursor(int x, int y, byte direction)
        {
            return AddCursor(x, y, direction, (byte)0, true);
        }

        public MapCursor AddCursor(int x, int y, byte direction, byte type)
        {
            return AddCursor(x, y, direction, type, true);
        }

        public MapCursor AddCursor(int x, int y, byte direction, byte type, bool visible)
        {
            return AddCursor(new MapCursor((byte)x, (byte)y, direction, type, visible));
        }

    }
}
