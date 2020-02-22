using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewFoodCount
{
    public class Product
    {
        public string Name { get; set; }
        public double Protein { get; set; }
        public double Carbohydrate { get; set; }
        public double Fat { get; set; }
        public double Calorific { get; set; }
        public Product()
        {

        }

        public Product(string name, double protein,
            double carbohydrate, double fat, double calorific)
        {
            Name = name;
            Protein = protein;
            Carbohydrate = carbohydrate;
            Fat = fat;
            Calorific = calorific;
        }

        public override bool Equals(object obj)
        {
            return obj is Product product &&
                   Name == product.Name &&
                   Protein == product.Protein &&
                   Carbohydrate == product.Carbohydrate &&
                   Fat == product.Fat &&
                   Calorific == product.Calorific;
        }

        public override int GetHashCode()
        {
            var hashCode = -9536604;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + Protein.GetHashCode();
            hashCode = hashCode * -1521134295 + Carbohydrate.GetHashCode();
            hashCode = hashCode * -1521134295 + Fat.GetHashCode();
            hashCode = hashCode * -1521134295 + Calorific.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
