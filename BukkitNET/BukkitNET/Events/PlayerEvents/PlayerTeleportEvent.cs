using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BukkitNET.Entities;

namespace BukkitNET.Events.PlayerEvents
{
    public class PlayerTeleportEvent : PlayerMoveEvent
    {

        private static HandlerList handlers = new HandlerList();
        private TeleportCause cause = TeleportCause.UNKNOWN;

        public TeleportCause Cause
        {
            get
            {
                return cause;
            }
        }

        public PlayerTeleportEvent(IPlayer player, Location from, Location to)
            : base(player, from, to)
        {
        }

        public PlayerTeleportEvent(IPlayer player, Location from, Location to, TeleportCause cause)
            : this(player, from, to)
        {
            this.cause = cause;
        }

        public enum TeleportCause
        {
            ENDER_PEARL,
            COMMAND,
            PLUGIN,
            NETHER_PORTAL,
            END_PORTAL,
            UNKNOWN
        }

    }
}
