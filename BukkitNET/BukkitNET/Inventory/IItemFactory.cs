using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BukkitNET.Inventory.Meta;

namespace BukkitNET.Inventory
{
    public interface IItemFactory
    {

        IItemMeta GetItemMeta(Material material);

        bool IsApplicable(IItemMeta meta, ItemStack stack);
        
        bool IsApplicable(IItemMeta meta, Material material);

        bool Equals(IItemMeta meta1, IItemMeta meta2);

        IItemMeta AsMetaFor(IItemMeta meta, ItemStack stack);

        IItemMeta AsMetaFor(IItemMeta meta, Material material);

        Color GetDefaultLeatherColor();

    }
}
