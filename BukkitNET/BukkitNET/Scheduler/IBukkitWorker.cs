using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using BukkitNET.Plugin;

namespace BukkitNET.Scheduler
{
    public interface IBukkitWorker
    {

        int GetTaskId();

        IPlugin GetOwner();

        Thread GetThread();

    }
}
