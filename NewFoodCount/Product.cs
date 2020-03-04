using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

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

    public class ProductCollection: List<Product>
    {

    }

    public static class AllProducts
    {
        private static  ProductCollection products;

        public static ProductCollection Products => products;
        public static void Save()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ProductCollection));
            using (FileStream fs = new FileStream("products.xml", FileMode.OpenOrCreate))
            {
                serializer.Serialize(fs, products);
            }
        }
        public static void Load()
        {
            if (File.Exists("products.xml"))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(ProductCollection));
                using (FileStream fs = new FileStream("products.xml", FileMode.OpenOrCreate))
                using (XmlReader reader = XmlReader.Create(fs))
                {
                    ProductCollection list = (ProductCollection)serializer.Deserialize(reader);
                    products = list;
                }
            }
            else
            {
                products = new ProductCollection();
            }
        }

        public static List<Product> GetProteinProducts()
        {
            return Products.OrderByDescending(x => x.Protein).ToList();
        }

        public static List<Product> GetCarbohydrateProducts()
        {
            return Products.OrderByDescending(x => x.Carbohydrate).ToList();
        }

        public static List<Product> GetFatProducts()
        {
            return Products.OrderByDescending(x => x.Fat).ToList();
        }
    }

}
