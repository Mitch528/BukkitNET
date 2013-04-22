using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BukkitNET.Inventory;

namespace BukkitNET.Enchantments
{
    public abstract class Enchantment
    {

        public static Enchantment PROTECTION_ENVIRONMENTAL = new EnchantmentWrapper(0);

        public static Enchantment PROTECTION_FIRE = new EnchantmentWrapper(1);

        public static Enchantment PROTECTION_FALL = new EnchantmentWrapper(2);

        public static Enchantment PROTECTION_EXPLOSIONS = new EnchantmentWrapper(3);

        public static Enchantment PROTECTION_PROJECTILE = new EnchantmentWrapper(4);

        public static Enchantment OXYGEN = new EnchantmentWrapper(5);

        public static Enchantment WATER_WORKER = new EnchantmentWrapper(6);

        public static Enchantment THORNS = new EnchantmentWrapper(7);

        public static Enchantment DAMAGE_ALL = new EnchantmentWrapper(16);

        public static Enchantment DAMAGE_UNDEAD = new EnchantmentWrapper(17);

        public static Enchantment DAMAGE_ARTHROPODS = new EnchantmentWrapper(18);

        public static Enchantment KNOCKBACK = new EnchantmentWrapper(19);

        public static Enchantment FIRE_ASPECT = new EnchantmentWrapper(20);

        public static Enchantment LOOT_BONUS_MOBS = new EnchantmentWrapper(21);

        public static Enchantment DIG_SPEED = new EnchantmentWrapper(32);

        public static Enchantment SILK_TOUCH = new EnchantmentWrapper(33);

        public static Enchantment DURABILITY = new EnchantmentWrapper(34);

        public static Enchantment LOOT_BONUS_BLOCKS = new EnchantmentWrapper(35);

        public static Enchantment ARROW_DAMAGE = new EnchantmentWrapper(48);

        public static Enchantment ARROW_KNOCKBACK = new EnchantmentWrapper(49);

        public static Enchantment ARROW_FIRE = new EnchantmentWrapper(50);

        public static Enchantment ARROW_INFINITE = new EnchantmentWrapper(51);

        private static Dictionary<int, Enchantment> byId = new Dictionary<int, Enchantment>();
        private static Dictionary<string, Enchantment> byName = new Dictionary<string, Enchantment>();
        private static bool acceptingNew = true;
        private int id;

        public int Id
        {
            get
            {
                return id;
            }
        }

        public bool IsAcceptingRegistrations
        {
            get
            {
                return IsAcceptingRegistrations;
            }
        }



        protected Enchantment(int id)
        {
            this.id = id;
        }

        public abstract string GetName();
        public abstract int GetMaxLevel();
        public abstract int GetStartLevel();
        public abstract EnchantmentTarget GetItemTarget();
        public abstract bool ConflictsWith(Enchantment other);
        public abstract bool CanEnchantItem(ItemStack item);

        public override bool Equals(Object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (!(obj is Enchantment))
            {
                return false;
            }
            Enchantment other = (Enchantment)obj;
            if (this.id != other.id)
            {
                return false;
            }
            return true;
        }

        public override int GetHashCode()
        {
            return id;
        }

        public override string ToString()
        {
            return "Enchantment[" + id + ", " + GetName() + "]";
        }

        public static void RegisterEnchantment(Enchantment enchantment)
        {
            if (byId.ContainsKey(enchantment.id) || byName.ContainsKey(enchantment.GetName()))
            {
                throw new ArgumentException("Cannot set already-set enchantment");
            }
            else if (!IsAcceptingRegistrations())
            {
                throw new ArgumentException("No longer accepting new enchantments (can only be done by the server implementation)");
            }

            byId.Add(enchantment.id, enchantment);
            byName.Add(enchantment.GetName(), enchantment);
        }

        public static void StopAcceptingRegistrations()
        {
            acceptingNew = false;
            EnchantCommand.buildEnchantments();
        }

        public static Enchantment GetById(int id)
        {
            return byId[id];
        }

        public static Enchantment GetByName(string name)
        {
            return byName[name];
        }

        public static Enchantment[] GetValues()
        {
            return byId.Values.ToArray();
        }

    }
}
