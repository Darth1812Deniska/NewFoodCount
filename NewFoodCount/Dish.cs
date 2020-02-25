using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewFoodCount
{
    public class Dish
    {
        private readonly Product _product;
        private double weight;

        public Product Product => _product;
        public double Weight { get => weight; set => weight = value; }
        public double Protein { get => GetProtein(); set => SetProtein(value); }
        public double Carbohydrate { get => GetCarbohydrate(); set =>SetCarbohydrate(value); }
        public double Fat { get => GetFat(); set => SetFat(value); }
        public double Calorific { get => GetCalorific(); set => SetCalorific(value); }
        public Dish()
        {

        }
        public Dish(Product product)
        {
            this._product = product;
        }
        public Dish(Product product, double weight)
        {
            _product = product;
            Weight = weight;
        }
        private double GetProtein()
        {
            return Product.Protein * Weight;
        }
        private double GetCarbohydrate()
        {
            return Product.Carbohydrate * Weight;
        }
        private double GetFat()
        {
            return Product.Fat * Weight;
        }
        private double GetCalorific()
        {
            return Product.Calorific * Weight;
        }

        private void SetProtein(double value)
        {
            weight = value / Product.Protein;
        }
        private void SetCarbohydrate(double value)
        {
            weight = value / Product.Carbohydrate;
        }
        private void SetFat(double value)
        {
            weight = value / Product.Fat;
        }
        private void SetCalorific(double value)
        {
            weight = value / Product.Calorific;
        }

        public override string ToString()
        {
            return Product.Name;
        }

        public override bool Equals(object obj)
        {
            return obj is Dish dish &&
                   EqualityComparer<Product>.Default.Equals(Product, dish.Product);
        }

        public override int GetHashCode()
        {
            return -957662036 + EqualityComparer<Product>.Default.GetHashCode(Product);
        }
    }
    public class DishCollection:List<Dish>
    {
        public double MaxProtein { get; set; }
        public double MaxCarbohydrate { get; set; }
        public double MaxFat { get; set; }
        public double MaxCalorific { get; set; }
        public void AddProteinProduct(Product product)
        {
            int productCount = this.Count;
            if (productCount >= 0)
            {
                int newCount = productCount + 1;
                double addingWeight = MaxProtein / newCount;
                this.Add(new Dish(product, addingWeight));
            }
        }
        public void AddCarbohydrateProduct(Product product)
        {
            int productCount = this.Count;
            if (productCount >= 0)
            {
                int newCount = productCount + 1;
                double addingWeight = MaxCarbohydrate / newCount;
                this.Add(new Dish(product, addingWeight));
            }
        }
        public void AddFatProduct(Product product)
        {
            int productCount = this.Count;
            if (productCount >= 0)
            {
                int newCount = productCount + 1;
                double addingWeight = MaxFat / newCount;
                this.Add(new Dish(product, addingWeight));
            }
        }

        // Перерасчет масс других продуктов
        private void MassRecalculationAddingProtein(double addingWeight)
        {
            Dictionary<Product, double> productProportions = new Dictionary<Product, double>();
            foreach (Dish dish in this)
            {
                productProportions.Add(dish.Product, dish.Protein / MaxProtein);
            }
            double prevDishWeight = MaxProtein - addingWeight;
         
            for (int i = 0; i < this.Count; i++)
            {
                this[i].Protein = productProportions[this[i].Product] * prevDishWeight;
            }
        }

        private void MassRecalculationAddingCarbohydrate(double addingWeight)
        {
            Dictionary<Product, double> productProportions = new Dictionary<Product, double>();
            foreach (Dish dish in this)
            {
                productProportions.Add(dish.Product, dish.Carbohydrate / MaxCarbohydrate);
            }
            double prevDishWeight = MaxProtein - addingWeight;
            for (int i = 0; i < this.Count; i++)
            {
                this[i].Carbohydrate = productProportions[this[i].Product] * prevDishWeight;
            }
        }

        private void MassRecalculationAddingFat(double addingWeight)
        {
            Dictionary<Product, double> productProportions = new Dictionary<Product, double>();
            foreach (Dish dish in this)
            {
                productProportions.Add(dish.Product, dish.Fat / MaxFat);
            }
            double prevDishWeight = MaxProtein - addingWeight;
            for (int i = 0; i < this.Count; i++)
            {
                this[i].Fat = productProportions[this[i].Product] * prevDishWeight;
            }
        }
    }
}
