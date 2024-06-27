using System.Linq;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace ST10140587_PROG6221_POE
{
    public partial class RecipeDetailsPage : Page
    {
        private Recipe currentRecipe;

        public RecipeDetailsPage(Recipe recipe)
        {
            InitializeComponent();
            currentRecipe = recipe;
            RecipeNameTextBlock.Text = currentRecipe.Name;
            RecipeDetailsDataGrid.ItemsSource = currentRecipe.Ingredients;
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

        private void ScaleButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Button button = sender as Button;
            double scale = double.Parse(button.Tag.ToString());
            currentRecipe.ScaleQuantities(scale);
            RecipeDetailsDataGrid.Items.Refresh();
            UpdateTotalCalories();
        }

        private void ResetButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            currentRecipe.ResetQuantities();
            RecipeDetailsDataGrid.Items.Refresh();
            UpdateTotalCalories();
        }

        private void EditRecipeButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService.Navigate(new EditRecipePage(currentRecipe));
        }

        private void BackButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
