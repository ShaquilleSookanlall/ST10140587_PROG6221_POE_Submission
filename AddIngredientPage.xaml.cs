using System.Windows;
using System.Windows.Controls;

namespace ST10140587_PROG6221_POE
{
    public partial class AddIngredientPage : Page
    {
        private Recipe currentRecipe;
        private Ingredient currentIngredient;

        public AddIngredientPage(Recipe recipe, Ingredient ingredient = null)
        {
            InitializeComponent();
            currentRecipe = recipe;
            currentIngredient = ingredient;

            if (currentIngredient != null)
            {
                IngredientNameTextBox.Text = currentIngredient.Name;
                IngredientQuantityTextBox.Text = currentIngredient.Quantity.ToString();
                IngredientUnitTextBox.Text = currentIngredient.Unit;
                IngredientCaloriesTextBox.Text = currentIngredient.Calories.ToString();
                IngredientFoodGroupTextBox.Text = currentIngredient.FoodGroup;
            }
        }

        private void SaveIngredientButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(IngredientNameTextBox.Text) ||
                !double.TryParse(IngredientQuantityTextBox.Text, out double quantity) ||
                string.IsNullOrWhiteSpace(IngredientUnitTextBox.Text) ||
                !int.TryParse(IngredientCaloriesTextBox.Text, out int calories) ||
                string.IsNullOrWhiteSpace(IngredientFoodGroupTextBox.Text))
            {
                MessageBox.Show("Please ensure all ingredient information is filled correctly and the calorie count is a number.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (currentIngredient == null)
            {
                currentIngredient = new Ingredient();
                currentRecipe.Ingredients.Add(currentIngredient);
            }

            currentIngredient.Name = IngredientNameTextBox.Text;
            currentIngredient.Quantity = quantity;
            currentIngredient.Unit = IngredientUnitTextBox.Text;
            currentIngredient.Calories = calories;
            currentIngredient.FoodGroup = IngredientFoodGroupTextBox.Text;

            NavigationService.GoBack();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
