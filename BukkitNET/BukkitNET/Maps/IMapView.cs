using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BukkitNET.Maps
{

    public interface IMapView
    {

        short GetId();

        bool IsVirtual();

        Scale GetScale();

        void SetScale(Scale scale);

        int GetCenterX();

        int GetCenterZ();

        void SetCenterX(int x);

        void SetCenterZ(int z);

        IWorld GetWorld();

        void SetWorld(IWorld world);

        List<MapRenderer> GetRenderers();

        void AddRenderer(MapRenderer renderer);

        bool RemoveRenderer(MapRenderer renderer);

    }

    public enum Scale
    {
        Closest = 0,
        Close = 1,
        Normal = 2,
        Far = 3,
        Farthest = 4
    }

    public static class ScaleExtensions
    {

        public static Scale ToScale(this byte value)
        {
            switch (value)
            {
                case 0: return Scale.Closest;
                case 1: return Scale.Close;
                case 2: return Scale.Normal;
                case 3: return Scale.Far;
                case 4: return Scale.Farthest;
                default: return default(Scale);
            }
        }

    }

}
