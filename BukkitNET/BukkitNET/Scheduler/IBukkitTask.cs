using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BukkitNET.Plugin;

namespace BukkitNET.Scheduler
{
    public interface IBukkitTask
    {

        int GetTaskId();

        IPlugin GetOwner();

        bool IsSync();

        void Cancel();

    }
}
