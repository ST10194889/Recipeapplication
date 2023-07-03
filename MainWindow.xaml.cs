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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Recipeapplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
      
        
        public static List<Recipes> recipe_new = new List<Recipes>();

        public MainWindow()
        {
            InitializeComponent();
           
        }
        // creating a methods for when the user clicks the buttons
        private void btn_ADD(object sender, RoutedEventArgs e)// add button
        {
            windowADD onjADD = new windowADD();

            onjADD.Show();
            Close();
        }
        private void btn_exit(object sender, RoutedEventArgs e)// exit button 
        {
            Environment.Exit(0);
        }
        private void btn_display(object sender, RoutedEventArgs e)// display button
        {
            if (recipeNames.Recipenames.Count >=1)
            {
                DisplayWindow objDisplay = new DisplayWindow();
                objDisplay.Show();
                Close();
            }
            else
            {
                MessageBox.Show("NO RECIPES FOUND", "Empty recipes", MessageBoxButton.OK);
            }
           
        }
        private void btn_view(object sender, RoutedEventArgs e)
        {
            if (recipeNames.Recipenames.Count >= 1)
            {
              display objdisplay = new display();
                objdisplay.Show();
                Close();
            }
            else
            {
                MessageBox.Show("NO RECIPES FOUND", "Empty recipes", MessageBoxButton.OK);
            }
        }

    }
}
