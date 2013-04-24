using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BukkitNET.Block;

namespace BukkitNET.Materials
{
    public abstract class SimpleAttachableMaterialData : MaterialData, IAttachable
    {

        protected SimpleAttachableMaterialData(int type, BlockFace direction) : this(type)
        {
            SetFacingDirection(direction);
        }

        protected SimpleAttachableMaterialData(Material type, BlockFace direction) : this(type)
        {
            SetFacingDirection(direction);
        }

        protected SimpleAttachableMaterialData(int type) : base(type)
        {
        }

        protected SimpleAttachableMaterialData(Material type) : base(type)
        {
        }

        protected SimpleAttachableMaterialData(int type, byte data) : base(type, data)
        {
        }

        protected SimpleAttachableMaterialData(Material type, byte data) : base(type, data)
        {
        }

        public void SetFacingDirection(BlockFace face)
        {
            throw new NotImplementedException();
        }

        public BlockFace GetFacing()
        {
            BlockFace attachedFace = GetAttachedFace();
            return attachedFace.GetOppositeFace();
        }

        public abstract BlockFace GetAttachedFace();

        public override string ToString()
        {
            return base.ToString() + " facing " + GetFacing();
        }
    }
}
