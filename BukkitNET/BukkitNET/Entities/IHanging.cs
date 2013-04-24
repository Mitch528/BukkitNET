using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BukkitNET.Block;
using BukkitNET.Materials;

namespace BukkitNET.Entities
{
    public interface IHanging : IEntity, IAttachable
    {

        bool SetFacingDirection(BlockFace face, bool force);

    }
}
