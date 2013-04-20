using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using BukkitNET.Inventory;
using BukkitNET.Metadata;

namespace BukkitNET.Block
{
    public interface IBlock : IMetadatable
    {

        byte GetData();

        IBlock GetRelative(int modX, int modY, int modZ);

        IBlock GetRelative(BlockFace face);

        IBlock GetRelative(BlockFace face, int distance);

        Material GetType();

        int GetTypeId();

        byte GetLightLevel();

        byte GetLightFromSky();

        byte GetLightFromBlocks();

        IWorld GetWorld();

        int GetX();

        int GetY();

        int GetZ();

        Location GetLocation();

        Location GetLocation(Location loc);

        IChunk GetChunk();

        void SetData(byte data);

        void SetData(byte data, bool applyPhysics);

        void SetType(Material material);

        bool SetTypeId(int type);

        bool SetTypeId(int type, bool applyPhysics);

        bool SetTypeIdAndData(int type, byte data,  bool applyPhysics);

        BlockFace GetFace(IBlock block);

        IBlockState GetState();

        Biome GetBiome();

        void SetBiome(Biome bio);

        bool IsBlockPowered();

        bool IsBlockIndirectlyPowered();

        bool IsBlockFacePowered(BlockFace face);

        bool IsBlockFaceIndirectlyPowered(BlockFace face);

        int GetBlockPower(BlockFace face);

        int GetBlockPower();

        bool IsEmpty();

        bool IsLiquid();

        double GetTemperature();

        double GetHumidity();

        PistonMoveReaction GetPistonMoveReaction();

        bool BreakNaturally();

        bool BreakNaturally(ItemStack tool);

        Collection<ItemStack> GetDrops();

        Collection<ItemStack> GetDrops(ItemStack tool);

    }
}
