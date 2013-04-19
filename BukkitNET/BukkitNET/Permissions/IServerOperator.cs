using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BukkitNET.Permissions
{
    public interface IServerOperator
    {

        bool IsOp();

        void SetOp(bool value);

    }
}
