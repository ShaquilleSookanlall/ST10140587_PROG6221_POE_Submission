using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ST10140587_PROG6221_POE
{
    public partial class RecipeDetailsPage : Page
    {
        private Recipe currentRecipe;
        private Dictionary<string, double> originalQuantities;

        public RecipeDetailsPage(Recipe recipe)
        {
            InitializeComponent();
            currentRecipe = recipe;
            originalQuantities = new Dictionary<string, double>();
            foreach (var ingredient in recipe.Ingredients)
            {
                originalQuantities[ingredient.Name] = ingredient.Quantity;
            }
            DisplayRecipe();
        }

        private void DisplayRecipe()
        {
            RecipeNameTextBlock.Text = currentRecipe.Name;
            RecipeDetailsDataGrid.ItemsSource = currentRecipe.Ingredients;
            StepsListBox.ItemsSource = currentRecipe.Steps;
            UpdateTotalCalories();
        }

        private void UpdateTotalCalories()
        {
            int totalCalories = currentRecipe.Ingredients.Sum(i => i.Calories);
            TotalCaloriesTextBlock.Text = $"Total Calories: {totalCalories}";
            TotalCaloriesTextBlock.Foreground = totalCalories > 300 ? new SolidColorBrush(Colors.Red) : new SolidColorBrush(Colors.Black);
        }

        private void ScaleButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                double scale = double.Parse(button.Tag.ToString());
                foreach (var ingredient in currentRecipe.Ingredients)
                {
                    ingredient.Quantity = originalQuantities[ingredient.Name] * scale;
                }
                RecipeDetailsDataGrid.ItemsSource = null;
                RecipeDetailsDataGrid.ItemsSource = currentRecipe.Ingredients;
                UpdateTotalCalories();
            }
        }

        private void EditRecipeButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EditRecipePage(currentRecipe));
        }

        private void DeleteRecipeButton_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to delete this recipe?", "Confirm Delete", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                App.Recipes.Remove(currentRecipe); // Use App class name directly
                NavigationService.GoBack();
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
