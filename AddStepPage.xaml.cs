using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace ST10140587_PROG6221_POE
{
    public partial class AddStepPage : Page
    {
        private Recipe currentRecipe;
        private string currentStep;
        private int stepIndex;

        public AddStepPage(Recipe recipe)
        {
            InitializeComponent();
            currentRecipe = recipe;
        }

        public AddStepPage(Recipe recipe, string step) : this(recipe)
        {
            currentStep = step;
            stepIndex = recipe.Steps.IndexOf(step);
            StepTextBox.Text = step;
        }

        private void SaveStepButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentStep == null)
            {
                currentRecipe.Steps.Add(StepTextBox.Text);
            }
            else
            {
                currentRecipe.Steps[stepIndex] = StepTextBox.Text;
            }
            NavigationService navigationService = NavigationService.GetNavigationService(this);
            navigationService.GoBack();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService navigationService = NavigationService.GetNavigationService(this);
            navigationService.GoBack();
        }
    }
}
