using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace ST10140587_PROG6221_POE
{
    public partial class HomePage : Page
    {
        public HomePage()
        {
            InitializeComponent();
            RecipesListBox.ItemsSource = App.Recipes;
        }

        private void AddNewRecipeButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddRecipePage());
        }

        private void RecipesListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (RecipesListBox.SelectedItem is Recipe selectedRecipe)
            {
                NavigationService.Navigate(new RecipeDetailsPage(selectedRecipe));
            }
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string searchText = CombinedSearchBox.Text.ToLower();
            int cal;
            bool isCalValid = int.TryParse(searchText, out cal);

            var filteredRecipes = App.Recipes.Where(r =>
                r.Name.ToLower().Contains(searchText) ||
                r.Ingredients.Any(i => i.FoodGroup.ToLower().Contains(searchText) || i.Name.ToLower().Contains(searchText)) ||
                (isCalValid && r.TotalCalories <= cal)
            ).ToList();

            RecipesListBox.ItemsSource = filteredRecipes.OrderBy(r => r.Name);
        }
    }
}
