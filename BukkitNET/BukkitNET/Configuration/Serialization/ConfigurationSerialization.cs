using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using BukkitNET.Inventory;
using BukkitNET.Potions;
using BukkitNET.Util;

namespace BukkitNET.Configuration.Serialization
{
    public class ConfigurationSerialization
    {

        public static String SERIALIZED_TYPE_KEY = "==";
        private Type type;
        private static Dictionary<string, Type> aliases = new Dictionary<string, Type>();

        static ConfigurationSerialization()
        {
            RegisterClass(typeof(Vector));
            RegisterClass(typeof(BlockVector));
            RegisterClass(typeof(ItemStack));
            RegisterClass(typeof(Color));
            RegisterClass(typeof(PotionEffect));
            RegisterClass(typeof(FireworkEffect));
        }

        protected ConfigurationSerialization(Type type)
        {

            if (!(typeof(ConfigurationSerialization).IsAssignableFrom(type)))
                throw new Exception();

            this.type = type;

        }

        protected MethodInfo GetMethod(string name, bool isStatic)
        {

            try
            {
                MethodInfo method = type.GetMethod(name, new[] { typeof(Dictionary<,>).MakeGenericType() });

                if (!typeof(IConfigurationSerializable).IsAssignableFrom(method.GetType()))
                {
                    return null;
                }
                if (method.IsStatic != isStatic)
                {
                    return null;
                }

                return method;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        protected ConstructorInfo GetConstructor<T>()
        {
            return typeof(T).GetConstructor(new[] { typeof(Dictionary<,>).MakeGenericType() });
        }

        protected IConfigurationSerializable DeserializeViaMethod(MethodInfo method, Dictionary<string, object> args)
        {
            try
            {
                IConfigurationSerializable result = (IConfigurationSerializable)method.Invoke(null, args);

                if (result == null)
                {
                    Logger.getLogger(typeof(ConfigurationSerialization).Name).log(Level.SEVERE, "Could not call method '" + method.toString() + "' of " + clazz + " for deserialization: method returned null");
                }
                else
                {
                    return result;
                }
            }
            catch (Exception ex)
            {
                Logger.getLogger(typeof(ConfigurationSerialization).Name).log(
                        Level.SEVERE,
                        "Could not call method '" + method.toString() + "' of " + clazz + " for deserialization", ex);
            }

            return null;
        }

        protected IConfigurationSerializable DeserializeViaCtor(ConstructorInfo ctor, Dictionary<string, object> args)
        {

            try
            {
                return (IConfigurationSerializable)Activator.CreateInstance(ctor.GetType());
            }
            catch (Exception ex)
            {
                Logger.getLogger(typeof(ConfigurationSerialization).Name).Log(
                        Level.SEVERE,
                        "Could not call constructor '" + ctor.toString() + "' of " + clazz + " for deserialization", ex);
            }

            return null;

        }

        public IConfigurationSerializable Deserialize<T>(Dictionary<string, object> args)
        {
            Debug.Assert(args != null, "Args must not be null");

            IConfigurationSerializable result = null;
            MethodInfo method = null;

            method = GetMethod("Deserialize", true);

            if (method != null)
            {
                result = DeserializeViaMethod(method, args);
            }

            if (result == null)
            {
                ConstructorInfo constructor = GetConstructor<T>();

                if (constructor != null)
                {
                    result = DeserializeViaCtor(constructor, args);
                }
            }

            return result;
        }

        public static IConfigurationSerializable DeserializeObject<T>(Dictionary<string, object> args, Type type)
        {
            return new ConfigurationSerialization(type).Deserialize<T>(args);
        }

        public static IConfigurationSerializable DeserializeObject<T>(Dictionary<string, object> args)
        {
            Type type = null;

            if (args.ContainsKey(SERIALIZED_TYPE_KEY))
            {
                try
                {
                    String alias = (String)args[SERIALIZED_TYPE_KEY];

                    if (alias == null)
                    {
                        throw new ArgumentException("Cannot have null alias");
                    }
                    type = GetClassByAlias(alias);
                    if (type == null)
                    {
                        throw new ArgumentException("Specified class does not exist ('" + alias + "')");
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                throw new ArgumentException("Args doesn't contain type key ('" + SERIALIZED_TYPE_KEY + "')");
            }

            return new ConfigurationSerialization(type).Deserialize<T>(args);
        }

        public static void RegisterClass(Type type)
        {

            var attribs = type.GetCustomAttributes(true);

            if (!attribs.Any())
            {
                RegisterClass(type, GetAlias(type));
                RegisterClass(type, type.Name);
            }
        }

        public static void RegisterClass(Type type, string alias)
        {
            if (!aliases.ContainsKey(alias))
                aliases.Add(alias, type);
        }

        public static void UnregisterClass(string alias)
        {
            aliases.Remove(alias);
        }

        public static void UnregisterClass(Type type)
        {

            var types = aliases.ToList();

            for (int i = 0; i < types.Count; i++)
            {
                if (types[i].Value == type)
                {
                    aliases.Remove(types[i].Key);
                }
            }

        }

        public static Type GetClassByAlias(string alias)
        {
            return aliases[alias];
        }



        public static string GetAlias(Type type)
        {
            foreach (var al in aliases.Where(al => al.Value == type))
            {
                return al.Key;
            }
        }
    }
}
