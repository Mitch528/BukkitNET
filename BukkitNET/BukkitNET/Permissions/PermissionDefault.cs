using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BukkitNET.Attributes;
using BukkitNET.Extensions;

namespace BukkitNET.Permissions
{

    public enum PermissionDefault
    {

        [PermissionDefaultInfo("true")]
        True,

        [PermissionDefaultInfo("false")]
        False,

        [PermissionDefaultInfo("op", "isop", "operator", "isoperator", "admin", "isadmin")]
        OP,

        [PermissionDefaultInfo("!op", "notop", "!operator", "notoperator", "!admin", "notadmin")]
        NotOP

    }

    public static class PermissionDefaultHelper
    {

        public static PermissionDefault GetByName(string name)
        {

            var values = Enum.GetValues(typeof(PermissionDefault));

            foreach (var val in values)
            {

                var value = (PermissionDefault)val;

                var attrib = value.GetAttribute<PermissionDefaultInfoAttribute>();

                var n = Enum.GetName(typeof(PermissionDefault), value);

                if (n.Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    return value;
                }

            }

            return default(PermissionDefault);

        }

    }

    public static class PermissionDefaultExtensions
    {

        public static bool GetValue(this PermissionDefault def, bool op)
        {

            switch (def)
            {
                case PermissionDefault.True:
                    return true;
                case PermissionDefault.False:
                    return false;
                case PermissionDefault.OP:
                    return op;
                case PermissionDefault.NotOP:
                    return !op;
                default:
                    return false;
            }

        }

    }

}
