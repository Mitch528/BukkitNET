using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BukkitNET.Configuration
{
    public interface ConfigurationSection
    {

        HashSet<String> getKeys(bool deep);

        Dictionary<string, object> getValues(bool deep);

        bool contains(string path);

        bool isSet(string path);

        string getCurrentPath();

        Config getRoot();

    }
}
