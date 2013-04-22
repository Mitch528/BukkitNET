using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using BukkitNET.Materials;

namespace BukkitNET.Inventory
{
    public class ShapedRecipe : IRecipe
    {

        private ItemStack output;
        private string[] rows;
        private Dictionary<char, ItemStack> ingredients = new Dictionary<char, ItemStack>();

        public ShapedRecipe(ItemStack result)
        {
            this.output = new ItemStack(result);
        }

        public ShapedRecipe Shape(params string[] shape)
        {
            Debug.Assert(shape != null, "Must provide a shape");
            Debug.Assert((shape.Length > 0 && shape.Length < 4), "Crafting recipes should be 1, 2, 3 rows, not " + shape.Length);

            foreach (string row in shape)
            {
                Debug.Assert(row != null, "Shape cannot have null rows");
                Debug.Assert(row.Length > 0 && row.Length < 4, "Crafting rows should be 1, 2, or 3 characters, not " + row.Length);
            }
            this.rows = new string[shape.Length];
            for (int i = 0; i < shape.Length; i++)
            {
                this.rows[i] = shape[i];
            }

            Dictionary<char, ItemStack> newIngredients = new Dictionary<char, ItemStack>();
            foreach (string row in shape)
            {
                foreach (char c in row)
                {
                    newIngredients.Add(c, ingredients[c]);
                }
            }
            this.ingredients = newIngredients;

            return this;
        }

        public ShapedRecipe SetIngredient(char key, MaterialData ingredient)
        {
            return SetIngredient(key, ingredient.ItemType, ingredient.Data);
        }

        public ShapedRecipe SetIngredient(char key, Material ingredient)
        {
            return SetIngredient(key, ingredient, 0);
        }

        public ShapedRecipe SetIngredient(char key, Material ingredient, int raw)
        {
            Debug.Assert(ingredients.ContainsKey(key), "Symbol does not appear in the shape:" + key);

            if (raw == -1)
            {
                raw = short.MaxValue;
            }

            ingredients.Add(key, new ItemStack(ingredient, 1, (short)raw));
            return this;
        }

        public Dictionary<char, ItemStack> GetIngredientMap()
        {
            Dictionary<char, ItemStack> result = new Dictionary<char, ItemStack>();
            foreach (var ingredient in ingredients)
            {
                if (ingredient.Value == null)
                {
                    result.Add(ingredient.Key, null);
                }
                else
                {
                    result.Add(ingredient.Key, ingredient.Value.Clone());
                }
            }
            return result;
        }

        public string[] GetShape()
        {
            return (string[])rows.Clone();
        }

        public ItemStack GetResult()
        {
            return output.Clone();
        }

    }
}
