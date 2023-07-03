using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Recipeapplication
{
    /// <summary>
    /// Interaction logic for display.xaml
    /// </summary>
    public partial class display : Window
    {
        public display()
        {
            InitializeComponent();
            LoadRecipes();
        }

        public void LoadRecipes()
        {
            recipeNames.Recipenames.Sort();
            foreach (string recipe in recipeNames.Recipenames)
            {
                RecipeBox.Items.Add(recipe);
                cmbName.Items.Add(recipe);
            }
        }

        private void cmbName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void btn_viewing(object sender, RoutedEventArgs e)
        {
            RecipeBox.Items.Clear();
            string searchName = cmbName.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(searchName))
            {
                MessageBox.Show("Please select a recipe.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Recipes searchRecipe = MainWindow.recipe_new.Find(r => r.Name == searchName);
            if (searchRecipe == null)
            {
                MessageBox.Show("Recipe not found.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            RecipeBox.Items.Add($"-------{searchRecipe.Name}--------- \nIngredients:  ");
            foreach (Ingredient ingredient in searchRecipe.Ingredients)
            {
                RecipeBox.Items.Add($"{ingredient.Name} - {ingredient.Quantity} {ingredient.unit}, {ingredient.Calories} Calories  {ingredient.foodGroup}");
            }
            RecipeBox.Items.Add("\n  Steps:");
            foreach(Steps steps in searchRecipe.Steps)
            {
                RecipeBox.Items.Add($" {steps.Description}");
            }
        }

        private void btn_return(object sender, RoutedEventArgs e) // method to return to main menu
        {
            MainWindow obj = new MainWindow();
            obj.Show();
            Close();
        }
        private void btn_delete(object sender, RoutedEventArgs e)
        {
            string selectedRecipe = cmbName.SelectedItem?.ToString();

            if (!string.IsNullOrEmpty(selectedRecipe))
            {
                Recipes recipeToDelete = MainWindow.recipe_new.Find(r => r.Name == selectedRecipe);

                if (recipeToDelete != null)
                {
                    MainWindow.recipe_new.Remove(recipeToDelete); // removes the recipe from the list
                    RecipeBox.Items.Clear();// clears the list box
                    recipeNames.Recipenames.Remove(selectedRecipe); // Remove the recipe name from recipeNames list
                    LoadRecipes();
                    MessageBox.Show("Recipe deleted successfully.", "Delete Recipe", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Selected recipe not found.", "Delete Recipe", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                MessageBox.Show("No recipe selected.", "Delete Recipe", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}

