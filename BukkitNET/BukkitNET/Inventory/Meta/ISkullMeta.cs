using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BukkitNET.Inventory.Meta
{
    public interface ISkullMeta : IItemMeta
    {

        string GetOwner();

        bool HasOwner();

        bool SetOwner(string owner);

        new ISkullMeta Clone();

    }
}
