using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using BukkitNET.Materials;

namespace BukkitNET.Inventory
{
    public class ShapelessRecipe : IRecipe
    {

        private ItemStack output;
        private List<ItemStack> ingredients = new List<ItemStack>();

        public ShapelessRecipe(ItemStack result)
        {
            this.output = new ItemStack(result);
        }

        public ShapelessRecipe AddIngredient(MaterialData ingredient)
        {
            return AddIngredient(1, ingredient);
        }

        public ShapelessRecipe AddIngredient(Material ingredient)
        {
            return AddIngredient(1, ingredient, 0);
        }

        public ShapelessRecipe AddIngredient(Material ingredient, int rawdata)
        {
            return AddIngredient(1, ingredient, rawdata);
        }

        public ShapelessRecipe AddIngredient(int count, MaterialData ingredient)
        {
            return AddIngredient(count, ingredient.ItemType, ingredient.Data);
        }

        public ShapelessRecipe AddIngredient(int count, Material ingredient)
        {
            return AddIngredient(count, ingredient, 0);
        }

        public ShapelessRecipe AddIngredient(int count, Material ingredient, int rawdata)
        {
            Debug.Assert(ingredients.Count + count <= 9, "Shapeless recipes cannot have more than 9 ingredients");

            if (rawdata == -1)
            {
                rawdata = short.MaxValue;
            }

            while (count-- > 0)
            {
                ingredients.Add(new ItemStack(ingredient, 1, (short)rawdata));
            }
            return this;
        }

        public ShapelessRecipe RemoveIngredient(Material ingredient)
        {
            return RemoveIngredient(ingredient, 0);
        }

        public ShapelessRecipe RemoveIngredient(MaterialData ingredient)
        {
            return RemoveIngredient(ingredient.ItemType, ingredient.Data);
        }

        public ShapelessRecipe RemoveIngredient(int count, Material ingredient)
        {
            return RemoveIngredient(count, ingredient, 0);
        }

        public ShapelessRecipe RemoveIngredient(int count, MaterialData ingredient)
        {
            return RemoveIngredient(count, ingredient.ItemType, ingredient.Data);
        }

        public ShapelessRecipe RemoveIngredient(Material ingredient, int rawdata)
        {
            return RemoveIngredient(1, ingredient, rawdata);
        }

        public ShapelessRecipe RemoveIngredient(int count, Material ingredient, int rawdata)
        {

            var enumerator = ingredients.GetEnumerator();
            while (count > 0 && enumerator.MoveNext())
            {

                ItemStack stack = enumerator.Current;

                if (stack == null)
                    continue;

                if (stack.GetMaterialType() == ingredient && stack.Durability == rawdata)
                {
                    ingredients.Remove(stack);
                    count--;
                }
            }

            return this;
        }

        public ItemStack GetResult()
        {
            return output.Clone();
        }

        public List<ItemStack> GetIngredientList()
        {
            List<ItemStack> result = new List<ItemStack>(ingredients.Count);
            foreach (ItemStack ingredient in ingredients)
            {
                result.Add(ingredient.Clone());
            }
            return result;
        }

    }
}
