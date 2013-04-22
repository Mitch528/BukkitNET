using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using BukkitNET.Attributes;
using BukkitNET.Block;
using BukkitNET.Extensions;
using BukkitNET.Materials;

namespace BukkitNET
{

    public enum Material
    {

        [MaterialInfo(0, 0)]
        Air,

        [MaterialInfo(1)]
        Stone,

        [MaterialInfo(2)]
        Grass,

        [MaterialInfo(3)]
        Dirt,

        [MaterialInfo(4)]
        CobbleStone,

        [MaterialInfo(5, typeof(Tree))]
        Wood,

        [MaterialInfo(6, typeof(Tree))]
        Sapling,

        [MaterialInfo(7)]
        Bedrock,

        [MaterialInfo(8, typeof(MaterialData))]
        Water,

        [MaterialInfo(9, typeof(MaterialData))]
        StationaryWater,

        [MaterialInfo(10, typeof(MaterialData))]
        Lava,

        [MaterialInfo(11, typeof(MaterialData))]
        StationaryLava,

        [MaterialInfo(12)]
        Sand,

        [MaterialInfo(13)]
        Gravel,

        [MaterialInfo(14)]
        GoldOre,

        [MaterialInfo(15)]
        IronOre,

        [MaterialInfo(16)]
        CoalOre,

        [MaterialInfo(17, typeof(Tree))]
        Log,

        [MaterialInfo(18, typeof(Tree))]
        Leaves,

        [MaterialInfo(19)]
        Sponge,

        [MaterialInfo(20)]
        Glass,

        [MaterialInfo(21)]
        LapisOre,

        [MaterialInfo(22)]
        LapisBlock,

        [MaterialInfo(23, typeof(Dispenser))]
        Dispenser,

        [MaterialInfo(24, typeof(Sandstone))]
        Sandstone,

        [MaterialInfo(25)]
        NoteBlock,

        [MaterialInfo(26, typeof(Bed))]
        BedBlock,

        [MaterialInfo(27, typeof(PoweredRail))]
        PoweredRail,

        [MaterialInfo(28, typeof(DetectorRail))]
        DetectorRail,

        [MaterialInfo(29, typeof(PistonBaseMaterial))]
        PistonStickyBase,

        [MaterialInfo(30)]
        Web,

        [MaterialInfo(31, typeof(LongGrass))]
        LongGrass,

        [MaterialInfo(32)]
        DeadBush,

        [MaterialInfo(33, typeof(PistonBaseMaterial))]
        PistonBase,

        [MaterialInfo(34, typeof(PistonExtensionMaterial))]
        PistonExtension,

        [MaterialInfo(35, typeof(Wool))]
        Wool,

        [MaterialInfo(36)]
        PistonMovingPiece,

        [MaterialInfo(37)]
        YellowFlower,

        [MaterialInfo(38)]
        RedRose,

        [MaterialInfo(39)]
        BrownMushroom,

        [MaterialInfo(40)]
        RedMushroom,

        [MaterialInfo(41)]
        GoldBlock,

        [MaterialInfo(42)]
        IronBlock,

        [MaterialInfo(43, typeof(IStep))]
        DoubleStep,

        [MaterialInfo(44, typeof(IStep))]
        Step,

        [MaterialInfo(45)]
        Brick,

        [MaterialInfo(46)]
        Tnt,

        [MaterialInfo(47)]
        BookShelf,

        [MaterialInfo(48)]
        MossyCobblestone,
        
        [MaterialInfo(49)]
        Obsidian,

        [MaterialInfo(50, typeof(ITorch))]
        Torch,

        [MaterialInfo(51)]
        Fire,

        [MaterialInfo(52)]
        MobSpawner,

        [MaterialInfo(53, typeof(Stairs))]
        WoodStairs,

        [MaterialInfo(54, typeof(Chest))]
        Chest,

        [MaterialInfo(55, typeof(RedstoneWire))]
        RedstoneWire,

        [MaterialInfo(56)]
        DiamondOre,

