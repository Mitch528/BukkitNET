using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BukkitNET.Attributes;

namespace BukkitNET.Events.InventoryEvents
{
    public enum InventoryType
    {

        [InventoryTypeInfo(27, "Chest")]
        Chest,

        [InventoryTypeInfo(9, "Dispenser")]
        Dispenser,

        [InventoryTypeInfo(9, "Dropper")]
        Dropper,

        [InventoryTypeInfo(3, "Furnace")]
        Furnace,

        [InventoryTypeInfo(10, "Crafting")]
        Workbench,

        [InventoryTypeInfo(5, "Crafting")]
        Crafting,

        [InventoryTypeInfo(1, "Enchanting")]
        Enchanting,

        [InventoryTypeInfo(4, "Brewing")]
        Brewing,

        [InventoryTypeInfo(36, "Player")]
        Player,

        [InventoryTypeInfo(9, "Creative")]
        Creative,

        [InventoryTypeInfo(3, "Villager")]
        Merchant,

        [InventoryTypeInfo(27, "Ender Chest")]
        EnderChest,

        [InventoryTypeInfo(3, "Reparing")]
        Anvil,

        [InventoryTypeInfo(1, "container.beacon")]
        Beacon,

        [InventoryTypeInfo(5, "Item Hopper")]
        Hopper

    }

    public enum SlotType
    {
        Result,
        Crafting,
        Armor,
        Container,
        Quickbar,
        Outside,
        Fuel
    }

}
