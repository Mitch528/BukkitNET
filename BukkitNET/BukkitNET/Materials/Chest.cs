using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BukkitNET.Block;

namespace BukkitNET.Materials
{
    public class Chest : DirectionalContainer
    {

        public Chest()
            : base(Material.Chest)
        {
        }

        public Chest(BlockFace direction)
            : this()
        {
            SetFacingDirection(direction);
        }

        public Chest(int type)
            : base(type)
        {
        }

        public Chest(Material type)
            : base(type)
        {
        }

        public Chest(int type, byte data)
            : base(type, data)
        {
        }

        public Chest(Material type, byte data)
            : base(type, data)
        {
        }

    }
}
