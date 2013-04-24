using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BukkitNET.Block;

namespace BukkitNET.Materials
{
    public class EnderChest : DirectionalContainer
    {

        public EnderChest()
            : base(Material.EnderChest)
        {
        }

        public EnderChest(BlockFace direction)
            : this()
        {
            SetFacingDirection(direction);
        }

        public EnderChest(int type)
            : base(type)
        {
        }

        public EnderChest(Material type)
            : base(type)
        {
        }

        public EnderChest(int type, byte data)
            : base(type, data)
        {
        }

        public EnderChest(Material type, byte data)
            : base(type, data)
        {
        }
    }
}
