using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ST10140587_PROG6221_POE
{
    public partial class EditRecipePage : Page
    {
        private Recipe currentRecipe;

        public EditRecipePage(Recipe recipe)
        {
            InitializeComponent();
            currentRecipe = recipe;
            RecipeNameTextBox.Text = currentRecipe.Name;
            IngredientsDataGrid.ItemsSource = currentRecipe.Ingredients;
            StepsListBox.ItemsSource = currentRecipe.Steps;
            UpdateTotalCalories();
        }

        private void UpdateTotalCalories()
        {
            int totalCalories = currentRecipe.Ingredients.Sum(i => i.Calories);
            TotalCaloriesTextBlock.Text = totalCalories.ToString();

            if (totalCalories > 300)
            {
                TotalCaloriesTextBlock.Foreground = System.Windows.Media.Brushes.Red;
            }
            else
            {
                TotalCaloriesTextBlock.Foreground = System.Windows.Media.Brushes.Black;
            }
        }

        private void AddIngredientButton_Click(object sender, RoutedEventArgs e)
        {
            // Validate ingredient input
            if (IsValidIngredientInput(out Ingredient ingredient))
            {
                currentRecipe.Ingredients.Add(ingredient);
                IngredientsDataGrid.Items.Refresh();
                UpdateTotalCalories();
            }
            else
            {
                MessageBox.Show("Please ensure all ingredient information is filled correctly and the calorie count is a number.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private bool IsValidIngredientInput(out Ingredient ingredient)
        {
            ingredient = new Ingredient();
            // Perform your validation logic here and populate the ingredient
            return true; // Return false if validation fails
        }

        private void EditIngredientButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedIngredient = IngredientsDataGrid.SelectedItem as Ingredient;
            if (selectedIngredient != null)
            {
                // Navigate to edit ingredient page
            }
        }

        private void RemoveIngredientButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedIngredient = IngredientsDataGrid.SelectedItem as Ingredient;
            if (selectedIngredient != null)
            {
                currentRecipe.Ingredients.Remove(selectedIngredient);
                IngredientsDataGrid.Items.Refresh();
                UpdateTotalCalories();
            }
        }

        private void AddStepButton_Click(object sender, RoutedEventArgs e)
        {
            // Add step logic
        }

        private void EditStepButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedStep = StepsListBox.SelectedItem as string;
            if (selectedStep != null)
            {
                // Edit step logic
            }
        }

        private void RemoveStepButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedStep = StepsListBox.SelectedItem as string;
            if (selectedStep != null)
            {
                currentRecipe.Steps.Remove(selectedStep);
                StepsListBox.Items.Refresh();
            }
        }

        private void SaveRecipeButton_Click(object sender, RoutedEventArgs e)
        {
            // Validate recipe name
            if (string.IsNullOrWhiteSpace(RecipeNameTextBox.Text))
            {
                MessageBox.Show("Recipe name cannot be empty.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            currentRecipe.Name = RecipeNameTextBox.Text;
            // Save recipe logic here

            // Alert if calories exceed 300
            if (currentRecipe.Ingredients.Sum(i => i.Calories) > 300)
            {
                if (MessageBox.Show("Total calorie count exceeds 300. Do you still want to save this recipe?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                {
                    return;
                }
            }

            NavigationService.GoBack();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
