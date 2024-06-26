﻿using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace ST10140587_PROG6221_POE
{
    public partial class AddStepPage : Page
    {
        private Recipe currentRecipe;

        public AddStepPage(Recipe recipe)
        {
            InitializeComponent();
            currentRecipe = recipe;
        }

        private void SaveStepButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(StepTextBox.Text))
            {
                MessageBox.Show("Step description cannot be empty.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            currentRecipe.Steps.Add(StepTextBox.Text);
            NavigationService.GoBack();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
