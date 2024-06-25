using System.Windows;
using System.Windows.Controls;

namespace ST10140587_PROG6221_POE
{
    public partial class AddIngredientPage : Page
    {
        private Recipe currentRecipe;
        private Ingredient currentIngredient;

        public AddIngredientPage(Recipe recipe)
        {
            InitializeComponent();
            currentRecipe = recipe;
        }

        public AddIngredientPage(Recipe recipe, Ingredient ingredient) : this(recipe)
        {
            currentIngredient = ingredient;
            IngredientNameTextBox.Text = ingredient.Name;
            IngredientQuantityTextBox.Text = ingredient.Quantity.ToString();
            IngredientUnitTextBox.Text = ingredient.Unit;
            IngredientCaloriesTextBox.Text = ingredient.Calories.ToString();
            IngredientFoodGroupTextBox.Text = ingredient.FoodGroup;
        }

        private void SaveIngredientButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentIngredient == null)
            {
                currentIngredient = new Ingredient();
                currentRecipe.Ingredients.Add(currentIngredient);
            }
            currentIngredient.Name = IngredientNameTextBox.Text;
            currentIngredient.Quantity = double.Parse(IngredientQuantityTextBox.Text);
            currentIngredient.Unit = IngredientUnitTextBox.Text;
            currentIngredient.Calories = int.Parse(IngredientCaloriesTextBox.Text);
            currentIngredient.FoodGroup = IngredientFoodGroupTextBox.Text;

            NavigationService.GoBack();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
