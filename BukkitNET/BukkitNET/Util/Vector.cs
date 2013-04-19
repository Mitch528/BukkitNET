using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BukkitNET.Util
{
    public class Vector
    {

        private static Random random = new Random();

        private static readonly double epsilon = 0.000001;

        protected double x;
        protected double y;
        protected double z;

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

        public int BlockX
        {
            get
            {
                return (int)Math.Floor(x);
            }
        }

        public int BlockY
        {
            get
            {
                return (int)Math.Floor(y);
            }
        }

        public int BlockZ
        {
            get
            {
                return (int)Math.Floor(z);
            }
        }

        public Vector()
        {
            this.x = 0;
            this.y = 0;
            this.z = 0;
        }

        public Vector(int x, int y, int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public Vector(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public Vector(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public Vector Add(Vector vec)
        {
            x += vec.x;
            y += vec.y;
            z += vec.z;
            return this;
        }

        public Vector Subtract(Vector vec)
        {
            x -= vec.x;
            y -= vec.y;
            z -= vec.z;
            return this;
        }

        public Vector Multiply(Vector vec)
        {
            x *= vec.x;
            y *= vec.y;
            z *= vec.z;
            return this;
        }

        public Vector Divide(Vector vec)
        {
            x /= vec.x;
            y /= vec.y;
            z /= vec.z;
            return this;
        }

        public Vector Copy(Vector vec)
        {
            x = vec.x;
            y = vec.y;
            z = vec.z;
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

        public double Distance(Vector o)
        {
            return Math.Sqrt(Math.Pow(x - o.x, 2) + Math.Pow(y - o.y, 2) + Math.Pow(z - o.z, 2));
        }

        public double DistanceSquared(Vector o)
        {
            return Math.Pow(x - o.x, 2) + Math.Pow(y - o.y, 2) + Math.Pow(z - o.z, 2);
        }

        public float Angle(Vector other)
        {
            double dot = Dot(other) / (Length() * other.Length());

            return (float)Math.Acos(dot);
        }

        public Vector Midpoint(Vector other)
        {
            x = (x + other.x) / 2;
            y = (y + other.y) / 2;
            z = (z + other.z) / 2;
            return this;
        }

        public Vector GetMidpoint(Vector other)
        {
            double x = (this.x + other.x) / 2;
            double y = (this.y + other.y) / 2;
            double z = (this.z + other.z) / 2;
            return new Vector(x, y, z);
        }

        public Vector Multiply(int m)
        {
            x *= m;
            y *= m;
            z *= m;
            return this;
        }

        public Vector Multiply(double m)
        {
            x *= m;
            y *= m;
            z *= m;
            return this;
        }

        public Vector Multiply(float m)
        {
            x *= m;
            y *= m;
            z *= m;
            return this;
        }

        public double Dot(Vector other)
        {
            return x * other.x + y * other.y + z * other.z;
        }

        public Vector CrossProduct(Vector o)
        {
            double newX = y * o.z - o.y * z;
            double newY = z * o.x - o.z * x;
            double newZ = x * o.y - o.x * y;

            x = newX;
            y = newY;
            z = newZ;
            return this;
        }

        public Vector Normalize()
        {
            double length = Length();

            x /= length;
            y /= length;
            z /= length;

            return this;
        }

        public Vector Zero()
        {
            x = 0;
            y = 0;
            z = 0;
            return this;
        }

        public bool IsInAABB(Vector min, Vector max)
        {
            return x >= min.x && x <= max.x && y >= min.y && y <= max.y && z >= min.z && z <= max.z;
        }

        public bool IsInSphere(Vector origin, double radius)
        {
            return (Math.Pow(origin.x - x, 2) + Math.Pow(origin.y - y, 2) + Math.Pow(origin.z - z, 2)) <= Math.Pow(radius, 2);
        }

        public override bool Equals(object obj)
        {

            if (!(obj is Vector))
            {
                return false;
            }

            Vector other = (Vector)obj;

            return Math.Abs(x - other.x) < epsilon && Math.Abs(y - other.y) < epsilon && Math.Abs(z - other.z) < epsilon && (this.GetType() == obj.GetType());

        }

        public override int GetHashCode()
        {
            int hash = 7;

            hash = 79 * hash + (int)(BitConverter.DoubleToInt64Bits(this.x) ^ ((uint)BitConverter.DoubleToInt64Bits(this.x) >> 32));
            hash = 79 * hash + (int)(BitConverter.DoubleToInt64Bits(this.y) ^ ((uint)BitConverter.DoubleToInt64Bits(this.y) >> 32));
            hash = 79 * hash + (int)(BitConverter.DoubleToInt64Bits(this.z) ^ ((uint)BitConverter.DoubleToInt64Bits(this.z) >> 32));
            return hash;
        }

        public Dictionary<string, object> Serialize()
        {

            var dict = new Dictionary<string, object>();

            dict.Add("x", x);
            dict.Add("y", y);
            dict.Add("z", z);

            return dict;

        }

        public Vector Clone()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return x + "," + y + "," + z;
        }

        public Location ToLocation(World world)
        {
            return new Location(world, x, y, z);
        }

        public Location ToLocation(World world, float yaw, float pitch)
        {
            return new Location(world, x, y, z, yaw, pitch);
        }

        public BlockVector ToBlockVector()
        {
            return new BlockVector(x, y, z);
        }

        public static double GetEpsilon()
        {
            return epsilon;
        }

        public static Vector GetMinimum(Vector v1, Vector v2)
        {
            return new Vector(Math.Min(v1.x, v2.x), Math.Min(v1.y, v2.y), Math.Min(v1.z, v2.z));
        }

        public static Vector GetMaximum(Vector v1, Vector v2)
        {
            return new Vector(Math.Max(v1.x, v2.x), Math.Max(v1.y, v2.y), Math.Max(v1.z, v2.z));
        }

        public static Vector GetRandom()
        {
            return new Vector(random.NextDouble(), random.NextDouble(), random.NextDouble());
        }

        public static Vector Deserialize(Dictionary<string, object> args)
        {

            double x = 0;
            double y = 0;
            double z = 0;

            if (args.ContainsKey("x"))
            {
                x = Convert.ToDouble(args["x"]);
            }
            if (args.ContainsKey("y"))
            {
                y = Convert.ToDouble(args["y"]);
            }
            if (args.ContainsKey("z"))
            {
                z = Convert.ToDouble(args["z"]);
            }

            return new Vector(x, y, z);

        }

    }
}
