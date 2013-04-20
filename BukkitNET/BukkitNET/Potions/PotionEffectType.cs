using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace BukkitNET.Potions
{
    public abstract class PotionEffectType
    {

        public static readonly PotionEffectType SPEED = new PotionEffectTypeWrapper(1);

        public static readonly PotionEffectType SLOW = new PotionEffectTypeWrapper(2);

        public static readonly PotionEffectType FAST_DIGGING = new PotionEffectTypeWrapper(3);

        public static readonly PotionEffectType SLOW_DIGGING = new PotionEffectTypeWrapper(4);

        public static readonly PotionEffectType INCREASE_DAMAGE = new PotionEffectTypeWrapper(5);

        public static readonly PotionEffectType HEAL = new PotionEffectTypeWrapper(6);

        public static readonly PotionEffectType HARM = new PotionEffectTypeWrapper(7);

        public static readonly PotionEffectType JUMP = new PotionEffectTypeWrapper(8);

        public static readonly PotionEffectType CONFUSION = new PotionEffectTypeWrapper(9);

        public static readonly PotionEffectType REGENERATION = new PotionEffectTypeWrapper(10);

        public static readonly PotionEffectType DAMAGE_RESISTANCE = new PotionEffectTypeWrapper(11);

        public static readonly PotionEffectType FIRE_RESISTANCE = new PotionEffectTypeWrapper(12);

        public static readonly PotionEffectType WATER_BREATHING = new PotionEffectTypeWrapper(13);

        public static readonly PotionEffectType INVISIBILITY = new PotionEffectTypeWrapper(14);

        public static readonly PotionEffectType BLINDNESS = new PotionEffectTypeWrapper(15);

        public static readonly PotionEffectType NIGHT_VISION = new PotionEffectTypeWrapper(16);

        public static readonly PotionEffectType HUNGER = new PotionEffectTypeWrapper(17);

        public static readonly PotionEffectType WEAKNESS = new PotionEffectTypeWrapper(18);

        public static readonly PotionEffectType POISON = new PotionEffectTypeWrapper(19);

        public static readonly PotionEffectType WITHER = new PotionEffectTypeWrapper(20);

        private int id;

        public int Id
        {
            get
            {
                return id;
            }
        }

        protected PotionEffectType(int id)
        {
            this.id = id;
        }

        public PotionEffect CreateEffect(int duration, int amplifier)
        {
            return Potion.Brewer.CreateEffect(this, duration, amplifier);
        }

        public abstract double GetDurationModifier();

        public abstract string GetName();

        public abstract bool IsInstant();

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (!(obj is PotionEffectType))
            {
                return false;
            }
            PotionEffectType other = (PotionEffectType)obj;
            if (this.id != other.id)
            {
                return false;
            }
            return true;
        }

        public override int GetHashCode()
        {
            return id;
        }

        public override string ToString()
        {
            return "PotionEffectType[" + id + ", " + GetName() + "]";
        }

        private static PotionEffectType[] byId = new PotionEffectType[21];
        private static Dictionary<string, PotionEffectType> byName = new Dictionary<String, PotionEffectType>();

        private static bool acceptingNew = true;

        public static PotionEffectType GetById(int id)
        {
            if (id >= byId.Length || id < 0)
                return null;
            return byId[id];
        }

        public static PotionEffectType GetByName(string name)
        {
            Debug.Assert(name != null, "name cannot be null");
            return byName[name.ToLower()];
        }

        public static void RegisterPotionEffectType(PotionEffectType type)
        {
            if (byId[type.id] != null || byName.ContainsKey(type.GetName().ToLower()))
            {
                throw new ArgumentException("Cannot set already-set type");
            }
            else if (!acceptingNew)
            {
                throw new Exception(
                        "No longer accepting new potion effect types (can only be done by the server implementation)");
            }

            byId[type.id] = type;
            byName.Add(type.GetName().ToLower(), type);
        }

        public static void StopAcceptingRegistrations()
        {
            acceptingNew = false;
        }

        public static PotionEffectType[] Values()
        {
            return (PotionEffectType[])byId.Clone();
        }

    }
}
