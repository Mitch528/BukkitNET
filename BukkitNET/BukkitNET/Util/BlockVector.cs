using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BukkitNET.Util
{
    public class BlockVector : Vector
    {

        public BlockVector()
        {
            this.x = 0;
            this.y = 0;
            this.z = 0;
        }

        public BlockVector(Vector vec)
        {
            this.x = vec.X;
            this.y = vec.Y;
            this.z = vec.Z;
        }

        public BlockVector(int x, int y, int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public BlockVector(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public BlockVector(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public override bool Equals(Object obj)
        {
            if (!(obj is BlockVector))
            {
                return false;
            }
            BlockVector other = (BlockVector)obj;

            return (int)other.X == (int)this.x && (int)other.Y == (int)this.y && (int)other.Z == (int)this.z;

        }

        public override int GetHashCode()
        {
            return (((int)x).GetHashCode() >> 13) ^ (((int)y).GetHashCode() >> 7) ^ ((int)z).GetHashCode();
        }

        public new static BlockVector Deserialize(Dictionary<String, Object> args)
        {
            double x = 0;
            double y = 0;
            double z = 0;

            if (args.ContainsKey("x"))
            {
                x = (double)args["x"];
            }
            if (args.ContainsKey("y"))
            {
                y = (double)args["y"];
            }
            if (args.ContainsKey("z"))
            {
                z = (double)args["z"];
            }

            return new BlockVector(x, y, z);
        }

    }
}
