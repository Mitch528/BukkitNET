using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BukkitNET.Entities;

namespace BukkitNET.Maps
{
    public abstract class MapRenderer
    {

        private bool contextual;

        public bool IsContextual
        {
            get
            {
                return contextual;
            }
        }

        public MapRenderer() : this(false)
        {
        }

        public MapRenderer(bool contextual)
        {
            this.contextual = contextual;
        }

        public void Initialize(IMapView map)
        {
        }

        abstract public void Render(IMapView map, MapCanvas canvas, IPlayer player);

    }
}
