using System.Windows;
using System.Windows.Controls;

namespace ST10140587_PROG6221_POE
{
    public partial class AddStepPage : Page
    {
        private Recipe currentRecipe;
        private string currentStep;

        public AddStepPage(Recipe recipe, string step = null)
        {
            InitializeComponent();
            currentRecipe = recipe;
            currentStep = step;

            if (currentStep != null)
            {
                StepTextBox.Text = currentStep;
            }
        }

        private void SaveStepButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(StepTextBox.Text))
            {
                MessageBox.Show("Step cannot be empty.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (currentStep == null)
            {
                currentRecipe.Steps.Add(StepTextBox.Text);
            }
            else
            {
                var index = currentRecipe.Steps.IndexOf(currentStep);
                currentRecipe.Steps[index] = StepTextBox.Text;
            }

            NavigationService.GoBack();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
