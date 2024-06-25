using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ST10140587_PROG6221_POE
{
    public partial class AddRecipePage : Page
    {
        private Recipe currentRecipe;

        public AddRecipePage()
        {
            InitializeComponent();
            currentRecipe = new Recipe();
        }

        private void AddIngredientButton_Click(object sender, RoutedEventArgs e)
        {
            var ingredientDetails = IngredientDetailsTextBox.Text.Split(' ');
            if (ingredientDetails.Length >= 3)
            {
                var ingredient = new Ingredient
                {
                    Quantity = double.Parse(ingredientDetails[0]),
                    Unit = ingredientDetails[1],
                    Name = string.Join(" ", ingredientDetails.Skip(2)),
                    Calories = int.Parse(IngredientCaloriesTextBox.Text)
                };
                currentRecipe.Ingredients.Add(ingredient);
                IngredientDetailsTextBox.Text = string.Empty;
                IngredientCaloriesTextBox.Text = string.Empty;
            }
            else
            {
                MessageBox.Show("Please enter the ingredient details in the format: <amount> <type> of <ingredient name>");
            }
        }

        private void AddStepButton_Click(object sender, RoutedEventArgs e)
        {
            currentRecipe.Steps.Add(StepTextBox.Text);
            StepTextBox.Text = string.Empty;
        }

        private void SaveRecipeButton_Click(object sender, RoutedEventArgs e)
        {
            currentRecipe.Name = RecipeNameTextBox.Text;
            App.Recipes.Add(currentRecipe);
            NavigationService.GoBack();
        }
    }
}
