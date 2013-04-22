using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BukkitNET.Block
{
    public interface ISkull : IBlockState
    {

        bool HasOwner();

        string GetOwner();

        bool SetOwner(string name);

        BlockFace GetRotation();

        void SetRotation(BlockFace rotation);

        SkullType GetSkullType();

        void SetSkullType(SkullType skullType);


    }
}
