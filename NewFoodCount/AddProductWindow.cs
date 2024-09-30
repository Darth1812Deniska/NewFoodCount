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

namespace NewFoodCount
{
    /// <summary>
    /// Логика взаимодействия для wndAddFinishedProduct.xaml
    /// </summary>
    public partial class AddProductWindow : Window
    {
        private string ProductName { get => GetProductName(); }
        private double Protein { get => GetProtein(); }
        private double Carbohydrate { get => GetCarbohydrate(); }
        private double Fat { get => GetFat(); }
        private double Calorific { get => GetCalorific(); }
        public AddProductWindow()
        {
            InitializeComponent();
        }
        private string GetProductName()
        {
            return TxtProductName.Text;
        }
        private double GetProtein ()
        {
            double result = 0;
            if (!string.IsNullOrEmpty( UdProtein.Text))
            {
                if (Rb100.IsChecked == true)
                {
                    result = (double)UdProtein.Value / 100;
                }
                else
                {
                    result = (double)UdProtein.Value;
                }
            }
            return result;
        }

        private double GetCarbohydrate()
        {
            double result = 0;
            if (!string.IsNullOrEmpty(UdCarbohydrate.Text))
            {
                if (Rb100.IsChecked == true)
                {
                    result = (double)UdCarbohydrate.Value / 100;
                }
                else
                {
                    result = (double)UdCarbohydrate.Value;
                }
            }
            return result;
        }

        private  double GetFat()
        {
            double result = 0;
            if (!string.IsNullOrEmpty(UdFat.Text))
            {
                if (Rb100.IsChecked == true)
                {
                    result = (double)UdFat.Value / 100;
                }
                else
                {
                    result = (double)UdFat.Value;
                }
            }
            return result;
        }

        private double GetCalorific()
        {
            double result = 0;
            if (!string.IsNullOrEmpty(UdCalorific.Text))
            {
                if (Rb100.IsChecked == true)
                {
                    result = (double)UdCalorific.Value / 100;
                }
                else
                {
                    result = (double)UdCalorific.Value;
                }
            }
            return result;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Product product = new Product(ProductName, Protein, Carbohydrate, Fat, Calorific);
            AllProducts.Products.Add(product);
            Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
