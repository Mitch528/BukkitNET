using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BukkitNET.Inventory.Meta;

namespace BukkitNET.Entities
{
    public interface IFirework : IEntity
    {

        IFireworkMeta GetFireworkMeta();

        void SetFireworkMeta(IFireworkMeta meta);

    }
}
