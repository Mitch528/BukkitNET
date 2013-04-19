using System;
using System.Collections.Generic;
using BukkitNET.Inventory;
using BukkitNET.Util;

namespace BukkitNET.Configuration
{
    public interface IConfigurationSection
    {

        HashSet<String> GetKeys(bool deep);

        Dictionary<string, object> GetValues(bool deep);

        bool Contains(string path);

        bool IsSet(string path);

        string GetCurrentPath();

        string GetName();

        IConfiguration GetRoot();

        IConfigurationSection GetParent();

        object Get(string path);

        object Get(string path, object def);

        void Set(string path, object value);

        IConfigurationSection CreateSection(String path);

        IConfigurationSection CreateSection<TKey, TValue>(String path, Dictionary<TKey, TValue> map);

        string GetString(string path);

        string GetString(string path, string def);

        bool IsString(string path);

        int GetInt(string path);

        int GetInt(string path, int def);

        bool IsInt(string path);

        bool GetBoolean(string path);

        bool GetBoolean(string path, bool def);

        double GetDouble(string path);

        double GetDouble(string path, double def);

        bool IsDouble(string path);

        long GetLong(string path);

        long GetLong(string path, long def);

        bool IsLong(string path);

        List<T> GetList<T>(string path);

        List<T> GetList<T>(string path, List<T> def);

        bool IsList<T>(string path);

        List<string> GetStringList(string path);

        List<int> GetIntegerList(string path);

        List<bool> GetBooleanList(string path);

        List<double> GetDoubleList(string path);

        List<float> GetFloatList(string path);

        List<byte> GetByteList(string path);

        List<char> GetCharacterList(string path);

        List<short> GetShortList(string path);

        List<Dictionary<TKey, TValue>> GetMapList<TKey, TValue>(string path);

        Vector GetVector(string path);

        Vector GetVector(string path, Vector def);

        bool IsVector(string path);

        OfflinePlayer GetOfflinePlayer(string path);

        OfflinePlayer GetOfflinePlayer(string path, OfflinePlayer def);

        bool IsOfflinePlayer(string path);

        ItemStack GetItemStack(string path);

        ItemStack GetItemStack(string path, ItemStack def);

        bool IsItemStack(string path);

        Color GetColor(string path);

        Color GetColor(string path, Color def);

        bool IsColor(string path);

        IConfigurationSection GetConfigurationSection(string path);

        bool IsConfigurationSection(string path);

        IConfigurationSection GetDefaultSection();

        void AddDefault(string path, object value);

    }
}
