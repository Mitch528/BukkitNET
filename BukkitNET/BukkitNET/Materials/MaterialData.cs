using System;
using BukkitNET.Inventory;

namespace BukkitNET.Materials
{
    public class MaterialData
    {

        private readonly int type;
        private byte data = 0;

        public byte Data
        {
            get
            {
                return data;
            }
            set
            {
                data = value;
            }
        }

        public Material ItemType
        {
            get
            {
                return Material.GetMaterial(type);
            }
        }

        public int TypeId
        {
            get
            {
                return type;
            }
        }

        public MaterialData(int type)
            : this(type, (byte)0)
        {
        }

        public MaterialData(Material type)
            : this(type, (byte)0)
        {
        }

        public MaterialData(int type, byte data)
        {
            this.type = type;
            this.data = data;
        }

        public MaterialData(Material type, byte data)
            : this(type.Id, data)
        {
        }

        public ItemStack ToItemStack()
        {
            return new ItemStack(type, 0, data);
        }

        public ItemStack ToItemStack(int amount)
        {
            return new ItemStack(type, amount, data);
        }

        public override string ToString()
        {
            return type + "(" + data + ")";
        }

        public override int GetHashCode()
        {
            return ((type << 8) ^ data);
        }

        public override bool Equals(Object obj)
        {
            if (obj != null && obj is MaterialData)
            {
                MaterialData md = (MaterialData)obj;

                return (md.TypeId == type && md.Data == data);
            }
            else
            {
                return false;
            }
        }

        public MaterialData Clone()
        {
            throw new NotImplementedException();
        }

    }
}
