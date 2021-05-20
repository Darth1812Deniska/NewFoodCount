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
        private User _selectedUser = null;
        private DishCollection _menuDishes = null;
        private readonly DateTime _selectedDate;

        public User SelectedUser
        {
            get { return _selectedUser == null ? _selectedUser = new User() : _selectedUser; }
            set => _selectedUser = value;
        }
        public DishCollection MenuDishes { get => _menuDishes == null ? _menuDishes = new DishCollection() : _menuDishes; }
        public DateTime SelectedDate => _selectedDate;
        public SavingWindow(DishCollection dayDishes, User selectedUser)
        {
            InitializeComponent();
            cmbSelectedUser.ItemsSource = AllUsers.Users;
            _selectedUser = selectedUser;
            cmbSelectedUser.SelectedItem = SelectedUser;
            _menuDishes = dayDishes;
            lstResultList.ItemsSource = MenuDishes;
            dtpMenuDate.SelectedDate = DateTime.Today;
            _selectedDate = dtpMenuDate.SelectedDate.Value;

        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnSavetoFile_Click(object sender, RoutedEventArgs e)
        {
            UserDayMenu userDayMenu = new UserDayMenu(SelectedUser, MenuDishes, SelectedDate);
            AllUserDayMenu.UserDayMenus.Add(userDayMenu);
            try
            {
                AllUserDayMenu.SaveMenus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                MessageBox.Show("Сохранено");
            }
        }
    }
}
