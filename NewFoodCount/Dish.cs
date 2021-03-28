using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Drawing;

namespace NewFoodCount
{
    /// <summary>
    /// Класс описывающий блюдо
    /// </summary>
    public class Dish
    {
        private Product _product;
        private readonly Brush color;
        private readonly NutrientType addAsNutrientType;
        private double weight;

        /// <summary>
        /// Продукт из которого состоит блюдо
        /// </summary>
        public Product Product { get => _product; set => _product = value; }
        /// <summary> 
        /// Вес блюда
        /// </summary>
        public double Weight { get => weight; set => weight = value; }
        public double Protein { get => GetProtein(); set => SetProtein(value); }
        public double Carbohydrate { get => GetCarbohydrate(); set => SetCarbohydrate(value); }
        public double Fat { get => GetFat(); set => SetFat(value); }
        public double Calorific { get => GetCalorific(); set => SetCalorific(value); }
        public Brush DishColor => color;
        public NutrientType AddAsNutrientType => addAsNutrientType;

        public Dish()
        {
            Random r = new Random();
            color = new SolidColorBrush(Color.FromRgb((byte)r.Next(1, 255),
              (byte)r.Next(1, 255), (byte)r.Next(1, 255)));
        }

        public Dish(Product product, NutrientType nutrientType)
        {
            this._product = product;
            addAsNutrientType = nutrientType;
            Random r = new Random();
            color = new SolidColorBrush(Color.FromRgb((byte)r.Next(1, 255),
              (byte)r.Next(1, 255), (byte)r.Next(1, 255)));
        }

        public Dish(Product product, NutrientType nutrientType, double weight)
        {
            _product = product;
            Weight = weight;
            addAsNutrientType = nutrientType;
            Random r = new Random();
            color = new SolidColorBrush(Color.FromRgb((byte)r.Next(1, 255),
              (byte)r.Next(1, 255), (byte)r.Next(1, 255)));
        }

        private double GetProtein()
        {
            return Math.Round(Product.Protein * Weight, 2);
        }
        private double GetCarbohydrate()
        {
            return Math.Round(Product.Carbohydrate * Weight, 2);
        }
        private double GetFat()
        {
            return Math.Round(Product.Fat * Weight, 2);
        }
        private double GetCalorific()
        {
            return Math.Round(Product.Calorific * Weight, 2);
        }

