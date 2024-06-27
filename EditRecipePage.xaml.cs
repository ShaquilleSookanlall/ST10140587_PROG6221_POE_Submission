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

        private void IngredientsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Handle selection changed event if needed
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
            NavigationService.Navigate(new AddIngredientPage(currentRecipe));
        }

        private void EditIngredientButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedIngredient = IngredientsDataGrid.SelectedItem as Ingredient;
            if (selectedIngredient != null)
            {
                NavigationService.Navigate(new AddIngredientPage(currentRecipe, selectedIngredient));
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
            NavigationService.Navigate(new AddStepPage(currentRecipe));
        }

        private void EditStepButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedStep = StepsListBox.SelectedItem as string;
            if (selectedStep != null)
            {
                NavigationService.Navigate(new AddStepPage(currentRecipe, selectedStep));
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

            // Validate at least one ingredient and one step
            if (currentRecipe.Ingredients.Count == 0)
            {
                MessageBox.Show("Recipe must have at least one ingredient.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (currentRecipe.Steps.Count == 0)
            {
                MessageBox.Show("Recipe must have at least one step.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            currentRecipe.Name = RecipeNameTextBox.Text;

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

        private void ScaleButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            double scale = double.Parse(button.Tag.ToString());
            currentRecipe.ScaleQuantities(scale);
            IngredientsDataGrid.Items.Refresh();
            UpdateTotalCalories();
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            currentRecipe.ResetQuantities();
            IngredientsDataGrid.Items.Refresh();
            UpdateTotalCalories();
        }
    }
}
