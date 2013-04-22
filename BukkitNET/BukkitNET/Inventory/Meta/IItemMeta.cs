using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BukkitNET.Configuration.Serialization;
using BukkitNET.Enchantments;

namespace BukkitNET.Inventory.Meta
{
    public interface IItemMeta : IConfigurationSerializable
    {

        bool HasDisplayName();

        string GetDisplayName();

        void SetDisplayName(string name);

        bool HasLore();

        List<string> GetLore();

        void SetLore(List<string> lore);

        bool HasEnchants();

        bool HasEnchant(Enchantment ench);

        int GetEnchantLevel(Enchantment ench);

        Dictionary<Enchantment, int> GetEnchants();

        bool AddEnchant(Enchantment ench, int level, bool ignoreLevelRestriction);

        bool RemoveEnchant(Enchantment ench);

        bool HasConflictingEnchant(Enchantment ench);

        IItemMeta Clone();

    }
}
