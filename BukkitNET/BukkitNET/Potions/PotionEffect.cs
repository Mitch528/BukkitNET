using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using BukkitNET.Configuration.Serialization;
using BukkitNET.Entities;

namespace BukkitNET.Potions
{
    public class PotionEffect : ConfigurationSerializable
    {

        private static string AMPLIFIER = "amplifier";
        private static string DURATION = "duration";
        private static string TYPE = "effect";
        private static string AMBIENT = "ambient";
        private int amplifier;
        private int duration;
        private PotionEffectType type;
        private bool ambient;

        public int Amplifier
        {
            get
            {
                return amplifier;
            }
        }

        public int Duration
        {
            get
            {
                return duration;
            }
        }

        public PotionEffectType Type
        {
            get
            {
                return type;
            }
        }

        public bool IsAmbient
        {
            get
            {
                return ambient;
            }
        }

        public PotionEffect(PotionEffectType type, int duration, int amplifier, bool ambient)
        {
            Debug.Assert(type != null, "effect type cannot be null");
            this.type = type;
            this.duration = duration;
            this.amplifier = amplifier;
            this.ambient = ambient;
        }

        public PotionEffect(PotionEffectType type, int duration, int amplifier)
            : this(type, duration, amplifier, true)
        {
        }

        public PotionEffect(Dictionary<string, object> map)
            : this(GetEffectType(map), GetInt(map, DURATION), GetInt(map, AMPLIFIER), GetBool(map, AMBIENT))
        {
        }

        public Dictionary<string, object> Serialize()
        {

            var dict = new Dictionary<string, object>
                           {
                               {TYPE, type.Id},
                               {DURATION, duration},
                               {AMPLIFIER, amplifier},
                               {AMBIENT, ambient}
                           };

            return dict;

        }

        private static PotionEffectType GetEffectType<TKey, TValue>(Dictionary<TKey, TValue> map)
        {
            int type = GetInt(map, TYPE);
            PotionEffectType effect = PotionEffectType.GetById(type);
            if (effect != null)
            {
                return effect;
            }
            throw new Exception(map + " does not contain " + TYPE);
        }

        private static int GetInt<TKey, TValue>(Dictionary<TKey, TValue> map, object key)
        {
            object num = map[(TKey)key];
            if (num is int)
            {
                return (int)num;
            }
            throw new Exception(map + " does not contain " + key);
        }

        private static bool GetBool<TKey, TValue>(Dictionary<TKey, TValue> map, object key)
        {
            Object bl = map[(TKey)key];
            if (bl is bool)
            {
                return (Boolean)bl;
            }
            throw new Exception(map + " does not contain " + key);
        }

        public bool Apply(ILivingEntity entity)
        {
            return entity.AddPotionEffect(this);
        }

        public override bool Equals(object obj)
        {
            if (this == obj)
            {
                return true;
            }
            if (!(obj is PotionEffect))
            {
                return false;
            }
            PotionEffect that = (PotionEffect)obj;
            return this.type.Equals(that.type) && this.ambient == that.ambient && this.amplifier == that.amplifier && this.duration == that.duration;
        }

        public override int GetHashCode()
        {
            int hash = 1;
            hash = hash * 31 + type.GetHashCode();
            hash = hash * 31 + amplifier;
            hash = hash * 31 + duration;
            hash ^= 0x22222222 >> (ambient ? 1 : -1);
            return hash;
        }

        public override string ToString()
        {
            return type.GetName() + (ambient ? ":(" : ":") + duration + "t-x" + amplifier + (ambient ? ")" : "");
        }

    }
}
