using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BukkitNET.Inventory.Meta
{
    public interface IMapMeta : IItemMeta
    {

        bool IsScaling();

        void SetScaling(bool value);

        new IMapMeta Clone();

    }
}
