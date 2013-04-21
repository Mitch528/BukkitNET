using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace BukkitNET.Maps
{
    public interface IMapCanvas
    {

        IMapView GetMapView();

        MapCursorCollection GetCursors();

        void SetCursors(MapCursorCollection cursors);

        void SetPixel(int x, int y, byte color);

        byte GetPixel(int x, int y);

        byte GetBasePixel(int x, int y);

        void DrawImage(int x, int y, Image image);

        void DrawText(int x, int y, MapFont font, String text);

    }
}
