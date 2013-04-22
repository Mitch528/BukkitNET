using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BukkitNET.Block
{
    public interface IJukebox : IBlockState
    {

        Material GetPlaying();

        void SetPlaying(Material record);

        bool IsPlaying();

        bool Eject();

    }
}
