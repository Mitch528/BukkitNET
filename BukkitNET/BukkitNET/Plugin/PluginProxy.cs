using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace BukkitNET.Plugin
{
    internal class PluginProxy : MarshalByRefObject
    {

        public Assembly LoadAssemblyReflection(string assemblyPath)
        {
            try
            {
                return Assembly.ReflectionOnlyLoadFrom(assemblyPath);
            }
            catch (FileNotFoundException)
            {
                return null;
            }
        }

        public Assembly LoadAssembly(string assemblyPath)
        {
            try
            {
                return Assembly.LoadFrom(assemblyPath);
            }
            catch (FileNotFoundException)
            {
                return null;
            }
        }

    }
}
