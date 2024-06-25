using System.Linq;
using System.Windows.Controls;

namespace ST10140587_PROG6221_POE
{
    public partial class RecipeDetailsPage : Page
    {
        private Recipe originalRecipe;
        private Recipe currentRecipe;

        public RecipeDetailsPage(string recipeName)
        {
            InitializeComponent();
            originalRecipe = App.Recipes.FirstOrDefault(r => r.Name == recipeName);
            currentRecipe = originalRecipe.Clone();
            BindData();
        }

        private void BindData()
        {
            RecipeNameTextBlock.Text = currentRecipe.Name;
            RecipeDetailsDataGrid.ItemsSource = currentRecipe.Ingredients;
            StepsListBox.ItemsSource = currentRecipe.Steps;
        }

        private void ScaleButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Button button = sender as Button;
            double scale = double.Parse(button.Tag.ToString());
            currentRecipe = originalRecipe.Clone();
            currentRecipe.ScaleRecipe(scale);
            BindData();
        }

        private void BackButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void EditRecipeButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService.Navigate(new EditRecipePage(originalRecipe));
        }
    }
}
