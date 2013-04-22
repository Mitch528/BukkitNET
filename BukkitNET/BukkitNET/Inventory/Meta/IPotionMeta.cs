using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BukkitNET.Potions;

namespace BukkitNET.Inventory.Meta
{
    public interface IPotionMeta : IItemMeta
    {

        bool HasCustomEffects();

        List<PotionEffect> GetCustomEffects();

        bool AddCustomEffect(PotionEffect effect, bool overwrite);

        bool RemoveCustomEffect(PotionEffectType type);

        bool HasCustomEffect(PotionEffectType type);

        void SetMainEffect(PotionEffectType type);

        bool ClearCustomEffects();

        new IPotionMeta Clone();

    }
}
