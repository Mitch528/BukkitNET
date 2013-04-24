using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BukkitNET.Materials
{
    public interface IColorable
    {

        DyeColor GetColor();

        void SetColor(DyeColor color);

    }
}
