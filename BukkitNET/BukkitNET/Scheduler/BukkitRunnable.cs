using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BukkitNET.Plugin;

namespace BukkitNET.Scheduler
{
    public abstract class BukkitRunnable
    {

        private int taskId = -1;

        private readonly object syncLock = new object();

        public void Cancel()
        {
            lock (syncLock)
            {
                Bukkit.getScheduler().cancelTask(GetTaskId());
            }
        }

        public BukkitTask RunTask(IPlugin plugin)
        {
            lock (syncLock)
            {
                CheckState();
                return setupId(Bukkit.getScheduler().runTask(plugin, this));
            }
        }

        public BukkitTask RunTaskAsynchronously(IPlugin plugin)
        {
            lock (syncLock)
            {
                CheckState();
                return SetupId(Bukkit.getScheduler().RunTaskAsynchronously(plugin, this));
            }
        }

        public BukkitTask RunTaskLater(IPlugin plugin, long delay)
        {
            lock (syncLock)
            {
                CheckState();
                return SetupId(Bukkit.getScheduler().RunTaskLater(plugin, this, delay));
            }
        }

        public BukkitTask RunTaskLaterAsynchronously(IPlugin plugin, long delay)
        {
            lock (syncLock)
            {
                CheckState();
                return SetupId(Bukkit.getScheduler().RunTaskLaterAsynchronously(plugin, this, delay));
            }
        }

        public BukkitTask RunTaskTimer(IPlugin plugin, long delay, long period)
        {
            lock (syncLock)
            {
                CheckState();
                return SetupId(Bukkit.getScheduler().RunTaskTimer(plugin, this, delay, period));
            }
        }

        public BukkitTask RunTaskTimerAsynchronously(IPlugin plugin, long delay, long period)
        {
            lock (syncLock)
            {
                CheckState();
                return SetupId(Bukkit.getScheduler().RunTaskTimerAsynchronously(plugin, this, delay, period));
            }
        }

        public int GetTaskId()
        {
            lock (syncLock)
            {
                int id = taskId;
                if (id == -1)
                {
                    throw new Exception("Not scheduled yet");
                }
                return id;
            }
        }

        private void CheckState()
        {
            if (taskId != -1)
            {
                throw new Exception("Already scheduled as " + taskId);
            }
        }

        private BukkitTask SetupId(BukkitTask task)
        {
            this.taskId = task.TaskId;
            return task;
        }

    }
}
