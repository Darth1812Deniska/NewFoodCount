using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewFoodCount
{
    public class ProductInfo
    {
        private readonly string productName;
        private readonly float protein;
        private readonly float fat;
        private readonly float carbohydrate;
        private readonly int baseID;
        private readonly float calorific;

        public string ProductName => productName;
        public int BaseID => baseID;
        public float Protein => protein;
        public float Fat => fat;
        public float Carbohydrate => carbohydrate;
        public float Calorific => calorific;
        public ProductInfo(int _baseID, string _productName,
            float _protein, float _fat, float _carbohydrate, float _calorific)
        {
            baseID = _baseID;
            productName = _productName;
            protein = _protein;
            fat = _fat;
            carbohydrate = _carbohydrate;
            calorific = _calorific;
        }
    }
}
