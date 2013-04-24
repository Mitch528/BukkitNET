using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BukkitNET.Entities
{
    public interface IPainting : IHanging
    {

        Art GetArt();

        bool SetArt(Art art);

        bool SetArt(Art art, bool force);

    }
}
