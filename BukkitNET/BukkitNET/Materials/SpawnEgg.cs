using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BukkitNET.Entities;

namespace BukkitNET.Materials
{
    public class SpawnEgg : MaterialData
    {

        public EntityType SpawnedType
        {
            get
            {
                return EntityTypeHelper.FromId(Data);
            }
            set
            {
                Data = ((byte)value.GetEntityTypeId());
            }
        }

        public SpawnEgg()
            : base(Material.MonsterEgg)
        {
        }

        public SpawnEgg(byte data)
            : base(Material.MonsterEgg, data)
        {
        }

        public SpawnEgg(EntityType type)
            : this()
        {
            SpawnedType = type;
        }

        public SpawnEgg(int type)
            : base(type)
        {
        }

        public SpawnEgg(Material type)
            : base(type)
        {
        }

        public SpawnEgg(int type, byte data)
            : base(type, data)
        {
        }

        public SpawnEgg(Material type, byte data)
            : base(type, data)
        {
        }

        public override string ToString()
        {
            return "SPAWN EGG{" + SpawnedType + "}";
        }

    }
}
