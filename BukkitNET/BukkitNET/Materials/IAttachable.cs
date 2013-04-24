using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BukkitNET.Block;

namespace BukkitNET.Materials
{
    public interface IAttachable : IDirectional
    {

        BlockFace GetAttachedFace();

    }
}
