using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BukkitNET
{
    public interface IBlockChangeDelegate
    {

        bool SetRawTypeId(int x, int y, int z, int typeId);

        bool SetRawTypeIdAndData(int x, int y, int z, int typeId, int data);

        bool SetTypeId(int x, int y, int z, int typeId);

        bool SetTypeIdAndData(int x, int y, int z, int typeId, int data);

        int GetTypeId(int x, int y, int z);

        int GetHeight();

        bool IsEmpty(int x, int y, int z);

    }
}
