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

        [MaterialInfo(43, typeof(Step))]
        DoubleStep,

        [MaterialInfo(44, typeof(Step))]
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

        [MaterialInfo(50, typeof(Torch))]
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

        [MaterialInfo(78)]
        Snow,

        [MaterialInfo(79)]
        Ice,

        [MaterialInfo(80)]
        SnowBlock,

        [MaterialInfo(81, typeof(MaterialData))]
        Cactus,

        [MaterialInfo(82)]
        Clay,

        [MaterialInfo(83, typeof(MaterialData))]
        SugarCaneBlock,

        [MaterialInfo(84)]
        JukeBox,

        [MaterialInfo(85)]
        Fence,

        [MaterialInfo(86, typeof(Pumpkin))]
        Pumpkin,

        [MaterialInfo(87)]
        Netherrack,

        [MaterialInfo(88)]
        SoulSand,

        [MaterialInfo(89)]
        GlowStone,

        [MaterialInfo(90)]
        Portal,

        [MaterialInfo(91, typeof(Pumpkin))]
        JackOLantern,

        [MaterialInfo(92, 64, typeof(Cake))]
        CakeBlock,

        [MaterialInfo(93, typeof(Diode))]
        DiodeBlockOff,

        [MaterialInfo(94, typeof(Diode))]
        DiodeBlockOn,

        [MaterialInfo(95)]
        LockedChest,

        [MaterialInfo(96, typeof(TrapDoor))]
        TrapDoor,

        [MaterialInfo(97, typeof(MonsterEggs))]
        MonsterEggs,

        [MaterialInfo(98, typeof(SmoothBrick))]
        SmoothBrick,

        [MaterialInfo(99, typeof(Mushroom))]
        HugeMushroom1,

        [MaterialInfo(100, typeof(Mushroom))]
        HugeMushroom2,

        [MaterialInfo(101)]
        IronFence,

        [MaterialInfo(102)]
        ThinGlass,

        [MaterialInfo(103)]
        MelonBlock,

        [MaterialInfo(104, typeof(MaterialData))]
        PumpkinStem,

        [MaterialInfo(105, typeof(MaterialData))]
        MelonStem,

        [MaterialInfo(106, typeof(Vine))]
        Vine,

        [MaterialInfo(107, typeof(Gate))]
        FenceGate,

        [MaterialInfo(108, typeof(Stairs))]
        BrickStairs,

        [MaterialInfo(109, typeof(Stairs))]
        SmoothStairs,

        [MaterialInfo(110)]
        Mycel,

        [MaterialInfo(111)]
        WaterLily,

        [MaterialInfo(112)]
        NetherBrick,

        [MaterialInfo(113)]
        NetherFence,

        [MaterialInfo(114, typeof(Stairs))]
        NetherBrickStairs,

        [MaterialInfo(115, typeof(NetherWarts))]
        NetherWarts,

        [MaterialInfo(116)]
        EnchantmentTable,

        [MaterialInfo(117, typeof(MaterialData))]
        BrewingStand,

        [MaterialInfo(118, typeof(Cauldron))]
        Cauldron,

        [MaterialInfo(119)]
        EnderPortal,

        [MaterialInfo(120)]
        EnderPortalFrame,

        [MaterialInfo(121)]
        EnderStone,

        [MaterialInfo(122)]
        DragonEgg,

        [MaterialInfo(123)]
        RedstoneLampOff,

        [MaterialInfo(124)]
        RedstoneLampOn,

        [MaterialInfo(125, typeof(WoodenStep))]
        WoodDoubleStep,

        [MaterialInfo(126, typeof(WoodenStep))]
        WoodStep,

        [MaterialInfo(127, typeof(CocoaPlant))]
        Cocoa,

        [MaterialInfo(128, typeof(Stairs))]
        SandstoneStairs,

        [MaterialInfo(129)]
        EmeraldOre,

        [MaterialInfo(130, typeof(EnderChest))]
        EnderChest,

        [MaterialInfo(131, typeof(TripwireHook))]
        TripwireHook,

        [MaterialInfo(132, typeof(Tripwire))]
        Tripwire,

        [MaterialInfo(133)]
        EmeraldBlock,

        [MaterialInfo(134, typeof(Stairs))]
        SpruceWoodStairs,

        [MaterialInfo(135, typeof(Stairs))]
        BirchWoodStairs,

        [MaterialInfo(136, typeof(Stairs))]
        JungleWoodStairs,

        [MaterialInfo(137, typeof(Command))]
        Command,

        [MaterialInfo(138)]
        Beacon,

        [MaterialInfo(139)]
        CobbleWall,

        [MaterialInfo(140, typeof(FlowerPot))]
        FlowerPot,

        [MaterialInfo(141)]
        Carrot,

        [MaterialInfo(142)]
        Potato,

        [MaterialInfo(143, typeof(Button))]
        WoodButton,

        [MaterialInfo(144, typeof(Skull))]
        Skull,

        [MaterialInfo(145)]
        Anvil,

        [MaterialInfo(146)]
        TrappedChest,

        [MaterialInfo(147)]
        GoldPlate,

        [MaterialInfo(148)]
        IronPlate,

        [MaterialInfo(149)]
        RedstoneComparatorOff,

        [MaterialInfo(150)]
        RedstoneComparatorOn,

        [MaterialInfo(151)]
        DaylightDetector,

        [MaterialInfo(152)]
        RedstoneBlock,

        [MaterialInfo(153)]
        QuartzOre,

        [MaterialInfo(154)]
        Hopper,

        [MaterialInfo(155)]
        QuartzBlock,

        [MaterialInfo(156, typeof(Stairs))]
        QuartzStairs,

        [MaterialInfo(157, typeof(PoweredRail))]
        ActivatorRail,

        [MaterialInfo(158, typeof(Dispenser))]
        Dropper,

        // ----- Item Separator -----

        [MaterialInfo(256, 1, 250)]
        IronSpade,

        [MaterialInfo(257, 1, 250)]
        IronPickAxe,

        [MaterialInfo(258, 1, 250)]
        IronAxe,

        [MaterialInfo(269, 1, 64)]
        FlintAndSteel,

        [MaterialInfo(260)]
        Apple,

        [MaterialInfo(261, 1, 384)]
        Bow,

        [MaterialInfo(262)]
        Arrow,

        [MaterialInfo(263, typeof(Coal))]
        Coal,

        [MaterialInfo(264)]
        Diamond,

        [MaterialInfo(265)]
        IronIngot,

        [MaterialInfo(266)]
        GoldIngot,

        [MaterialInfo(267, 1, 250)]
        IronSword,

        [MaterialInfo(268, 1, 59)]
        WoodSword,

        [MaterialInfo(269, 1, 59)]
        WoodSpade,

        [MaterialInfo(270, 1, 59)]
        WoodPickaxe,

        [MaterialInfo(271, 1, 59)]
        WoodAxe,

        [MaterialInfo(272, 1, 131)]
        StoneSword,

        [MaterialInfo(273, 1, 131)]
        StoneSpade,

        [MaterialInfo(274, 1, 131)]
        StonePickaxe,

        [MaterialInfo(275, 1, 132)]
        StoneAxe,

        [MaterialInfo(276, 1, 1561)]
        DiamondSword,

        [MaterialInfo(277, 1, 1561)]
        DiamondSpade,

        [MaterialInfo(278, 1, 1561)]
        DiamondPickaxe,

        [MaterialInfo(279, 1, 1561)]
        DiamondAxe,

        [MaterialInfo(280)]
        Stick,

        [MaterialInfo(281)]
        Bowl,

        [MaterialInfo(282, 1)]
        MushroomSoup,

        [MaterialInfo(283, 1, 32)]
        GoldSword,

        [MaterialInfo(284, 1, 32)]
        GoldSpade,

        [MaterialInfo(285, 1, 32)]
        GoldPickaxe,

        [MaterialInfo(286, 1, 32)]
        GoldAxe,

        [MaterialInfo(287)]
        String,

        [MaterialInfo(288)]
        Feather,

        [MaterialInfo(289)]
        Sulphur,

        [MaterialInfo(290, 1, 59)]
        WoodHoe,

        [MaterialInfo(291, 1, 131)]
        StoneHoe,

        [MaterialInfo(292, 1, 250)]
        IronHoe,

        [MaterialInfo(293, 1, 1561)]
        DiamondHoe,

        [MaterialInfo(294, 1, 32)]
        GoldHoe,

        [MaterialInfo(295)]
        Seeds,

        [MaterialInfo(296)]
        Wheat,

        [MaterialInfo(297)]
        Bread,

        [MaterialInfo(298, 1, 55)]
        LeatherHelmet,

        [MaterialInfo(299, 1, 80)]
        LeatherChestplate,

        [MaterialInfo(300, 1, 75)]
        LeatherLeggings,

        [MaterialInfo(301, 1, 65)]
        LeatherBoots,

        [MaterialInfo(302, 1, 165)]
        ChainmailHelmet,

        [MaterialInfo(303, 1, 240)]
        ChainmailChestplate,

        [MaterialInfo(304, 1, 225)]
        ChainmailLeggings,

        [MaterialInfo(305, 1, 195)]
        ChainmailBoots,

        [MaterialInfo(306, 1, 165)]
        IronHelmet,

        [MaterialInfo(307, 1, 240)]
        IronChestplate,

        [MaterialInfo(308, 1, 225)]
        IronLeggings,

        [MaterialInfo(309, 1, 195)]
        IronBoots,

        [MaterialInfo(310, 1, 363)]
        DiamondHelmet,

        [MaterialInfo(311, 1, 528)]
        DiamondChestplate,

        [MaterialInfo(312, 1, 495)]
        DiamondLeggings,

        [MaterialInfo(313, 1, 429)]
        DiamondBoots,

        [MaterialInfo(314, 1, 77)]
        GoldHelmet,

        [MaterialInfo(315, 1, 112)]
        GoldChestplate,

        [MaterialInfo(316, 1, 105)]
        GoldLeggings,

        [MaterialInfo(317, 1, 91)]
        GoldBoots,

        [MaterialInfo(318)]
        Flint,

        [MaterialInfo(319)]
        Pork,

        [MaterialInfo(320)]
        GrilledPork,

        [MaterialInfo(321)]
        Painting,

        [MaterialInfo(322)]
        GoldenApple,

        [MaterialInfo(323, 16)]
        Sign,

        [MaterialInfo(324, 1)]
        WoodDoor,

        [MaterialInfo(325, 16)]
        Bucket,

        [MaterialInfo(326, 1)]
        WaterBucket,

        [MaterialInfo(327, 1)]
        LavaBucket,

        [MaterialInfo(328, 1)]
        Minecart,

        [MaterialInfo(329, 1)]
        Saddle,

        [MaterialInfo(330, 1)]
        IronDoor,

        [MaterialInfo(331)]
        Redstone,

        [MaterialInfo(332, 16)]
        Snowball,

        [MaterialInfo(333, 1)]
        Boat,

        [MaterialInfo(334)]
        Leather,

        [MaterialInfo(335, 1)]
        MilkBucket,

        [MaterialInfo(336)]
        ClayBrick,

        [MaterialInfo(337)]
        ClayBall,

        [MaterialInfo(338)]
        SugarCane,

        [MaterialInfo(339)]
        Paper,

        [MaterialInfo(340)]
        Book,

        [MaterialInfo(341)]
        SlimeBall,

        [MaterialInfo(342, 1)]
        StorageMinecart,

        [MaterialInfo(343, 1)]
        PoweredMinecart,

        [MaterialInfo(344, 16)]
        Egg,

        [MaterialInfo(345)]
        Compass,

        [MaterialInfo(346, 1, 64)]
        FishingRod,

        [MaterialInfo(347)]
        Watch,

        [MaterialInfo(348)]
        GlowstoneDust,

        [MaterialInfo(349)]
        RawFish,

        [MaterialInfo(350)]
        CookedFish,

        [MaterialInfo(351, typeof(Dye))]
        InkSack,

        [MaterialInfo(352)]
        Bone,

        [MaterialInfo(353)]
        Sugar,

        [MaterialInfo(354, 1)]
        Cake,

        [MaterialInfo(355, 1)]
        Bed,

        [MaterialInfo(356)]
        Diode,

        [MaterialInfo(357)]
        Cookie,

        [MaterialInfo(358, typeof(MaterialData))]
        Map,

        [MaterialInfo(359, 1, 238)]
        Shears,

        [MaterialInfo(360)]
        Melon,

        [MaterialInfo(361)]
        PumpkinSeeds,

        [MaterialInfo(362)]
        MelonSeeds,

        [MaterialInfo(363)]
        RawBeef,

        [MaterialInfo(364)]
        CookedBeef,

        [MaterialInfo(365)]
        RawChicken,

        [MaterialInfo(366)]
        CookedChicken,

        [MaterialInfo(367)]
        RottenFlesh,

        [MaterialInfo(368, 16)]
        EnderPearl,

        [MaterialInfo(369)]
        BlazeRod,

        [MaterialInfo(370)]
        GhastTear,

        [MaterialInfo(371)]
        GoldNugget,

        [MaterialInfo(372)]
        NetherStalk,

        [MaterialInfo(373, 1, typeof(MaterialData))]
        Potion,

        [MaterialInfo(374)]
        GlassBottle,

        [MaterialInfo(375)]
        SpiderEye,

        [MaterialInfo(376)]
        FermentedSpiderEye,

        [MaterialInfo(377)]
        BlazePowder,

        [MaterialInfo(378)]
        MagmaCream,

        [MaterialInfo(379)]
        BrewingStandItem,

        [MaterialInfo(380)]
        CauldronItem,

        [MaterialInfo(381)]
        EyeOfEnder,

        [MaterialInfo(382)]
        SpeckledMelon,

        [MaterialInfo(383, 64, typeof(SpawnEgg))]
        MonsterEgg,

        [MaterialInfo(384, 64)]
        ExpBottle,

        [MaterialInfo(385, 64)]
        Fireball,

        [MaterialInfo(386, 1)]
        BookAndQuill,

        [MaterialInfo(387, 1)]
        WrittenBook,

        [MaterialInfo(388, 64)]
        Emerald,

        [MaterialInfo(389)]
        ItemFrame,

        [MaterialInfo(390)]
        FlowerpotItem,

        [MaterialInfo(391)]
        CarrotItem,

        [MaterialInfo(392)]
        PotatoItem,

        [MaterialInfo(393)]
        BakedPotato,

        [MaterialInfo(394)]
        PoisonousPotato,

        [MaterialInfo(395)]
        EmptyMap,

        [MaterialInfo(396)]
        GoldenCarrot,

        [MaterialInfo(397)]
        SkullItem,

        [MaterialInfo(398, 1, 25)]
        CarrotStick,

        [MaterialInfo(399)]
        NetherStar,

        [MaterialInfo(400)]
        PumpkinPie,

        [MaterialInfo(401)]
        Firework,

        [MaterialInfo(402)]
        FireworkCharge,

        [MaterialInfo(403)]
        EnchantedBook,

        [MaterialInfo(404)]
        RedstoneComparator,

        [MaterialInfo(405)]
        NetherBrickItem,

        [MaterialInfo(406)]
        Quartz,

        [MaterialInfo(407, 1)]
        ExplosiveMinecart,

        [MaterialInfo(408, 1)]
        HopperMinecart,

        [MaterialInfo(2256, 1)]
        GoldRecord,

        [MaterialInfo(2257, 1)]
        GreenRecord,

        [MaterialInfo(2258, 1)]
        Record3,

        [MaterialInfo(2259, 1)]
        Record4,

        [MaterialInfo(2260, 1)]
        Record5,

        [MaterialInfo(2261, 1)]
        Record6,

        [MaterialInfo(2262, 1)]
        Record7,

        [MaterialInfo(2263, 1)]
        Record8,

        [MaterialInfo(2264, 1)]
        Record9,

        [MaterialInfo(2265, 1)]
        Record10,

        [MaterialInfo(2266, 1)]
        Record11,

        [MaterialInfo(2267, 1)]
        Record12

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
                case Material.Bread:
                case Material.CarrotItem:
                case Material.BakedPotato:
                case Material.PotatoItem:
                case Material.PoisonousPotato:
                case Material.GoldenCarrot:
                case Material.PumpkinPie:
                case Material.Cookie:
                case Material.Melon:
                case Material.MushroomSoup:
                case Material.RawChicken:
                case Material.CookedChicken:
                case Material.RawBeef:
                case Material.CookedBeef:
                case Material.RawFish:
                case Material.CookedFish:
                case Material.Pork:
                case Material.GrilledPork:
                case Material.Apple:
                case Material.GoldenApple:
                case Material.RottenFlesh:
                case Material.SpiderEye:
                    return true;
                default:
                    return false;
            }
        }

        public static bool IsRecord(this Material material)
        {

            var attrib = GetAttribute(material);

            return attrib.Id >= GetAttribute(Material.GoldRecord).Id && attrib.Id <= GetAttribute(Material.Record12).Id;

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
                case Material.GoldBlock:
                case Material.IronBlock:
                case Material.DoubleStep:
                case Material.Step:
                case Material.Brick:
                case Material.Tnt:
                case Material.BookShelf:
                case Material.MossyCobblestone:
                case Material.Obsidian:
                case Material.MobSpawner:
                case Material.WoodStairs:
                case Material.Chest:
                case Material.DiamondOre:
                case Material.DiamondBlock:
                case Material.Workbench:
                case Material.Soil:
                case Material.Furnace:
                case Material.BurningFurnace:
                case Material.SignPost:
                case Material.WoodenDoor:
                case Material.CobblestoneStairs:
                case Material.WallSign:
                case Material.StonePlate:
                case Material.IronDoorBlock:
                case Material.WoodPlate:
                case Material.RedstoneOre:
                case Material.GlowingRedstoneOre:
                case Material.Ice:
                case Material.SnowBlock:
                case Material.Cactus:
                case Material.Clay:
                case Material.JukeBox:
                case Material.Fence:
                case Material.Pumpkin:
                case Material.Netherrack:
                case Material.SoulSand:
                case Material.GlowStone:
                case Material.JackOLantern:
                case Material.CakeBlock:
                case Material.LockedChest:
                case Material.TrapDoor:
                case Material.MonsterEggs:
                case Material.SmoothBrick:
                case Material.HugeMushroom1:
                case Material.HugeMushroom2:
                case Material.IronFence:
                case Material.ThinGlass:
                case Material.MelonBlock:
                case Material.FenceGate:
                case Material.BrickStairs:
                case Material.SmoothStairs:
                case Material.Mycel:
                case Material.NetherBrick:
                case Material.NetherFence:
                case Material.NetherBrickStairs:
                case Material.EnchantmentTable:
                case Material.BrewingStand:
                case Material.Cauldron:
                case Material.EnderPortalFrame:
                case Material.EnderStone:
                case Material.DragonEgg:
                case Material.RedstoneLampOff:
                case Material.RedstoneLampOn:
                case Material.WoodDoubleStep:
                case Material.WoodStep:
                case Material.SandstoneStairs:
                case Material.EmeraldOre:
                case Material.EnderChest:
                case Material.EmeraldBlock:
                case Material.SpruceWoodStairs:
                case Material.BirchWoodStairs:
                case Material.JungleWoodStairs:
                case Material.Command:
                case Material.Beacon:
                case Material.CobbleWall:
                case Material.Anvil:
                case Material.TrappedChest:
                case Material.GoldPlate:
                case Material.IronPlate:
                case Material.DaylightDetector:
                case Material.RedstoneBlock:
                case Material.QuartzOre:
                case Material.Hopper:
                case Material.QuartzBlock:
                case Material.QuartzStairs:
                case Material.Dropper:
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
                case Material.Air:
                case Material.Sapling:
                case Material.PoweredRail:
                case Material.DetectorRail:
                case Material.LongGrass:
                case Material.DeadBush:
                case Material.YellowFlower:
                case Material.RedRose:
                case Material.BrownMushroom:
                case Material.RedMushroom:
                case Material.Torch:
                case Material.Fire:
                case Material.RedstoneWire:
                case Material.Crops:
                case Material.Ladder:
                case Material.Rails:
                case Material.Lever:
                case Material.RedstoneTorchOff:
                case Material.RedstoneTorchOn:
                case Material.StoneButton:
                case Material.Snow:
                case Material.SugarCaneBlock:
                case Material.Portal:
                case Material.DiodeBlockOff:
                case Material.DiodeBlockOn:
                case Material.PumpkinStem:
                case Material.MelonStem:
                case Material.Vine:
                case Material.WaterLily:
                case Material.NetherWarts:
                case Material.EnderPortal:
                case Material.Cocoa:
                case Material.TripwireHook:
                case Material.Tripwire:
                case Material.FlowerPot:
                case Material.Carrot:
                case Material.Potato:
                case Material.WoodButton:
                case Material.Skull:
                case Material.RedstoneComparatorOff:
                case Material.RedstoneComparatorOn:
                case Material.ActivatorRail:
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
                case Material.Wood:
                case Material.Log:
                case Material.Leaves:
                case Material.NoteBlock:
                case Material.BedBlock:
                case Material.LongGrass:
                case Material.DeadBush:
                case Material.Wool:
                case Material.Tnt:
                case Material.BookShelf:
                case Material.WoodStairs:
                case Material.Chest:
                case Material.Workbench:
                case Material.SignPost:
                case Material.WoodenDoor:
                case Material.WallSign:
                case Material.WoodPlate:
                case Material.JukeBox:
                case Material.Fence:
                case Material.LockedChest:
                case Material.TrapDoor:
                case Material.HugeMushroom1:
                case Material.HugeMushroom2:
                case Material.Vine:
                case Material.FenceGate:
                case Material.WoodDoubleStep:
                case Material.WoodStep:
                case Material.SpruceWoodStairs:
                case Material.BirchWoodStairs:
                case Material.JungleWoodStairs:
                case Material.TrappedChest:
                case Material.DaylightDetector:
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
                case Material.Wood:
                case Material.Log:
                case Material.Leaves:
                case Material.LongGrass:
                case Material.Wool:
                case Material.Tnt:
                case Material.BookShelf:
                case Material.WoodStairs:
                case Material.Fence:
                case Material.Vine:
                case Material.WoodDoubleStep:
                case Material.WoodStep:
                case Material.SpruceWoodStairs:
                case Material.BirchWoodStairs:
                case Material.JungleWoodStairs:
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
                case Material.Sponge:
                case Material.LapisOre:
                case Material.LapisBlock:
                case Material.Dispenser:
                case Material.Sandstone:
                case Material.NoteBlock:
                case Material.Wool:
                case Material.GoldBlock:
                case Material.IronBlock:
                case Material.DoubleStep:
                case Material.Brick:
                case Material.BookShelf:
                case Material.MossyCobblestone:
                case Material.Obsidian:
                case Material.MobSpawner:
                case Material.DiamondOre:
                case Material.DiamondBlock:
                case Material.Workbench:
                case Material.Furnace:
                case Material.BurningFurnace:
                case Material.RedstoneOre:
                case Material.GlowingRedstoneOre:
                case Material.SnowBlock:
                case Material.Clay:
                case Material.JukeBox:
                case Material.Pumpkin:
                case Material.Netherrack:
                case Material.SoulSand:
                case Material.JackOLantern:
                case Material.LockedChest:
                case Material.MonsterEggs:
                case Material.SmoothBrick:
                case Material.HugeMushroom1:
                case Material.HugeMushroom2:
                case Material.MelonBlock:
                case Material.Mycel:
                case Material.NetherBrick:
                case Material.EnderPortalFrame:
                case Material.EnderStone:
                case Material.RedstoneLampOff:
                case Material.RedstoneLampOn:
                case Material.WoodDoubleStep:
                case Material.EmeraldOre:
                case Material.EmeraldBlock:
                case Material.Command:
                case Material.QuartzOre:
                case Material.QuartzBlock:
                case Material.Dropper:
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
                case Material.Sand:
                case Material.Gravel:
                case Material.Anvil:
                    return true;
                default:
                    return false;
            }
        }

    }

}