        private void SetProtein(double value)
        {
            weight = Math.Round(value / Product.Protein, 2);
        }
        private void SetCarbohydrate(double value)
        {
            weight = Math.Round(value / Product.Carbohydrate, 2);
        }
        private void SetFat(double value)
        {
            weight = Math.Round(value / Product.Fat, 2);
        }
        private void SetCalorific(double value)
        {
            weight = Math.Round(value / Product.Calorific, 2);
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

    [Serializable]
    public class DishCollection:List<Dish>
    {
        public double MaxProtein { get; set; }
        public double MaxCarbohydrate { get; set; }
        public double MaxFat { get; set; }
        public double MaxCalorific { get; set; }
        public double CurrentCalorificMass { get => GetCurrentCalorificMass(); }
        public double CurrentProteinMass { get=>GetCurrentProteinMass(); }
        public double CurrentCarbohydrateMass { get =>GetCurrentCarbohydrateMass(); }
        public double CurrentFatMass { get => GetCurrentFatMass(); }
        private double CurrentProteinRemains { get => GetCurrentProteinRemains(); }
        private double CurrentCarbohydrateRemains { get => GetCurrentCarbohydrateRemains(); }
        private double CurrentFatRemains { get => GetCurrentFatRemains(); }
        public void AddProteinProduct(Product product)
        {
            if (!this.Exists(x => x.Product == product))
            {
                double addingWeight = GetProteinAddingWeight();
                Dish dish = new Dish(product, NutrientType.Protein)
                {
                    Protein = addingWeight
                };
                MassRecalculationAddingProtein(addingWeight);
                this.Add(dish);

                if (CheckCarbohydrateForOverage())
                {
                    RecalculationCarbohydrateToMax();
                }
                if (CheckFatForOverage())
                {
                    RecalculationFatToMax();
                }
            }
        }

        public void AddCarbohydrateProduct(Product product)
        {
            if (!this.Exists(x => x.Product == product))
            {
                double addingWeight = GetCarbohydrateAddingWeight();
                Dish dish = new Dish(product,NutrientType.Carbohydrate)
                {
                    Carbohydrate = addingWeight
                };
                MassRecalculationAddingCarbohydrate(addingWeight);
                this.Add(dish);

                if (CheckProteinForOverage())
                {
                    RecalculationProteinToMax();
                }
                if (CheckFatForOverage())
                {
                    RecalculationFatToMax();
                }
            }
        }

        public void AddFatProduct(Product product)
        {
            if (!this.Exists(x => x.Product == product))
            {
                double addingWeight = GetFatAddingWeight();
                Dish dish = new Dish(product, NutrientType.Fat)
                {
                    Fat = addingWeight
                };
                MassRecalculationAddingFat(addingWeight);
                this.Add(dish);

                if (CheckProteinForOverage())
                {
                    RecalculationProteinToMax();
                }
                if (CheckCarbohydrateForOverage())
                {
                    RecalculationCarbohydrateToMax();
                }
            }
        }

        public Dish EditDishWeight(Product product, double newWeight)
        {
            Dish dish = this.Find(x => x.Product == product);
            dish.Weight = newWeight;
            return dish;

        }
        public Dish EditDishWeight(Dish dish, double newWeight)
        {
            Dish result = new Dish();
            if (dish != null)
            {
                Product product = dish.Product;
                result = EditDishWeight(product, newWeight);
            }
            return result;
        }
        public Dish EditDishCarbohydrate(Product product, double newWeight)
        {
            Dish dish = this.Find(x => x.Product == product);
            dish.Carbohydrate = newWeight;
            return dish;
        }

        public Dish EditDishCarbohydrate(Dish dish, double newWeight)
        {
            Dish result = new Dish();
            if (dish != null)
            {
                Product product = dish.Product;
                result = EditDishCarbohydrate(product, newWeight);
            }
            return result;
        }
        public Dish EditDishProtein(Product product, double newWeight)
        {
            Dish dish = this.Find(x => x.Product == product);
            dish.Protein = newWeight;
            return dish;
        }
        public Dish EditDishProtein(Dish dish, double newWeight)
        {
            Dish result = new Dish();
            if (dish != null)
            {
                Product product = dish.Product;
                result = EditDishProtein(product, newWeight);
            }
            return result;
        }
        public Dish EditDishFat(Product product, double newWeight)
        {
            Dish dish = this.Find(x => x.Product == product);
            dish.Fat = newWeight;
            return dish;
        }
        public Dish EditDishFat(Dish dish, double newWeight)
        {
            Dish result = new Dish();
            if (dish != null)
            {
                Product product = dish.Product;
                result = EditDishFat(product, newWeight);
            }
            return result;
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
                // Чтобы не занулить массу всего блюда, пропускаем нутриенты чья масса 0
                if (productProportions[this[i].Product] > 0)
                {
                    this[i].Protein = productProportions[this[i].Product] * prevDishWeight;
                }
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
                // Чтобы не занулить массу всего блюда, пропускаем нутриенты чья масса 0
                if (productProportions[this[i].Product] > 0)
                {
                    this[i].Carbohydrate = productProportions[this[i].Product] * prevDishWeight;
                }
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
                // Чтобы не занулить массу всего блюда, пропускаем нутриенты чья масса 0
                if (productProportions[this[i].Product] > 0)
                {
                    this[i].Fat = productProportions[this[i].Product] * prevDishWeight;
                }
            }
        }

        // Перерасчет белка до максимума
        public void RecalculationProteinToMax()
        {
            Dictionary<Product, double> productProportions = new Dictionary<Product, double>();
            foreach (Dish dish in this)
            {
                productProportions.Add(dish.Product, dish.Protein / CurrentProteinMass);
            }
            for (int i = 0; i<this.Count; i++)
            {
                if (productProportions[this[i].Product] > 0)
                {
                    this[i].Protein = productProportions[this[i].Product] * MaxProtein;
                }
            }
        }

        // Перерасчет углеводов до максимума
        public void RecalculationCarbohydrateToMax()
        {
            Dictionary<Product, double> productProportions = new Dictionary<Product, double>();
            foreach (Dish dish in this)
            {
                productProportions.Add(dish.Product, dish.Carbohydrate / CurrentCarbohydrateMass);
            }
            for (int i = 0; i < this.Count; i++)
            {
                if (productProportions[this[i].Product] > 0)
                {
                    this[i].Carbohydrate = productProportions[this[i].Product] * MaxCarbohydrate;
                }
            }
        }

        // Перерасчет жиров до максимума
        public void RecalculationFatToMax()
        {
            Dictionary<Product, double> productProportions = new Dictionary<Product, double>();
            foreach (Dish dish in this)
            {
                productProportions.Add(dish.Product, dish.Fat / CurrentFatMass);
            }
            for (int i = 0; i < this.Count; i++)
            {
                if (productProportions[this[i].Product] > 0)
                {
                    this[i].Fat = productProportions[this[i].Product] * MaxFat;
                }
            }
        }

        // Проверка на избыток белка
        private bool CheckProteinForOverage()
        {
            return CurrentProteinMass > MaxProtein;
        }

        // Проверка на тзбыток углеводов
        private bool CheckCarbohydrateForOverage()
        {
            return CurrentCarbohydrateMass > MaxCarbohydrate;
        }

        // Проверка на избыток жиров
        private bool CheckFatForOverage()
        {
            return CurrentFatMass > MaxFat;
        }

        private double GetCurrentCalorificMass()
        {
            double result = 0;
            foreach (Dish dish in this)
            {
                result += dish.Calorific;
            }
            return result;
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
