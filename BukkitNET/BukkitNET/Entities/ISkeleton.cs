using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BukkitNET.Entities
{

    public interface ISkeleton : IMonster
    {

        SkeletonType GetSkeletonType();

        void SetSkeletonType(SkeletonType type);

    }

    public enum SkeletonType
    {
        Normal = 0,
        Wither = 1
    }

}
