using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BukkitNET.Attributes;
using BukkitNET.Block;
using BukkitNET.Extensions;

namespace BukkitNET
{

    public enum Effect
    {

        [EffectInfo(1000, EffectType.Sound)]
        Click2,

        [EffectInfo(1001, EffectType.Sound)]
        Click1,

        [EffectInfo(1002, EffectType.Sound)]
        BowFire,

        [EffectInfo(1003, EffectType.Sound)]
        DoorToggle,

        [EffectInfo(1004, EffectType.Sound)]
        Extinguish,

        [EffectInfo(1005, EffectType.Sound, typeof(Material))]
        RecordPlay,

        [EffectInfo(1007, EffectType.Sound)]
        GhashShriek,

        [EffectInfo(1008, EffectType.Sound)]
        GhastShoot,

        [EffectInfo(1009, EffectType.Sound)]
        BlazeShoot,

        [EffectInfo(1010, EffectType.Sound)]
        ZombieChewWoodenDoor,

        [EffectInfo(1011, EffectType.Sound)]
        ZombieChewIronDoor,

        [EffectInfo(1012, EffectType.Sound)]
        ZombieDestroyDoor,

        [EffectInfo(2000, EffectType.Visual, typeof(BlockFace))]
        Smoke,

        [EffectInfo(2001, EffectType.Sound, typeof(Material))]
        StepSound,

        [EffectInfo(2002, EffectType.Sound, typeof(IPotion))]
        PotionBreak,

        [EffectInfo(2003, EffectType.Visual)]
        EnderSignal,

        [EffectInfo(2004, EffectType.Visual)]
        MobSpawnerFlames


    }

    public static class EffectHelper
    {

        public static Effect GetById(int id)
        {

            var vals = Enum.GetValues(typeof(Effect));

            foreach (Effect effect in vals)
            {

                var attrib = effect.GetAttribute<EffectInfoAttribute>();

                if (attrib.Id == id)
                {
                    return effect;
                }

            }

        }

    }

    public enum EffectType
    {
        Sound,
        Visual
    }

}
