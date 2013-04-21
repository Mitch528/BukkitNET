using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BukkitNET.Potions;

namespace BukkitNET.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public class PotionTypeInfoAttribute : Attribute
    {

        private int damageValue, maxLevel;
        private int effect;

        public int DamageValue
        {
            get
            {
                return damageValue;
            }
        }

        public int MaxLevel
        {
            get
            {
                return maxLevel;
            }
        }

        public int Effect
        {
            get
            {
                return effect;
            }
        }

        public PotionTypeInfoAttribute(int damageValue, int maxLevel) : this(damageValue, 0, maxLevel)
        {
        }

        public PotionTypeInfoAttribute(int damageValue, int effect, int maxLevel)
        {
            this.damageValue = damageValue;
            this.effect = effect;
            this.maxLevel = maxLevel;
        }

    }
}
