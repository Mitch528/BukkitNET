using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BukkitNET.Entities;

namespace BukkitNET.Events.PlayerEvents
{
    public class PlayerMoveEvent : PlayerEvent, ICancellable
    {

        private static HandlerList handlers = new HandlerList();
        private bool cancel = false;
        private Location from;
        private Location to;

        public PlayerMoveEvent(IPlayer who)
            : base(who)
        {
        }

        public PlayerMoveEvent(IPlayer who, bool async)
            : base(who, async)
        {
        }

        public PlayerMoveEvent(IPlayer player, Location from, Location to) : this(player)
        {
            this.from = from;
            this.to = to;
        }

        public Location From
        {
            get
            {
                return from;
            }
            set
            {
                from = value;
            }
        }

        public Location To
        {
            get
            {
                return to;
            }
            set
            {
                to = value;
            }
        }

        public HandlerList HandlerList
        {
            get
            {
                return handlers;
            }
        }

        public override HandlerList GetHandlers()
        {
            return handlers;
        }

        bool ICancellable.IsCancelled()
        {
            return cancel;
        }

        public void SetCancelled(bool cancel)
        {
            this.cancel = cancel;
        }
    }
}
