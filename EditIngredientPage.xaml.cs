using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace ST10140587_PROG6221_POE
{
    public partial class EditIngredientPage : Page
    {
        private Recipe currentRecipe;
        private Ingredient currentIngredient;

        public EditIngredientPage(Recipe recipe, Ingredient ingredient)
        {
            InitializeComponent();
            currentRecipe = recipe;
            currentIngredient = ingredient;
            IngredientNameTextBox.Text = ingredient.Name;
            IngredientQuantityTextBox.Text = ingredient.Quantity.ToString();
            IngredientUnitTextBox.Text = ingredient.Unit;
            IngredientCaloriesTextBox.Text = ingredient.Calories.ToString();
            IngredientFoodGroupTextBox.Text = ingredient.FoodGroup;
        }

        private void SaveIngredientButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(IngredientNameTextBox.Text) ||
                string.IsNullOrWhiteSpace(IngredientQuantityTextBox.Text) ||
                string.IsNullOrWhiteSpace(IngredientUnitTextBox.Text) ||
                string.IsNullOrWhiteSpace(IngredientCaloriesTextBox.Text) ||
                string.IsNullOrWhiteSpace(IngredientFoodGroupTextBox.Text))
            {
                MessageBox.Show("All fields are required.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!int.TryParse(IngredientCaloriesTextBox.Text, out int calories))
            {
                MessageBox.Show("Calories must be a valid number.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!double.TryParse(IngredientQuantityTextBox.Text, out double quantity))
            {
                MessageBox.Show("Quantity must be a valid number.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
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
