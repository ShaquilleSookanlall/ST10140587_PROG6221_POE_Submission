﻿using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace ST10140587_PROG6221_POE
{
    public partial class AddIngredientPage : Page
    {
        private Recipe currentRecipe;

        public AddIngredientPage(Recipe recipe)
        {
            InitializeComponent();
            currentRecipe = recipe;
        }

        private void SaveIngredientButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(IngredientNameTextBox.Text) ||
                string.IsNullOrWhiteSpace(IngredientQuantityTextBox.Text) ||
                string.IsNullOrWhiteSpace(IngredientUnitTextBox.Text) ||
                string.IsNullOrWhiteSpace(IngredientCaloriesTextBox.Text) ||
                string.IsNullOrWhiteSpace(IngredientFoodGroupTextBox.Text))
            {
                MessageBox.Show("All fields are required.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!int.TryParse(IngredientCaloriesTextBox.Text, out int calories))
            {
                MessageBox.Show("Calories must be a valid number.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!double.TryParse(IngredientQuantityTextBox.Text, out double quantity))
            {
                MessageBox.Show("Quantity must be a valid number.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Ingredient newIngredient = new Ingredient
            {
                Name = IngredientNameTextBox.Text,
                Quantity = quantity,
                Unit = IngredientUnitTextBox.Text,
                Calories = calories,
                FoodGroup = IngredientFoodGroupTextBox.Text
            };

            currentRecipe.Ingredients.Add(newIngredient);
            NavigationService.GoBack();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
