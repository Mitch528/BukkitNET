using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BukkitNET.Entities
{
    public interface IFallingBlock : IEntity
    {

        Material GetMaterial();

        int GetBlockId();

        byte GetBlockData();

        bool GetDropItem();

        void SetDropItem(bool drop);

    }
}
