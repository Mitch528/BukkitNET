using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using BukkitNET.Entities;
using BukkitNET.Inventory;

namespace BukkitNET.Potions
{
    public class Potion
    {

        private bool extended = false;
        private bool splash = false;
        private int level = 1;
        private int name = -1;
        private PotionType type;

        public int Level
        {
            get
            {
                return level;
            }
            set
            {
                int max = type.MaxLevel;
                Debug.Assert(level > 0 && level <= max, "Level must be " + (max == 1 ? "" : "between 1 and ") + max + " for this potion");
                level = value;
            }
        }

        public PotionType Type
        {
            get
            {
                return type;
            }
            set
            {
                type = value;
            }
        }

        public bool HasExtendedDuration
        {
            get
            {
                return extended;
            }
        }

        public bool IsSplash
        {
            get
            {
                return splash;
            }
            set
            {
                splash = value;
            }
        }

        public static IPotionBrewer Brewer
        {
            get
            {
                return brewer;
            }
            set
            {
                if (brewer != null)
                    throw new ArgumentException("brewer can only be set internally");
                brewer = value;
            }
        }


        public Potion(PotionType type)
        {
            this.type = type;
            if (type != null)
            {
                this.name = type.DamageValue;
            }
            if (type == null || type == PotionType.Water)
            {
                this.level = 0;
            }
        }

        public Potion(PotionType type, int level)
            : this(type)
        {
            Debug.Assert(type != null, "Type cannot be null");
            Debug.Assert(type != PotionType.WATER, "Water bottles don't have a level!");
            Debug.Assert(level > 0 && level < 3, "Level must be 1 or 2");
            this.level = level;
        }

        public Potion(int name)
            : this(PotionType.GetByDamageValue(name & POTION_BIT))
        {
            this.name = name & NAME_BIT;
            if ((name & POTION_BIT) == 0)
            {
                this.type = null;
            }
        }

        public Potion Splash()
        {
            splash = true;
            return this;
        }

        public Potion Extend()
        {
            extended = true;
            return this;
        }


        public void Apply(ItemStack to)
        {
            Debug.Assert(to != null, "itemstack cannot be null");
            Debug.Assert(to.getType() == Material.Potion, "given itemstack is not a potion");
            to.SetDurability(ToDamageValue());
        }

        public void Apply(ILivingEntity to)
        {
            Debug.Assert(to != null, "entity cannot be null");
            to.AddPotionEffects(GetEffects());
        }

        public override bool Equals(object obj)
        {
            if (this == obj)
            {
                return true;
            }
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            Potion other = (Potion)obj;
            return extended == other.extended && splash == other.splash && level == other.level && type == other.type;
        }

        public override int GetHashCode()
        {
            int prime = 31;
            int result = prime + level;
            result = prime * result + (extended ? 1231 : 1237);
            result = prime * result + (splash ? 1231 : 1237);
            result = prime * result + ((type == null) ? 0 : type.GetHashCode());
            return result;
        }



        public Collection<PotionEffect> GetEffects()
        {
            if (type == null) return new Collection<PotionEffect>();
            return brewer.GetEffectsFromDamage(ToDamageValue());
        }

        public short ToDamageValue()
        {
            short damage;
            if (type == PotionType.Water)
            {
                return 0;
            }
            else if (type == null)
            {
                damage = (short)(name == 0 ? 8192 : name);
            }
            else
            {
                damage = (short)(level - 1);
                damage <<= TIER_SHIFT;
                damage |= (short)type.GetDamageValue();
            }
            if (splash)
            {
                damage |= (short)SPLASH_BIT;
            }
            if (extended)
            {
                damage |= (short)EXTENDED_BIT;
            }
            return damage;
        }

        public ItemStack ToItemStack(int amount)
        {
            return new ItemStack(Material.Potion, amount, ToDamageValue());
        }

        private static IPotionBrewer brewer;

        private static int EXTENDED_BIT = 0x40;
        private static int POTION_BIT = 0xF;
        private static int SPLASH_BIT = 0x4000;
        private static int TIER_BIT = 0x20;
        private static int TIER_SHIFT = 5;
        private static int NAME_BIT = 0x3F;

        public static Potion FromDamage(int damage)
        {
            PotionType type = PotionType.GetByDamageValue(damage & POTION_BIT);
            Potion potion;
            if (type == null || (type == PotionType.Water && damage != 0))
            {
                potion = new Potion(damage & NAME_BIT);
            }
            else
            {
                int level = (damage & TIER_BIT) >> TIER_SHIFT;
                level++;
                potion = new Potion(type, level);
            }
            if ((damage & SPLASH_BIT) > 0)
            {
                potion = potion.Splash();
            }
            if ((damage & EXTENDED_BIT) > 0)
            {
                potion = potion.Extend();
            }
            return potion;
        }

        public static Potion FromItemStack(ItemStack item)
        {
            Debug.Assert(item != null, "item cannot be null");
            if (item.GetType() != Material.Potion)
                throw new ArgumentException("item is not a potion");
            return FromDamage(item.Durability);
        }

    }
}
