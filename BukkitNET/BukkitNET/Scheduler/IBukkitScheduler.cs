using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BukkitNET.Plugin;

namespace BukkitNET.Scheduler
{
    public interface IBukkitScheduler
    {

        int ScheduleSyncDelayedTask(IPlugin plugin, Action task, long delay);

        int SycheduleSyncDelayedTask(IPlugin plugin, Action task);

        int ScheduleSyncRepeatingTask(IPlugin plugin, Action task, long delay, long period);

        Func<T> CallSyncMethod<T>(IPlugin plugin, Action task);

        void CancelTask(int taskId);

        void CancelTasks(IPlugin plugin);

        void CancelAllTasks();

        bool IsCurrentlyRunning(int taskId);

        bool IsQueued(int taskId);

        List<IBukkitWorker> GetActiveWorkers();

        List<IBukkitTask> GetPendingTasks();

        IBukkitTask RunTask(IPlugin plugin, Action task);

        IBukkitTask RunTaskAsynchronously(IPlugin plugin, Action task);

        IBukkitTask RunTaskLater(IPlugin plugin, Action task, long delay);

        IBukkitTask RunTaskLaterAsynchronously(IPlugin plugin, Action task, long delay);

        IBukkitTask RunTaskTimer(IPlugin plugin, Action task, long delay, long period);

        IBukkitTask RunTaskTimerAsynchronously(IPlugin plugin, Action task, long delay, long period);

    }
}
