using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ST10140587_PROG6221_POE
{
    public class Recipe
    {
        public string Name { get; set; }
        public ObservableCollection<Ingredient> Ingredients { get; set; } = new ObservableCollection<Ingredient>();
        public ObservableCollection<string> Steps { get; set; } = new ObservableCollection<string>();

        public Recipe Clone()
        {
            return new Recipe
            {
                Name = this.Name,
                Ingredients = new ObservableCollection<Ingredient>(this.Ingredients),
                Steps = new ObservableCollection<string>(this.Steps)
            };
        }

        public void ScaleRecipe(double factor)
        {
            foreach (var ingredient in Ingredients)
            {
                ingredient.Quantity *= factor;
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
    }
}
