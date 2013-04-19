using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BukkitNET.Plugin;

namespace BukkitNET.Scheduler
{
    public interface BukkitScheduler
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

        List<BukkitWorker> GetActiveWorkers();

        List<BukkitTask> GetPendingTasks();

        BukkitTask RunTask(IPlugin plugin, Action task);

        BukkitTask RunTaskAsynchronously(IPlugin plugin, Action task);

        BukkitTask RunTaskLater(IPlugin plugin, Action task, long delay);

        BukkitTask RunTaskLaterAsynchronously(IPlugin plugin, Action task, long delay);

        BukkitTask RunTaskTimer(IPlugin plugin, Action task, long delay, long period);

        BukkitTask RunTaskTimerAsynchronously(IPlugin plugin, Action task, long delay, long period);

    }
}