        [MaterialInfo(57)]
        DiamondBlock,

        [MaterialInfo(58)]
        Workbench,

        [MaterialInfo(59, typeof(Crop))]
        Crops,
        
        [MaterialInfo(60, typeof(MaterialData))]
        Soil,

        [MaterialInfo(61, typeof(IFurnace))]
        Furnace,

        [MaterialInfo(62, typeof(IFurnace))]
        BurningFurnace,

        [MaterialInfo(63, typeof(Sign))]
        SignPost,

        [MaterialInfo(64, typeof(Door))]
        WoodenDoor,

        [MaterialInfo(65, typeof(Ladder))]
        Ladder,

        [MaterialInfo(66, typeof(Rails))]
        Rails,

        [MaterialInfo(67, typeof(Stairs))]
        CobblestoneStairs,

        [MaterialInfo(68, 64, typeof(Sign))]
        WallSign,

        [MaterialInfo(69, typeof(Lever))]
        Lever,

        [MaterialInfo(70, typeof(PressurePlate))]
        StonePlate,

        [MaterialInfo(71, typeof(Door))]
        IronDoorBlock,

        [MaterialInfo(72, typeof(PressurePlate))]
        WoodPlate,

        [MaterialInfo(73)]
        RedstoneOre,

        [MaterialInfo(74)]
        GlowingRedstoneOre,

        [MaterialInfo(75, typeof(RedstoneTorch))]
        RedstoneTorchOff,

        [MaterialInfo(76, typeof(RedstoneTorch))]
        RedstoneTorchOn,

        [MaterialInfo(77, typeof(Button))]
        StoneButton,



    }

    public static class MaterialHelper
    {

        private static Material[] byId = new Material[383];
        private static Dictionary<string, Material> BY_NAME = new Dictionary<string, Material>();

        static MaterialHelper()
        {

            foreach (Material material in Enum.GetValues(typeof(Material)))
            {

                var mat = material.GetAttribute<MaterialInfoAttribute>();
                int id = mat.Id;

                if (byId.Length > id)
                {
                    byId[id] = material;
                }
                else
                {
                    byId = byId.Arrays_copyOfRange(0, id + 2);
                    byId[id] = material;
                }

                var name = Enum.GetName(typeof(Material), material);

                if (name == null)
                    continue;

                BY_NAME.Add(name, material);
            }

        }

        public static Material GetMaterial(int id)
        {
            if (byId.Length > id && id >= 0)
            {
                return byId[id];
            }
            else
            {
                return default(Material);
            }
        }

        public static Material GetMaterial(string name)
        {
            return BY_NAME[name];
        }

    }

    public static class MaterialExtensions
    {

        public static Type GetData(this Material material)
        {
            return GetAttribute(material).ConstructorInfo.DeclaringType;
        }

        public static MaterialData GetNewData(this Material material, byte raw)
        {
            var attribute = GetAttribute(material);

            if (attribute.ConstructorInfo != null)
                return (MaterialData)Activator.CreateInstance(attribute.ConstructorInfo.DeclaringType, attribute.Id, raw);

            return null;

        }

        private static MaterialInfoAttribute GetAttribute(Material material)
        {
            return material.GetAttribute<MaterialInfoAttribute>();
        }

        public static int GetId(this Material material)
        {
            return GetAttribute(material).Id;
        }

        public static string GetName(this Material material)
        {
            return Enum.GetName(typeof(Material), material);
        }

        public static bool IsBlock(this Material material)
        {
            return GetAttribute(material).Id < 256;
        }

        public static bool IsEdible(this Material material)
        {
            switch (material)
            {
                case BREAD:
                case CARROT_ITEM:
                case BAKED_POTATO:
                case POTATO_ITEM:
                case POISONOUS_POTATO:
                case GOLDEN_CARROT:
                case PUMPKIN_PIE:
                case COOKIE:
                case MELON:
                case MUSHROOM_SOUP:
                case RAW_CHICKEN:
                case COOKED_CHICKEN:
                case RAW_BEEF:
                case COOKED_BEEF:
                case RAW_FISH:
                case COOKED_FISH:
                case PORK:
                case GRILLED_PORK:
                case APPLE:
                case GOLDEN_APPLE:
                case ROTTEN_FLESH:
                case SPIDER_EYE:
                    return true;
                default:
                    return false;
            }
        }

