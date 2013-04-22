using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BukkitNET.Inventory;

namespace BukkitNET.Enchantments
{
    public class EnchantmentWrapper : Enchantment
    {

        public EnchantmentWrapper(int id) : base(id)
        {
        }

        public Enchantment GetEnchantment()
        {
            return Enchantment.GetById(Id);
        }

        public override string GetName()
        {
            return GetEnchantment().GetName();
        }

        public override int GetMaxLevel()
        {
            return GetEnchantment().GetMaxLevel();
        }

        public override int GetStartLevel()
        {
            return GetEnchantment().GetStartLevel();
        }

        public override EnchantmentTarget GetItemTarget()
        {
            return GetEnchantment().GetItemTarget();
        }

        public override bool ConflictsWith(Enchantment other)
        {
            return GetEnchantment().ConflictsWith(other);
        }

        public override bool CanEnchantItem(ItemStack item)
        {
            return GetEnchantment().CanEnchantItem(item);
        }
    }
}
