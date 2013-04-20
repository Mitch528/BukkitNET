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

        [PotionTypeInfo(0, 0)]
        Water,

        [PotionTypeInfo(1, PotionEffectType.REGENERATION, 2)]
        Regen



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

                if (attrib.Effect == effect)
                    return t;

            }

            return PotionType.Water;

        }

    }

    public static class PotionTypeExtensions
    {

        public static bool IsInstant(this PotionType type)
        {

            var attrib = type.GetAttribute<PotionTypeInfoAttribute>();
            var effect = attrib.Effect;

            return effect == null ? true : effect.IsInstant;

        }

    }

}
