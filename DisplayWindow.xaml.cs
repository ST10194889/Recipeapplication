using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Recipeapplication
{
    /// <summary>
    /// Interaction logic for DisplayWindow.xaml
    /// </summary>
    public partial class DisplayWindow : Window
    {
        public DisplayWindow()
        {
            InitializeComponent();
            loadName();
            loadRecipes();
            loadfoodgroup();

        }
       public void loadRecipes()
        {
            recipeNames.Recipenames.Sort();
            foreach (string recipe in recipeNames.Recipenames)
            {
                RecipeBox.Items.Add(recipe);
            }
           
        }
        private void cmbFood_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void cmbName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        public void loadfoodgroup()
        {
            cmbFood.Items.Add("Carbohydrates");
            cmbFood.Items.Add("Vegetable");
            cmbFood.Items.Add("Fruit");
            cmbFood.Items.Add("Other");
        }
        public void loadName()
        {
            recipeNames.Recipenames.Sort();
            foreach (string recipe in recipeNames.Recipenames)
            { // foreach loop that will display all the recipes 
                cmbName.Items.Add(recipe);
            }
        }
        private void btn_display(object sender, RoutedEventArgs e)
        {
            RecipeBox.Items.Clear();

            string selectedIngredient = txtingrid.Text.ToUpper();
            string selectedName = cmbName.SelectedItem?.ToString();
            string selectedFoodGroup = cmbFood.SelectedItem?.ToString();
            int maxCalories = (int)caloriesSlider.Value;

            var filteredRecipes = MainWindow.recipe_new.Where(recipe =>
                (string.IsNullOrEmpty(selectedIngredient) || recipe.Ingredients.Any(ingredient => ingredient.Name.ToUpper().Contains(selectedIngredient))) &&
                (string.IsNullOrEmpty(selectedName) || recipe.Name.ToUpper().Contains(selectedName.ToUpper())) &&
                (string.IsNullOrEmpty(selectedFoodGroup) || recipe.Ingredients.Any(ingredient => ingredient.foodGroup == selectedFoodGroup)) &&
                recipe.Ingredients.Sum(ingredient => ingredient.Calories) <= maxCalories
            );

            if (filteredRecipes.Any())
            {
                foreach (Recipes recipe in filteredRecipes)
                {
                    RecipeBox.Items.Add($"-------{recipe.Name}--------- \nIngredients:  ");
                    foreach (Ingredient ingredient in recipe.Ingredients)
                    {
                        RecipeBox.Items.Add($"{ingredient.Name} - {ingredient.Quantity} {ingredient.unit}, {ingredient.Calories} Calories  {ingredient.foodGroup}");
                    }
                    RecipeBox.Items.Add("\n  Steps:");
                    foreach (Steps step in recipe.Steps)
                    {
                        RecipeBox.Items.Add($" {step.Description}");
                    }
                }
            }
            else
            {
                RecipeBox.Items.Add("No recipes found.");
            }
        }


    }
}
