using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ST10140587_PROG6221_POE
{
    public partial class HomePage : Page
    {
        private List<Recipe> allRecipes;
        private List<Recipe> filteredRecipes;

        public HomePage()
        {
            InitializeComponent();
            LoadRecipes();
        }

        private void LoadRecipes()
        {
            // Load all recipes (this should be replaced with actual data loading logic)
            allRecipes = new List<Recipe>
            {
                new Recipe { Name = "Recipe 1", Ingredients = new List<Ingredient> { new Ingredient { Name = "Ingredient 1" } }, Steps = new List<string> { "Step 1" }, TotalCalories = 100 },
                new Recipe { Name = "Recipe 2", Ingredients = new List<Ingredient> { new Ingredient { Name = "Ingredient 2" } }, Steps = new List<string> { "Step 2" }, TotalCalories = 200 }
            };
            filteredRecipes = allRecipes;
            RecipesListBox.ItemsSource = filteredRecipes.OrderBy(r => r.Name);
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string searchText = SearchTextBox.Text.ToLower();
            filteredRecipes = allRecipes
                .Where(r => r.Name.ToLower().Contains(searchText) ||
                            r.Ingredients.Any(i => i.Name.ToLower().Contains(searchText)) ||
                            (int.TryParse(searchText, out int calories) && r.TotalCalories <= calories))
                .ToList();
            RecipesListBox.ItemsSource = filteredRecipes.OrderBy(r => r.Name);
        }

        private void RecipesListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedRecipe = RecipesListBox.SelectedItem as Recipe;
            if (selectedRecipe != null)
            {
                NavigationService.Navigate(new RecipeDetailsPage(selectedRecipe));
            }
        }
    }
}
