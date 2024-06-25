using System.Linq;
using System.Windows.Controls;

namespace ST10140587_PROG6221_POE
{
    public partial class HomePage : Page
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            BindData();
        }

        private void BindData()
        {
            RecipesListBox.ItemsSource = App.Recipes.OrderBy(r => r.Name).Select(r => r.Name).ToList();
        }

        private void AddNewRecipeButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var newRecipe = new Recipe();
            App.Recipes.Add(newRecipe);
            NavigationService.Navigate(new EditRecipePage(newRecipe));
        }

        private void RecipesListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedRecipeName = RecipesListBox.SelectedItem as string;
            if (selectedRecipeName != null)
            {
                NavigationService.Navigate(new RecipeDetailsPage(selectedRecipeName));
            }
        }

        private void SearchButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var searchQuery = CombinedSearchBox.Text.ToLower();
            var filteredRecipes = App.Recipes.AsQueryable();

            bool calorieSearch = int.TryParse(searchQuery, out int calorieLimit);

            if (!string.IsNullOrWhiteSpace(searchQuery))
            {
                filteredRecipes = filteredRecipes.Where(r =>
                    r.Name.ToLower().Contains(searchQuery) ||
                    r.Ingredients.Any(i => i.FoodGroup.ToLower().Contains(searchQuery)) ||
                    (calorieSearch && r.Ingredients.Sum(i => i.Calories) <= calorieLimit));
            }

            RecipesListBox.ItemsSource = filteredRecipes.OrderBy(r => r.Name).Select(r => r.Name).ToList();
        }
    }
}
