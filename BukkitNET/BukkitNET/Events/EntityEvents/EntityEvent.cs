using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BukkitNET.Entities;

namespace BukkitNET.Events.EntityEvents
{
    public abstract class EntityEvent : Event
    {

        protected IEntity entity;

        public IEntity Entity
        {
            get
            {
                return entity;
            }
        }

        public EntityType EntityType
        {
            get
            {
                return entity.GetEntityType();
            }
        }

        protected EntityEvent(IEntity what)
        {
            entity = what;
        }

    }
}