        public static Material GetMaterial(int id)
        {
            if (byId.Length > id && id >= 0)
            {
                return byId[id];
            }
            else
            {
                return Material.None;
            }
        }

        public static Material GetMaterial(string name)
        {
            return BY_NAME[name];
        }

        public static Material MatchMaterial(string name)
        {

            Debug.Assert(name != null, "Name cannot be null");

            int tryParse;

            if (!int.TryParse(name, out tryParse))
            {

                string filtered = name.ToUpper();

                filtered = Regex.Replace(filtered, "\\s+", "_");
                filtered = Regex.Replace(filtered, "\\W", "");

                Material result = BY_NAME[filtered];

                return result;

            }

            return GetMaterial(tryParse);

        }

        public static bool IsRecord(this Material material)
        {

            var attrib = GetAttribute(material);

            return attrib.Id >= GetAttribute(Material.GOLD_RECORD).Id && attrib.Id <= GetAttribute(Material.RECORD_12).Id;

        }

        public static bool IsSolid(this Material material)
        {

            var attrib = GetAttribute(material);

            if (!IsBlock(material) || attrib.Id == 0)
            {
                return false;
            }
            switch (material)
            {
                case Material.Stone:
                case Material.Grass:
                case Material.Dirt:
                case Material.CobbleStone:
                case Material.Wood:
                case Material.Bedrock:
                case Material.Sand:
                case Material.Gravel:
                case Material.GoldOre:
                case Material.IronOre:
                case Material.CoalOre:
                case Material.Log:
                case Material.Leaves:
                case Material.Sponge:
                case Material.Glass:
                case Material.LapisOre:
                case Material.LapisBlock:
                case Material.Dispenser:
                case Material.Sandstone:
                case Material.NoteBlock:
                case Material.BedBlock:
                case Material.PistonStickyBase:
                case Material.PistonBase:
                case Material.PistonExtension:
                case Material.Wool:
                case Material.PistonMovingPiece:
                case Material.GOLD_BLOCK:
                case Material.IRON_BLOCK:
                case Material.DOUBLE_STEP:
                case Material.STEP:
                case Material.BRICK:
                case Material.TNT:
                case Material.BOOKSHELF:
                case Material.MOSSY_COBBLESTONE:
                case Material.OBSIDIAN:
                case Material.MOB_SPAWNER:
                case Material.WOOD_STAIRS:
                case Material.CHEST:
                case Material.DIAMOND_ORE:
                case Material.DIAMOND_BLOCK:
                case Material.WORKBENCH:
                case Material.SOIL:
                case Material.FURNACE:
                case Material.BURNING_FURNACE:
                case Material.SIGN_POST:
                case Material.WOODEN_DOOR:
                case Material.COBBLESTONE_STAIRS:
                case Material.WALL_SIGN:
                case Material.STONE_PLATE:
                case Material.IRON_DOOR_BLOCK:
                case Material.WOOD_PLATE:
                case Material.REDSTONE_ORE:
                case Material.GLOWING_REDSTONE_ORE:
                case Material.ICE:
                case Material.SNOW_BLOCK:
                case Material.CACTUS:
                case Material.CLAY:
                case Material.JUKEBOX:
                case Material.FENCE:
                case Material.PUMPKIN:
                case Material.NETHERRACK:
                case Material.SOUL_SAND:
                case Material.GLOWSTONE:
                case Material.JACK_O_LANTERN:
                case Material.CAKE_BLOCK:
                case Material.LOCKED_CHEST:
                case Material.TRAP_DOOR:
                case Material.MONSTER_EGGS:
                case Material.SMOOTH_BRICK:
                case Material.HUGE_MUSHROOM_1:
                case Material.HUGE_MUSHROOM_2:
                case Material.IRON_FENCE:
                case Material.THIN_GLASS:
                case Material.MELON_BLOCK:
                case Material.FENCE_GATE:
                case Material.BRICK_STAIRS:
                case Material.SMOOTH_STAIRS:
                case Material.MYCEL:
                case Material.NETHER_BRICK:
                case Material.NETHER_FENCE:
                case Material.NETHER_BRICK_STAIRS:
                case Material.ENCHANTMENT_TABLE:
                case Material.BREWING_STAND:
                case Material.CAULDRON:
                case Material.ENDER_PORTAL_FRAME:
                case Material.ENDER_STONE:
                case Material.DRAGON_EGG:
                case Material.REDSTONE_LAMP_OFF:
                case Material.REDSTONE_LAMP_ON:
                case Material.WOOD_DOUBLE_STEP:
                case Material.WOOD_STEP:
                case Material.SANDSTONE_STAIRS:
                case Material.EMERALD_ORE:
                case Material.ENDER_CHEST:
                case Material.EMERALD_BLOCK:
                case Material.SPRUCE_WOOD_STAIRS:
                case Material.BIRCH_WOOD_STAIRS:
                case Material.JUNGLE_WOOD_STAIRS:
                case Material.COMMAND:
                case Material.BEACON:
                case Material.COBBLE_WALL:
                case Material.ANVIL:
                case Material.TRAPPED_CHEST:
                case Material.GOLD_PLATE:
                case Material.IRON_PLATE:
                case Material.DAYLIGHT_DETECTOR:
                case Material.REDSTONE_BLOCK:
                case Material.QUARTZ_ORE:
                case Material.HOPPER:
                case Material.QUARTZ_BLOCK:
                case Material.QUARTZ_STAIRS:
                case Material.DROPPER:
                    return true;
                default:
                    return false;
            }
        }

