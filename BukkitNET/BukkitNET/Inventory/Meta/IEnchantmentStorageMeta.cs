using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BukkitNET.Enchantments;

namespace BukkitNET.Inventory.Meta
{
    public interface IEnchantmentStorageMeta : IItemMeta
    {

        bool HasStoredEnchants();

        bool HasStoredEnchant(Enchantment ench);

        int GetStoredEnchantLevel(Enchantment ench);

        Dictionary<Enchantment, int> GetStoredEnchants();

        bool AddStoredEnchant(Enchantment ench, int level, bool ignoreLevelRestriction);

        bool RemoveStoredEnchant(Enchantment ench);

        bool HasConflictingStoredEnchant(Enchantment ench);

        new IEnchantmentStorageMeta Clone();

    }
}
