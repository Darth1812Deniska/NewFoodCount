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
        private double CurrentProteinMass { get=>GetCurrentProteinMass(); }
        private double CurrentCarbohydrateMass { get =>GetCurrentCarbohydrateMass(); }
        private double CurrentFatMass { get => GetCurrentFatMass(); }
        private double CurrentProteinRemains { get => GetCurrentProteinRemains(); }
        private double CurrentCarbohydrateRemains { get => GetCurrentCarbohydrateRemains(); }
        private double CurrentFatRemains { get => GetCurrentFatRemains(); }
        public void AddProteinProduct(Product product)
        {
            if (!this.Exists(x => x.Product == product))
            {
                double addingWeight = GetProteinAddingWeight();
                Dish dish = new Dish(product)
                {
                    Protein = addingWeight
                };
                MassRecalculationAddingProtein(addingWeight);
                this.Add(dish);

            }
        }

        public void AddCarbohydrateProduct(Product product)
        {
            if (!this.Exists(x => x.Product == product))
            {
                double addingWeight = GetCarbohydrateAddingWeight();
                Dish dish = new Dish(product)
                {
                    Carbohydrate = addingWeight
                };
                MassRecalculationAddingCarbohydrate(addingWeight);
                this.Add(dish);
            }
        }

        public void AddFatProduct(Product product)
        {
            if (!this.Exists(x => x.Product == product))
            {
                double addingWeight = GetFatAddingWeight();
                Dish dish = new Dish(product)
                {
                    Fat = addingWeight
                };
                MassRecalculationAddingFat(addingWeight);
                this.Add(dish);
            }
        }

        // Перерасчет масс других продуктов
        private void MassRecalculationAddingProtein(double addingWeight)
        {
            Dictionary<Product, double> productProportions = new Dictionary<Product, double>();
            foreach (Dish dish in this)
            {
                productProportions.Add(dish.Product, dish.Protein / CurrentProteinMass);
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
                productProportions.Add(dish.Product, dish.Carbohydrate / CurrentCarbohydrateMass);
            }
            double prevDishWeight = MaxCarbohydrate - addingWeight;
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
                productProportions.Add(dish.Product, dish.Fat / CurrentFatMass);
            }
            double prevDishWeight = MaxFat - addingWeight;
            for (int i = 0; i < this.Count; i++)
            {
                this[i].Fat = productProportions[this[i].Product] * prevDishWeight;
            }
        }
        private double GetCurrentProteinMass()
        {
            double result = 0;
            foreach (Dish dish in this)
            {
                result += dish.Protein;
            }
            return result;
        }
        private double GetCurrentCarbohydrateMass()
        {
            double result = 0;
            foreach (Dish dish in this)
            {
                result += dish.Carbohydrate;
            }
            return result;
        }
        private double GetCurrentFatMass()
        {
            double result = 0;
            foreach (Dish dish in this)
            {
                result += dish.Fat;
            }
            return result;
        }

        private double GetCurrentProteinRemains()
        {
            return MaxProtein - CurrentProteinMass;
        }
        private double GetCurrentCarbohydrateRemains()
        {
            return MaxCarbohydrate - CurrentCarbohydrateMass;
        }
        private double GetCurrentFatRemains()
        {
            return MaxFat - CurrentFatMass;
        }

        private double GetProteinAddingWeight()
        {
            int newCount = Count + 1;
            double addingWeight = MaxProtein / newCount;
            double result;
            if (addingWeight >= CurrentProteinRemains)
            {
                result = addingWeight;
            }
            else
            {
                result = CurrentProteinRemains;
            }
            return result;
        }
        private double GetCarbohydrateAddingWeight()
        {
            int newCount = Count + 1;
            double addingWeight = MaxCarbohydrate / newCount;
            double result;
            if (addingWeight >= CurrentCarbohydrateRemains)
            {
                result = addingWeight;
            }
            else
            {
                result = CurrentCarbohydrateRemains;
            }
            return result;
        }
        private double GetFatAddingWeight()
        {
            int newCount = Count + 1;
            double addingWeight = MaxFat / newCount;
            double result;
            if (addingWeight >= CurrentFatRemains)
            {
                result = addingWeight;
            }
            else
            {
                result = CurrentFatRemains;
            }
            return result;
        }
    }
}
