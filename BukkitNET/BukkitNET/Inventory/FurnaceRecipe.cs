using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BukkitNET.Materials;

namespace BukkitNET.Inventory
{
    public class FurnaceRecipe : IRecipe
    {

        private ItemStack output;
        private ItemStack ingredient;

        public FurnaceRecipe(ItemStack result, Material source) : this(result, source, 0)
        {
        }

        public FurnaceRecipe(ItemStack result, MaterialData source) : this(result, source.ItemType, source.Data)
        {
        }

        public FurnaceRecipe(ItemStack result, Material source, int data)
        {
            this.output = new ItemStack(result);
            this.ingredient = new ItemStack(source, 1, (short)data);
        }

        public FurnaceRecipe SetInput(MaterialData input)
        {
            return SetInput(input.ItemType, input.Data);
        }

        public FurnaceRecipe SetInput(Material input, int data)
        {
            this.ingredient = new ItemStack(input, 1, (short)data);
            return this;
        }

        public ItemStack GetInput()
        {
            return this.ingredient.Clone();
        }

        public ItemStack GetResult()
        {
            return output.Clone();
        }

    }
}
