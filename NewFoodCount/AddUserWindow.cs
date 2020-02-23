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
    /// Логика взаимодействия для wndAddUser.xaml
    /// </summary>
    public partial class AddUserWindow : Window
    {
        private string UserName { get; set; }
        private Gender UserGender => GetUserGender();
        private DateTime UserBirthDate { get; set; }
        private int UserHeight { get; set; }
        private double UserWeight { get; set; }
        private UserPurpose UserPurpose { get; set; }
        private int TrainingCount => GetTrainingCount();

        public AddUserWindow()
        {
            InitializeComponent();
        }

        private int GetTrainingCount()
        {
            string stringCount = cmbTrainingNumber.Text;
            return Convert.ToInt32(stringCount);
        }

        private Gender GetUserGender()
        {
            return (rbMale.IsChecked == true) ? Gender.Male : Gender.Female;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            User user = new User(txtName.Text, UserGender, calBirthDay.SelectedDate.Value,
                (int)udHeight.Value, (double)udWeight.Value, (UserPurpose)cmbPurpose.SelectedItem, TrainingCount);
            AllUsers.Users.Add(user);
            Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