        public static bool IsTransparent(this Material material)
        {

            var attrib = GetAttribute(material);

            if (!IsBlock(material))
            {
                return false;
            }

            switch (material)
            {
                case Material.AIR:
                case Material.SAPLING:
                case Material.POWERED_RAIL:
                case Material.DETECTOR_RAIL:
                case Material.LONG_GRASS:
                case Material.DEAD_BUSH:
                case Material.YELLOW_FLOWER:
                case Material.RED_ROSE:
                case Material.BROWN_MUSHROOM:
                case Material.RED_MUSHROOM:
                case Material.TORCH:
                case Material.FIRE:
                case Material.REDSTONE_WIRE:
                case Material.CROPS:
                case Material.LADDER:
                case Material.RAILS:
                case Material.LEVER:
                case Material.REDSTONE_TORCH_OFF:
                case Material.REDSTONE_TORCH_ON:
                case Material.STONE_BUTTON:
                case Material.SNOW:
                case Material.SUGAR_CANE_BLOCK:
                case Material.PORTAL:
                case Material.DIODE_BLOCK_OFF:
                case Material.DIODE_BLOCK_ON:
                case Material.PUMPKIN_STEM:
                case Material.MELON_STEM:
                case Material.VINE:
                case Material.WATER_LILY:
                case Material.NETHER_WARTS:
                case Material.ENDER_PORTAL:
                case Material.COCOA:
                case Material.TRIPWIRE_HOOK:
                case Material.TRIPWIRE:
                case Material.FLOWER_POT:
                case Material.CARROT:
                case Material.POTATO:
                case Material.WOOD_BUTTON:
                case Material.SKULL:
                case Material.REDSTONE_COMPARATOR_OFF:
                case Material.REDSTONE_COMPARATOR_ON:
                case Material.ACTIVATOR_RAIL:
                    return true;
                default:
                    return false;
            }
        }

