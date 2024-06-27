using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace ST10140587_PROG6221_POE
{
    public partial class EditStepPage : Page
    {
        private Recipe currentRecipe;
        private string currentStep;

        public EditStepPage(Recipe recipe, string step)
        {
            InitializeComponent();
            currentRecipe = recipe;
            currentStep = step;
            StepTextBox.Text = step;
        }

        private void SaveStepButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(StepTextBox.Text))
            {
                MessageBox.Show("Step description cannot be empty.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            int index = currentRecipe.Steps.IndexOf(currentStep);
            if (index >= 0)
            {
                currentRecipe.Steps[index] = StepTextBox.Text;
            }
            else
            {
                currentRecipe.Steps.Add(StepTextBox.Text);
            }
            NavigationService.GoBack();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
