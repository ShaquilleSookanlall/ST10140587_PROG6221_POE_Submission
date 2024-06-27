

Recipe App Library
This project is a WPF (Windows Presentation Foundation) application for managing recipes. Users can add, edit, view, scale, and delete recipes. Each recipe includes ingredients and steps, and users can also filter and search for recipes based on name, ingredients, food group, or calorie content.

Functionality
Add Recipe: Allows users to add a new recipe with ingredients and steps.
Edit Recipe: Users can edit an existing recipe, including its ingredients and steps.
View Recipe: Users can view the details of a recipe, including ingredients and steps.
Scale Recipe: Users can scale the ingredients of a recipe by 0.5x, 2x, or 3x, and reset to the original quantities.
Delete Recipe: Users can delete a recipe from the app.
Search Recipes: Users can search for recipes by name, ingredients, food group, or calorie content.

Components
App.xaml: Contains the application-level resources.
MainWindow.xaml: The main window of the application.
HomePage.xaml: The home page displaying the list of recipes and search functionality.
AddRecipePage.xaml: The page for adding a new recipe.
EditRecipePage.xaml: The page for editing an existing recipe.
RecipeDetailsPage.xaml: The page for viewing the details of a recipe.
AddIngredientPage.xaml: The page for adding an ingredient to a recipe.
AddStepPage.xaml: The page for adding a step to a recipe.
Recipe.cs: The model class for a recipe.
Ingredient.cs: The model class for an ingredient.

Updates from Part 2 to Final Part
Search Functionality: Implemented search functionality on the Home Page to allow users to search for recipes by name, ingredients, food group, or calorie content.
Improved UI Layout: Updated the layout of the AddRecipePage and EditRecipePage for better user experience.
Ingredient and Step Management: Users can now add, edit, and remove ingredients and steps on separate pages.
Validation: Added validation to ensure that recipes have a name, at least one ingredient, and at least one step. Also added validation to ensure ingredients have all required information and that the calorie count is a valid number.
Calorie Highlighting: The total calories of a recipe are highlighted in red if they exceed 300 calories.
Scaling Recipes: Fixed the scaling functionality to scale from the original values and reset to the original quantities.
Delete Recipe: Added functionality to delete a recipe from the app.
Color Scheme: Applied a consistent color scheme throughout the app for a better visual appeal.
