using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BukkitNET.Entities;

namespace BukkitNET.Events.EntityEvents
{
    public class EntityDamageEvent : EntityEvent, ICancellable
    {

        private static HandlerList handlers = new HandlerList();
        private int damage;
        private bool cancelled;
        private DamageCause cause;

        public int Damage
        {
            get
            {
                return damage;
            }
            set
            {
                damage = value;
            }
        }

        public DamageCause Cause
        {
            get
            {
                return cause;
            }
        }


        public EntityDamageEvent(IEntity damagee, DamageCause cause, int damage)
            : base(damagee)
        {
            this.cause = cause;
            this.damage = damage;
        }

        public EntityDamageEvent(IEntity what)
            : base(what)
        {
        }

        public override HandlerList GetHandlers()
        {
            return handlers;
        }

        public bool IsCancelled()
        {
            return cancelled;
        }

        public void SetCancelled(bool cancel)
        {
            cancelled = cancel;
        }

        public static HandlerList GetHandlerList()
        {
            return handlers;
        }

        public enum DamageCause
        {
            CONTACT,
            ENTITY_ATTACK,
            PROJECTILE,
            SUFFOCATION,
            FALL,
            FIRE,
            FIRE_TICK,
            MELTING,
            LAVA,
            DROWNING,
            BLOCK_EXPLOSION,
            ENTITY_EXPLOSION,
            VOID,
            LIGHTNING,
            SUICIDE,
            STARVATION,
            POISON,
            MAGIC,
            WITHER,
            FALLING_BLOCK,
            THORNS,
            CUSTOM
        }

    }
}
