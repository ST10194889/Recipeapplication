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
    /// Interaction logic for addSteps.xaml
    /// </summary>
    public partial class addSteps : Window
    {
        private Recipes recipe;
        public addSteps(Recipes recipe)
        {
            InitializeComponent();
            this.recipe = recipe;
           
        }
        private void btn_addingStep(object sender, EventArgs e)
        {
            int count = recipe.Steps.Count + 1; // Calculate step count based on existing steps

            string steps = $"{count}. {txtsteps.Text}";
            Steps step = new Steps
            {
                Description = steps
            };

            recipe.Steps.Add(step);
            savedsteps.Items.Add(steps); // Add the step to the ListBox
            txtsteps.Clear();
        }
        private void btn_save(object sender, EventArgs e)
        {
            MainWindow window = new MainWindow();
            window.Show();
            Close();
           
        }
       
    }
}
