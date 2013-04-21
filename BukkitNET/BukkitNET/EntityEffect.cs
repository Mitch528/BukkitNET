using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BukkitNET.Attributes;
using BukkitNET.Extensions;

namespace BukkitNET
{

    public enum EntityEffect
    {

        [EntityEffectInfo(2)]
        Hurt,

        [EntityEffectInfo(3)]
        Death,

        [EntityEffectInfo(6)]
        WolfSmoke,

        [EntityEffectInfo(7)]
        WolfHearts,

        [EntityEffectInfo(8)]
        WolfShake,

        [EntityEffectInfo(10)]
        SheepEat

    }

    public static class EntityEffectHelper
    {

        public static EntityEffect GetByData(byte data)
        {

            var vals = Enum.GetValues(typeof(EntityEffect));

            foreach (var val in vals)
            {

                var ee = (EntityEffect)val;

                var attrib = ee.GetAttribute<EntityEffectInfoAttribute>();

                if (attrib.Data == data)
                {
                    return ee;
                }

            }

        }

    }

}
