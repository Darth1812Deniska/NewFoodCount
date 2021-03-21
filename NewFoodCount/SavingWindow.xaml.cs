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
    /// Логика взаимодействия для SavingWindow.xaml
    /// </summary>
    public partial class SavingWindow : Window
    {
        public SavingWindow(DishCollection dayDishes)
        {
            InitializeComponent();
            lstResultList.ItemsSource = dayDishes;

        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
