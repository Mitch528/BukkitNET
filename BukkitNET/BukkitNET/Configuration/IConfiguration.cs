using System.Collections.Generic;

namespace BukkitNET.Configuration
{
    public interface IConfiguration : IConfigurationSection
    {

        void AddDefault(string path, object value);

        void AddDefaults(Dictionary<string, object> defaults);

        void AddDefaults(IConfiguration defaults);

        void SetDefaults(IConfiguration defaults);

        IConfiguration GetDefaults();

        ConfigurationOptions Options();

    }
}
