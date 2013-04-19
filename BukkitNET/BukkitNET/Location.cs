using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BukkitNET.Extensions;
using BukkitNET.Util;

namespace BukkitNET
{
    public class Location
    {

        private World world;
        private double x;
        private double y;
        private double z;
        private float pitch;
        private float yaw;

        public World World
        {
            get
            {
                return world;
            }
            set
            {
                world = value;
            }
        }

        public double X
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
            }
        }

        public double Y
        {
            get
            {
                return y;
            }
            set
            {
                y = value;
            }
        }

        public double Z
        {
            get
            {
                return z;
            }
            set
            {
                z = value;
            }
        }

        public Chunck Chunk
        {
            get
            {

            }
        }

        public Block Block
        {
            get
            {

            }
        }

        public int BlockX
        {
            get
            {
                return LocToBlock(x);
            }
        }

        public int BlockY
        {
            get
            {
                return LocToBlock(y);
            }
        }

        public int BlockZ
        {
            get
            {
                return LocToBlock(z);
            }
        }

        public float Yaw
        {
            get
            {
                return yaw;
            }
            set
            {
                yaw = value;
            }
        }

        public float Pitch
        {
            get
            {
                return pitch;
            }
            set
            {
                pitch = value;
            }
        }

        public Location(World world, double x, double y, double z)
            : this(world, x, y, z, 0, 0)
        {
        }

        public Location(World world, double x, double y, double z, float yaw, float pitch)
        {
            this.world = world;
            this.x = x;
            this.y = y;
            this.z = z;
            this.pitch = pitch;
            this.yaw = yaw;
        }

        public Vector GetDirection()
        {

            Vector vector = new Vector();

            double rotX = yaw;
            double rotY = pitch;

            vector.Y = (-Math.Sin(rotY.ToRadians()));

            double h = Math.Cos(rotY.ToRadians());

            vector.X = -h * Math.Sin(rotX.ToRadians());
            vector.Z = h * Math.Cos(rotX.ToRadians());

            return vector;

        }

        public Location Add(Location vec)
        {
            if (vec == null || vec.World != world)
            {
                throw new ArgumentException("Cannot add Locations of differing worlds");
            }

            x += vec.x;
            y += vec.y;
            z += vec.z;
            return this;
        }

        public Location Add(Vector vec)
        {
            this.x += vec.X;
            this.y += vec.Y;
            this.z += vec.Z;
            return this;
        }

        public Location Add(double x, double y, double z)
        {
            this.x += x;
            this.y += y;
            this.z += z;
            return this;
        }

        public Location Subtract(Location vec)
        {
            if (vec == null || vec.World != world)
            {
                throw new ArgumentException("Cannot add Locations of differing worlds");
            }

            x -= vec.x;
            y -= vec.y;
            z -= vec.z;
            return this;
        }

        public Location Subtract(Vector vec)
        {
            this.x -= vec.X;
            this.y -= vec.Y;
            this.z -= vec.Z;
            return this;
        }

        public Location Subtract(double x, double y, double z)
        {
            this.x -= x;
            this.y -= y;
            this.z -= z;
            return this;
        }

        public double Length()
        {
            return Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2) + Math.Pow(z, 2));
        }

        public double LengthSquared()
        {
            return Math.Pow(x, 2) + Math.Pow(y, 2) + Math.Pow(z, 2);
        }

        public double Distance(Location o)
        {
            return Math.Sqrt(DistanceSquared(o));
        }

        public double DistanceSquared(Location o)
        {
            if (o == null)
            {
                throw new ArgumentException("Cannot measure distance to a null location");
            }
            else if (o.World == null || world == null)
            {
                throw new ArgumentException("Cannot measure distance to a null world");
            }
            else if (o.World != world)
            {
                throw new ArgumentException("Cannot measure distance between " + world.Name + " and " + o.World.Name);
            }

            return Math.Pow(x - o.x, 2) + Math.Pow(y - o.y, 2) + Math.Pow(z - o.z, 2);
        }

        public Location Multiply(double m)
        {
            x *= m;
            y *= m;
            z *= m;
            return this;
        }

        public Location Zero()
        {
            x = 0;
            y = 0;
            z = 0;
            return this;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (GetType() != obj.GetType())
            {
                return false;
            }

            Location other = (Location)obj;

            if (this.world != other.world && (this.world == null || !this.world.Equals(other.world)))
            {
                return false;
            }
            if (BitConverter.DoubleToInt64Bits(this.x) != BitConverter.DoubleToInt64Bits(other.x))
            {
                return false;
            }
            if (BitConverter.DoubleToInt64Bits(this.y) != BitConverter.DoubleToInt64Bits(other.y))
            {
                return false;
            }
            if (BitConverter.DoubleToInt64Bits(this.z) != BitConverter.DoubleToInt64Bits(other.z))
            {
                return false;
            }
            if (this.pitch.SingleToInt32Bits() != other.pitch.SingleToInt32Bits())
            {
                return false;
            }
            if (this.yaw.SingleToInt32Bits() != other.yaw.SingleToInt32Bits())
            {
                return false;
            }
            return true;
        }

        public override int GetHashCode()
        {
            int hash = 3;

            hash = 19 * hash + (this.world != null ? this.world.GetHashCode() : 0);
            hash = 19 * hash + (int)(BitConverter.DoubleToInt64Bits(this.x) ^ ((uint)BitConverter.DoubleToInt64Bits(this.x) >> 32));
            hash = 19 * hash + (int)(BitConverter.DoubleToInt64Bits(this.y) ^ ((uint)BitConverter.DoubleToInt64Bits(this.y) >> 32));
            hash = 19 * hash + (int)(BitConverter.DoubleToInt64Bits(this.z) ^ ((uint)BitConverter.DoubleToInt64Bits(this.z) >> 32));
            hash = 19 * hash + this.pitch.SingleToInt32Bits();
            hash = 19 * hash + this.yaw.SingleToInt32Bits();
            return hash;
        }

        public override string ToString()
        {
            return "Location{" + "world=" + world + ",x=" + x + ",y=" + y + ",z=" + z + ",pitch=" + pitch + ",yaw=" + yaw + '}';
        }

        public Vector ToVector()
        {
            return new Vector(x, y, z);
        }

        public Location Clone()
        {
            throw new NotImplementedException();
        }

        public static int LocToBlock(double loc)
        {
            return (int)Math.Floor(loc);
        }

    }
}
