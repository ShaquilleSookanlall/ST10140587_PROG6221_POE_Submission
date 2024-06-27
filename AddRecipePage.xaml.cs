using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace ST10140587_PROG6221_POE
{
    public partial class AddRecipePage : Page
    {
        private Recipe currentRecipe;

        public AddRecipePage()
        {
            InitializeComponent();
            currentRecipe = new Recipe();
            DataContext = currentRecipe;
            IngredientsDataGrid.ItemsSource = currentRecipe.Ingredients;
            StepsListBox.ItemsSource = currentRecipe.Steps;
            UpdateTotalCalories();
        }

        private void AddIngredientButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddIngredientPage(currentRecipe));
        }

        private void EditIngredientButton_Click(object sender, RoutedEventArgs e)
        {
            if (IngredientsDataGrid.SelectedItem is Ingredient selectedIngredient)
            {
                NavigationService.Navigate(new EditIngredientPage(currentRecipe, selectedIngredient));
            }
            else
            {
                MessageBox.Show("Please select an ingredient to edit.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void RemoveIngredientButton_Click(object sender, RoutedEventArgs e)
        {
            if (IngredientsDataGrid.SelectedItem is Ingredient selectedIngredient)
            {
                currentRecipe.Ingredients.Remove(selectedIngredient);
                IngredientsDataGrid.ItemsSource = null;
                IngredientsDataGrid.ItemsSource = currentRecipe.Ingredients;
                UpdateTotalCalories();
            }
            else
            {
                MessageBox.Show("Please select an ingredient to remove.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AddStepButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddStepPage(currentRecipe));
        }

        private void EditStepButton_Click(object sender, RoutedEventArgs e)
        {
            if (StepsListBox.SelectedItem is string selectedStep)
            {
                NavigationService.Navigate(new EditStepPage(currentRecipe, selectedStep));
            }
            else
            {
                MessageBox.Show("Please select a step to edit.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void RemoveStepButton_Click(object sender, RoutedEventArgs e)
        {
            if (StepsListBox.SelectedItem is string selectedStep)
            {
                currentRecipe.Steps.Remove(selectedStep);
                StepsListBox.ItemsSource = null;
                StepsListBox.ItemsSource = currentRecipe.Steps;
            }
            else
            {
                MessageBox.Show("Please select a step to remove.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void SaveRecipeButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(RecipeNameTextBox.Text))
            {
                MessageBox.Show("Recipe name cannot be empty.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (currentRecipe.Ingredients.Count == 0)
            {
                MessageBox.Show("A recipe must have at least one ingredient.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (currentRecipe.Steps.Count == 0)
            {
                MessageBox.Show("A recipe must have at least one step.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            currentRecipe.Name = RecipeNameTextBox.Text;
            App.Recipes.Add(currentRecipe);
            NavigationService.GoBack();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void UpdateTotalCalories()
        {
            TotalCaloriesTextBlock.Text = $"Total Calories: {currentRecipe.TotalCalories}";
            if (currentRecipe.TotalCalories > 300)
            {
                TotalCaloriesTextBlock.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Red);
            }
            else
            {
                TotalCaloriesTextBlock.Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Black);
            }
        }
    }
}
