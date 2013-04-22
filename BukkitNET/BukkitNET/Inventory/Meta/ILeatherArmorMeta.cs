using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BukkitNET.Inventory.Meta
{
    public interface ILeatherArmorMeta : IItemMeta
    {

        Color GetColor();

        void SetColor(Color color);

        new ILeatherArmorMeta Clone();

    }
}
