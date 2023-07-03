using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
    /// Interaction logic for addingridients.xaml
    /// </summary>
    public partial class addingridients : Window
    {
        private static string recipename;
        private Recipes recipes;

        public addingridients()
        {
            InitializeComponent();
            recipename = recipeNames.Recipenames.LastOrDefault();
            recipes = new Recipes(recipename);
            lbname.Items.Add(recipename);

            //methods to populate combobox
            loadfoodgroup();


            recipes = new Recipes(recipename);
            lbname.Items.Add(recipename);
        }
        //method to populate the food group combobox
        public void loadfoodgroup()
        {
            cmbFood.Items.Add("Carbohydrates");
            cmbFood.Items.Add("Vegetable");
            cmbFood.Items.Add("Fruit");
            cmbFood.Items.Add("Other");
        }
        private void cmbFood_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void btn_adding(object sender, RoutedEventArgs e)
        {
            string name = txtingrid.Text.ToUpper();
            int calories = Convert.ToInt32(txtCalories.Text);
            int quant = Convert.ToInt32(txtQuant.Text);
            string unit = txtunit.Text.ToUpper();
            string FoodGroup = cmbFood.SelectedItem.ToString(); ;
            //checking if the fields are not empty

            if (name != "" && calories != null && quant != null && unit != "")
            {

                // adding ingridients to the list
                Ingredient ingredient = new Ingredient
                {
                    Name = name,
                    Calories = calories,
                    Quantity = quant,
                    unit = unit,
                    foodGroup = FoodGroup
                };

                recipes.Ingredients.Add(ingredient);

                txtingrid.Clear();
                txtCalories.Clear();
                txtQuant.Clear();
                txtunit.Clear();


            }
            else { MessageBox.Show("Please fill in all the fields", "Blank Entry", MessageBoxButton.OK); }

        }
        private void btn_steps(object sender, RoutedEventArgs e)
        {
            
                MainWindow.recipe_new.Add(recipes);
                addSteps objsteps = new addSteps(recipes);
                objsteps.Show();
                Close();
            }
        }
        }

    

    
