using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BukkitNET.Inventory;

namespace BukkitNET.Entities
{
    public interface IItemFrame : IHanging
    {

        ItemStack GetItem();

        void SetItem(ItemStack item);

        Rotation GetRotation();

        void SetRotation(Rotation value);

    }
}
