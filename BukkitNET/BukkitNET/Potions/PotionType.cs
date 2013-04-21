using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BukkitNET.Attributes;
using BukkitNET.Extensions;

namespace BukkitNET.Potions
{

    public enum PotionType
    {

        [PotionTypeInfo(0, 0, 0)]
        Water,

        [PotionTypeInfo(1, 10, 2)]
        Regen,

        [PotionTypeInfo(2, 1, 2)]
        Speed,

        [PotionTypeInfo(3, 12, 1)]
        FireResistance,

        [PotionTypeInfo(4, 19, 2)]
        Poison,

        [PotionTypeInfo(5, 6, 2)]
        InstantHeal,

        [PotionTypeInfo(6, 16, 1)]
        NightVision,

        [PotionTypeInfo(8, 18, 1)]
        Weakness,

        [PotionTypeInfo(9, 5, 2)]
        Strength,

        [PotionTypeInfo(10, 2, 1)]
        Slowness,

        [PotionTypeInfo(12, 7, 2)]
        InstantDamage,

        [PotionTypeInfo(14, 14, 1)]
        Invisibility


    }

    public static class PotionTypeHelper
    {

        public static PotionType GetByDamageValue(int damage)
        {

            var vals = Enum.GetValues(typeof(PotionType));

            foreach (PotionType type in vals)
            {

                var attrib = type.GetAttribute<PotionTypeInfoAttribute>();

                if (attrib.DamageValue == damage)
                    return type;

            }

            return default(PotionType);

        }

        public static PotionType GetByEffect(PotionEffectType effect)
        {

            if (effect == null)
                return PotionType.Water;

            var vals = Enum.GetValues(typeof(PotionType));

            foreach (PotionType t in vals)
            {

                var attrib = t.GetAttribute<PotionTypeInfoAttribute>();

                if (PotionEffectType.GetById(attrib.Effect).Equals(effect))
                    return t;

            }

            return PotionType.Water;

        }

    }

    public static class PotionTypeExtensions
    {

        public static int GetDamageValue(this PotionType type)
        {

            var attrib = type.GetAttribute<PotionTypeInfoAttribute>();

            return attrib.DamageValue;

        }

        public static int GetMaxLevel(this PotionType type)
        {

            var attrib = type.GetAttribute<PotionTypeInfoAttribute>();

            return attrib.MaxLevel;

        }

        public static bool IsInstant(this PotionType type)
        {

            var attrib = type.GetAttribute<PotionTypeInfoAttribute>();
            var effect = attrib.Effect;

            var et = PotionEffectType.GetById(effect);

            return et == null || et.IsInstant();

        }

    }

}
