using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipeapplication
{
    //constructor for the recipe
    public class Recipes
    {
        public string Name { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public List<Steps> Steps { get; set; }

        public Recipes(string name)
        {
            Name = name;
            Ingredients = new List<Ingredient>();
            Steps = new List<Steps>();
        }
    }
    public class Ingredient // class to store ingirdients
    {
        public string Name { get; set; }
        public int Calories { get; set; }
        public int Quantity { get; set; }
        public string unit { get; set; }
        public string foodGroup { get; set; }
    }
    public class Steps //class to store the steps
    {
        public string Description { get; set; }
    }
    public static class recipeNames
    {
        public static List<string> Recipenames { get; set; }

        static recipeNames()
        {
            Recipenames = new List<string>();
        }
    }
    

}
