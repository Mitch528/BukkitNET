using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BukkitNET.Entities;

namespace BukkitNET.Inventory
{
    public interface IInventory : IList<ItemStack>
    {

        int GetSize();

        int GetMaxStackSize();

        void SetMaxStackSize(int size);

        string GetName();

        ItemStack GetItem(int index);

        void SetItem(int index, ItemStack item);

        Dictionary<int, ItemStack> AddItem(params ItemStack[] items);

        Dictionary<int, ItemStack> RemoveItem(params ItemStack[] items);

        ItemStack[] GetContents();

        void SetContents(ItemStack[] items);

        bool Contains(int materialId);

        bool Contains(Material material);

        bool Contains(ItemStack item, int amount);

        bool ContainsAtLeast(ItemStack item, int amount);

        Dictionary<int, T> All<T>(int materialId);

        Dictionary<int, T> All<T>(Material material);

        Dictionary<int, T> All<T>(ItemStack item);

        int First(int materialId);

        int First(Material material);

        int First(ItemStack item);

        int FirstEmpty();

        void Remove(int materialId);

        void Remove(Material material);

        void Clear(int index);

        List<IHumanEntity> GetViewers();

        string GetTitle();

        InventoryType GetInventoryType();

        InventoryHolder GetHolder();

        IEnumerable<ItemStack> Numerable();

        IEnumerable<ItemStack> Numerable(int index);

    }
}
