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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NewFoodCount
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            AllUsers.LoadUsers();
            AllProducts.Load();
            AllUserDayMenu.LoadMenus();
        }

        private void btnAddUser_Click(object sender, RoutedEventArgs e)
        {
            AddUserWindow addUser = new AddUserWindow();
            addUser.ShowDialog();
        }

        private void wndMain_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            AllUsers.SaveUsers();
            AllProducts.Save();
            AllUserDayMenu.SaveMenus();
        }

        private void btnAddProduct_Click(object sender, RoutedEventArgs e)
        {
            AddProductWindow addProduct = new AddProductWindow();
            addProduct.ShowDialog();
        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            CalculateDayMenuWindow window = new CalculateDayMenuWindow();
            window.ShowDialog();
        }
    }
}