        public static bool IsFlammable(this Material material)
        {
            if (!IsBlock(material))
            {
                return false;
            }
            switch (material)
            {
                case WOOD:
                case LOG:
                case LEAVES:
                case NOTE_BLOCK:
                case BED_BLOCK:
                case LONG_GRASS:
                case DEAD_BUSH:
                case WOOL:
                case TNT:
                case BOOKSHELF:
                case WOOD_STAIRS:
                case CHEST:
                case WORKBENCH:
                case SIGN_POST:
                case WOODEN_DOOR:
                case WALL_SIGN:
                case WOOD_PLATE:
                case JUKEBOX:
                case FENCE:
                case LOCKED_CHEST:
                case TRAP_DOOR:
                case HUGE_MUSHROOM_1:
                case HUGE_MUSHROOM_2:
                case VINE:
                case FENCE_GATE:
                case WOOD_DOUBLE_STEP:
                case WOOD_STEP:
                case SPRUCE_WOOD_STAIRS:
                case BIRCH_WOOD_STAIRS:
                case JUNGLE_WOOD_STAIRS:
                case TRAPPED_CHEST:
                case DAYLIGHT_DETECTOR:
                    return true;
                default:
                    return false;
            }
        }

        public static bool IsBurnable(this Material material)
        {

            if (!IsBlock(material))
            {
                return false;
            }
            switch (material)
            {
                case WOOD:
                case LOG:
                case LEAVES:
                case LONG_GRASS:
                case WOOL:
                case TNT:
                case BOOKSHELF:
                case WOOD_STAIRS:
                case FENCE:
                case VINE:
                case WOOD_DOUBLE_STEP:
                case WOOD_STEP:
                case SPRUCE_WOOD_STAIRS:
                case BIRCH_WOOD_STAIRS:
                case JUNGLE_WOOD_STAIRS:
                    return true;
                default:
                    return false;
            }
        }

        public static bool IsOccluding(this Material material)
        {
            if (!IsBlock(material))
            {
                return false;
            }
            switch (material)
            {
                case STONE:
                case GRASS:
                case DIRT:
                case COBBLESTONE:
                case WOOD:
                case BEDROCK:
                case SAND:
                case GRAVEL:
                case GOLD_ORE:
                case IRON_ORE:
                case COAL_ORE:
                case LOG:
                case SPONGE:
                case LAPIS_ORE:
                case LAPIS_BLOCK:
                case DISPENSER:
                case SANDSTONE:
                case NOTE_BLOCK:
                case WOOL:
                case GOLD_BLOCK:
                case IRON_BLOCK:
                case DOUBLE_STEP:
                case BRICK:
                case BOOKSHELF:
                case MOSSY_COBBLESTONE:
                case OBSIDIAN:
                case MOB_SPAWNER:
                case DIAMOND_ORE:
                case DIAMOND_BLOCK:
                case WORKBENCH:
                case FURNACE:
                case BURNING_FURNACE:
                case REDSTONE_ORE:
                case GLOWING_REDSTONE_ORE:
                case SNOW_BLOCK:
                case CLAY:
                case JUKEBOX:
                case PUMPKIN:
                case NETHERRACK:
                case SOUL_SAND:
                case JACK_O_LANTERN:
                case LOCKED_CHEST:
                case MONSTER_EGGS:
                case SMOOTH_BRICK:
                case HUGE_MUSHROOM_1:
                case HUGE_MUSHROOM_2:
                case MELON_BLOCK:
                case MYCEL:
                case NETHER_BRICK:
                case ENDER_PORTAL_FRAME:
                case ENDER_STONE:
                case REDSTONE_LAMP_OFF:
                case REDSTONE_LAMP_ON:
                case WOOD_DOUBLE_STEP:
                case EMERALD_ORE:
                case EMERALD_BLOCK:
                case COMMAND:
                case QUARTZ_ORE:
                case QUARTZ_BLOCK:
                case DROPPER:
                    return true;
                default:
                    return false;
            }
        }

        public static bool HasGravity(this Material material)
        {
            if (!IsBlock(material))
            {
                return false;
            }
            switch (material)
            {
                case SAND:
                case GRAVEL:
                case ANVIL:
                    return true;
                default:
                    return false;
            }
        }

    }

}
