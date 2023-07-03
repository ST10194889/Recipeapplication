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
using System.Xml.Linq;

namespace Recipeapplication
{
    /// <summary>
    /// Interaction logic for windowADD.xaml
    /// </summary>
    public partial class windowADD : Window
    {
        
        
        public windowADD()
        {
            InitializeComponent();
        }
       // adding action listner to take to next page

        private void btn_next(object sender, RoutedEventArgs e)// add button
        {
         
           
            string recipeName = txtRecName.Text.ToUpper();

            if (recipeName != "")
            {
                recipeNames.Recipenames.Add(recipeName);
                addingridients objADD = new addingridients();
                objADD.Show();
             
             
                
                Close();

            }
            else
            {
                // MessageBox.Show("Name must not be blank");
                MessageBox.Show("Name must not be blank", "Blank Entry", MessageBoxButton.OK);
            }

        }
    }
}
