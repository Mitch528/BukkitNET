using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BukkitNET.Events
{
    public interface ICancellable
    {

        bool IsCancelled();

        void SetCancelled(bool cancel);

    }
}
