using System.Collections.Generic;
using System.Linq;

namespace ST10140587_PROG6221_POE
{
    public class Recipe
    {
        public string Name { get; set; }
        public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
        public List<string> Steps { get; set; } = new List<string>();
        public int TotalCalories
        {
            get { return Ingredients.Sum(i => i.Calories); }
        }

        // Add a method to reset the ingredient quantities to their original values
        public void ResetQuantities()
        {
            foreach (var ingredient in Ingredients)
            {
                ingredient.Quantity = ingredient.OriginalQuantity;
            }
        }

        // Add a method to scale the ingredient quantities
        public void ScaleQuantities(double scale)
        {
            foreach (var ingredient in Ingredients)
            {
                ingredient.Quantity = ingredient.OriginalQuantity * scale;
            }
        }
    }

    public class Ingredient
    {
        public string Name { get; set; }
        public double Quantity { get; set; }
        public string Unit { get; set; }
        public int Calories { get; set; }
        public string FoodGroup { get; set; }

        // Store the original quantity
        public double OriginalQuantity { get; set; }

        public Ingredient()
        {
            OriginalQuantity = Quantity;
        }
    }
}
