using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BukkitNET.Materials
{
    public interface IOpenable
    {

        bool IsOpen();

        void SetOpen(bool isOpen);

    }
}
