using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace BukkitNET.Plugin
{
    public class PluginProxy : MarshalByRefObject
    {

        public Assembly LoadPlugin(string filename)
        {
            try
            {
                return Assembly.LoadFile(filename);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
