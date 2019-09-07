using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewFoodCount
{
    public class DayMenuProduct
    {
        private readonly ProductInfo product;
        private float weight;

        public float Weight { get => weight; set => weight = value; }
        public float Protein { get => GetProtein(); set => SetProtein(value); }
        public float Fat { get => GetFat(); set => SetFat(value); }
        public float Carbohydrate { get => GetCarbohydrate(); set => SetFat(value); }
        public float Calorific { get => GetCalorific();  }

        public ProductInfo Product => product;

        public DayMenuProduct (ProductInfo productInfo, float _weight)
        {
            product = productInfo;
            weight = _weight;
        }

        private void SetProtein(float value)
        {
            weight = value / Product.Protein;
        }
        private float GetProtein()
        {
            float result = weight * Product.Protein;
            return result;
        }
        private void SetFat(float value)
        {
            weight = value / Product.Fat;
        }
        private float GetFat()
        {
            float result = weight * Product.Fat;
            return result;
        }
        private void SetCarbohydrate(float value)
        {
            weight = value / Product.Carbohydrate;
        }
        private float GetCarbohydrate()
        {
            float result = weight * Product.Carbohydrate;
            return result;
        }
        private float GetCalorific()
        {
            float result = weight * Product.Calorific;
            return result;
        }
    }

    public class DayMenuProductList: List<DayMenuProduct>
    {

    }
}
