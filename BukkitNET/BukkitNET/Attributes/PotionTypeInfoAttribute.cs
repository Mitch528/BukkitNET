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
        private PotionEffectType effect;

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

        public PotionEffectType Effect
        {
            get
            {
                return effect;
            }
        }

        public PotionTypeInfoAttribute(int damageValue, int maxLevel) : this(damageValue, null, maxLevel)
        {
        }

        public PotionTypeInfoAttribute(int damageValue, PotionEffectType effect, int maxLevel)
        {
            this.damageValue = damageValue;
            this.effect = effect;
            this.maxLevel = maxLevel;
        }

    }
}
