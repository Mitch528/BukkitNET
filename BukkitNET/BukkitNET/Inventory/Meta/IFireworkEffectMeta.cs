using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BukkitNET.Inventory.Meta
{
    public interface IFireworkEffectMeta : IItemMeta
    {

        void SetEffect(FireworkEffect effect);

        bool HasEffect();

        FireworkEffect GetEffect();

        new IFireworkEffectMeta Clone();

    }
}
