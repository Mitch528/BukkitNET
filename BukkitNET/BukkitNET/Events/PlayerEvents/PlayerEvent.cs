using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BukkitNET.Entities;

namespace BukkitNET.Events.PlayerEvents
{
    public abstract class PlayerEvent : Event
    {

        protected IPlayer player;

        public IPlayer Player
        {
            get
            {
                return player;
            }
        }

        protected PlayerEvent(IPlayer who)
        {
            player = who;
        }

        protected PlayerEvent(IPlayer who, bool async) : base(async)
        {
            player = who;
        }
    }
}
