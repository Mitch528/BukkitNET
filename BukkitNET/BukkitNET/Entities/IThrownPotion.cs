using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using BukkitNET.Inventory;
using BukkitNET.Potions;

namespace BukkitNET.Entities
{
    public interface IThrownPotion : IProjectile
    {

        Collection<PotionEffect> GetEffects();

        ItemStack GetItem();

        void SetItem(ItemStack item);

    }
}
