using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BukkitNET.Materials;
using BukkitNET.Metadata;

namespace BukkitNET.Block
{
    public interface IBlockState : IMetadatable
    {

        IBlock GetBlock();

        MaterialData GetData();

        Material GetMaterialType();

        int GetTypeId();

        int GetLightLevel();

        IWorld GetWorld();

        int GetX();

        int GetY();

        int GetZ();

        Location GetLocation();

        Location GetLocation(Location loc);

        IChunk GetChunk();

        void SetData(MaterialData data);

        void SetType(Material type);

        bool SetTypeId(int type);

        bool Update();

        bool Update(bool force);

        bool Update(bool force, bool applyPhysics);

        byte GetRawData();

        void SetRawData(byte data);

    }
}
