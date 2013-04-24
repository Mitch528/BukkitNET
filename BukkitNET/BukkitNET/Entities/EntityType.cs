using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BukkitNET.Attributes;
using BukkitNET.Entities.Minecart;
using BukkitNET.Extensions;

namespace BukkitNET.Entities
{

    public enum EntityType
    {

        [EntityTypeInfo("Item", typeof(IItem), 1, false)]
        DroppedItem,

        [EntityTypeInfo("XPOrb", typeof(IExperienceOrb), 2, false)]
        ExperienceOrb,

        [EntityTypeInfo("Painting", typeof(IPainting), 9, false)]
        Painting,

        [EntityTypeInfo("Arrow", typeof(IArrow), 10, false)]
        Arrow,

        [EntityTypeInfo("Snowball", typeof(ISnowball), 11)]
        Snowball,

        [EntityTypeInfo("Fireball", typeof(IFireball), 12)]
        Fireball,

        [EntityTypeInfo("SmallFireball", typeof(ISmallFireball), 13)]
        SmallFireball,

        [EntityTypeInfo("ThrownEnderpearl", typeof(IEnderPearl), 14)]
        EnderPearl,

        [EntityTypeInfo("EyeOfEnderSignal", typeof(IEnderSignal), 15)]
        EnderSignal,

        [EntityTypeInfo("ThrownExpBottle", typeof(IThrownExpBottle), 17)]
        ThrownExpBottle,

        [EntityTypeInfo("ItemFrame", typeof(IItemFrame), 18)]
        ItemFrame,

        [EntityTypeInfo("WitherSkull", typeof(IWitherSkull), 19)]
        WitherSkull,

        [EntityTypeInfo("PrimedTnt", typeof(ITNTPrimed), 20)]
        PrimedTnt,

        [EntityTypeInfo("FallingSand", typeof(IFallingBlock), 21, false)]
        FallingBlock,

        [EntityTypeInfo("FireworksRocketEntity", typeof(IFirework), 22, false)]
        Firework,

        [EntityTypeInfo("Boat", typeof(IBoat), 41)]
        Boat,

        [EntityTypeInfo("MinecartRideable", typeof(IRideableMinecart), 42)]
        Minecart,

        [EntityTypeInfo("MinecartChest", typeof(IStorageMinecart), 43)]
        MinecartChest,

        [EntityTypeInfo("MinecartFurnace", typeof(IPoweredMinecart), 44)]
        MinecartFurnace,

        [EntityTypeInfo("MinecartTNT", typeof(IExplosiveMinecart), 45)]
        MinecartTNT,

        [EntityTypeInfo("MinecartHopper", typeof(IHopperMinecart), 46)]
        MinecartHopper,

        [EntityTypeInfo("MinecartMobSpawner", typeof(ISpawnerMinecart), 47)]
        MinecartMobSpawner,

        [EntityTypeInfo("Creeper", typeof(ICreeper), 50)]
        Creeper,

        [EntityTypeInfo("Skeleton", typeof(ISkeleton), 51)]
        Skeleton,

        [EntityTypeInfo("Spider", typeof(ISpider), 52)]
        Spider,

        [EntityTypeInfo("Giant", typeof(IGiant), 53)]
        Giant,

        [EntityTypeInfo("Zombie", typeof(IZombie), 54)]
        Zombie,

        [EntityTypeInfo("Slime", typeof(ISlime), 55)]
        Slime,

        [EntityTypeInfo("Ghast", typeof(IGhast), 56)]
        Ghast,

        [EntityTypeInfo("PigZombie", typeof(IPigZombie), 57)]
        PigZombie,

        [EntityTypeInfo("Enderman", typeof(IEnderman), 58)]
        Enderman,

        [EntityTypeInfo("CaveSpider", typeof(ICaveSpider), 59)]
        CaveSpider,

        [EntityTypeInfo("SilverFish", typeof(ISilverfish), 60)]
        SilverFish,

        [EntityTypeInfo("Blaze", typeof(IBlaze), 61)]
        Blaze,

        [EntityTypeInfo("LavaSlime", typeof(IMagmaCube), 62)]
        MagmaCube,

        [EntityTypeInfo("EnderDragon", typeof(IEnderDragon), 63)]
        EnderDragon,

        [EntityTypeInfo("WitherBoss", typeof(IWither), 64)]
        WitherBoss,

        [EntityTypeInfo("Bat", typeof(IBat), 65)]
        Bat,

        [EntityTypeInfo("Witch", typeof(IWitch), 66)]
        Witch,

        [EntityTypeInfo("Pig", typeof(IPig), 90)]
        Pig,

        [EntityTypeInfo("Sheep", typeof(ISheep), 91)]
        Sheep,

        [EntityTypeInfo("Cow", typeof(ICow), 92)]
        Cow,

        [EntityTypeInfo("Chicken", typeof(IChicken), 93)]
        Chicken,

        [EntityTypeInfo("Squid", typeof(ISquid), 94)]
        Squid,

        [EntityTypeInfo("Wolf", typeof(IWolf), 95)]
        Wolf,

        [EntityTypeInfo("MushroomCow", typeof(IMushroomCow), 96)]
        MushroomCow,

        [EntityTypeInfo("SnowMan", typeof(ISnowman), 97)]
        SnowMan,

        [EntityTypeInfo("Ozelot", typeof(IOcelot), 98)]
        Ocelot,

        [EntityTypeInfo("VillagerGolem", typeof(IIronGolem), 99)]
        IronGolem,

        [EntityTypeInfo("Villager", typeof(IVillager), 120)]
        Villager,

        [EntityTypeInfo("EnderCrystal", typeof(IEnderCrystal), 200)]
        EnderCrystal,

        [EntityTypeInfo(null, typeof(IThrownPotion), -1, false)]
        SplashPotion,

        [EntityTypeInfo(null, typeof(IEgg), -1, false)]
        Egg,

        [EntityTypeInfo(null, typeof(IFish), -1, false)]
        FishingHook,

        [EntityTypeInfo(null, typeof(ILightningStrike), -1, false)]
        Lightning,

        [EntityTypeInfo(null, typeof(IWeather), -1, false)]
        Weahter,

        [EntityTypeInfo(null, typeof(IPlayer), -1, false)]
        Player,

        [EntityTypeInfo(null, typeof(IComplexEntityPart), -1, false)]
        ComplexPart,

        [EntityTypeInfo(null, null, -1, false)]
        Unknown

    }

    public static class EntityTypeHelper
    {

        public static EntityType FromName(string name)
        {

            EntityType type;

            Enum.TryParse(name, true, out type);

            return type;

        }

        public static EntityType FromId(int id)
        {

            var vals = Enum.GetValues(typeof(EntityType));

            foreach (EntityType type in vals)
            {

                var attrib = type.GetAttribute<EntityTypeInfoAttribute>();

                if (attrib.TId == id)
                    return type;

            }

            return EntityType.Unknown;

        }

    }

    public static class EntityTypeExtensions
    {

        public static string GetName(this EntityType type)
        {
            return GetAttribute(type).Name;
        }

        public static Type GetEntityType(this EntityType type)
        {
            return GetAttribute(type).Type;
        }

        public static int GetEntityTypeId(this EntityType type)
        {
            return GetAttribute(type).TId;
        }

        public static bool IsIndependent(this EntityType type)
        {
            return GetAttribute(type).Independent;
        }

        public static bool IsLiving(this EntityType type)
        {
            return GetAttribute(type).Living;
        }

        private static EntityTypeInfoAttribute GetAttribute(EntityType type)
        {
            return type.GetAttribute<EntityTypeInfoAttribute>();
        }

    }

}
