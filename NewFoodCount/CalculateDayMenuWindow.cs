using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для wndCalculateDayMenu.xaml
    /// </summary>
    public partial class CalculateDayMenuWindow : Window
    {
        private DishCollection dayDishes;
        private ObservableCollection<Dish> dishesList;
        private readonly ProductSegmentControl calorificSegmentControl;
        private readonly ProductSegmentControl carbohydrateSegmentControl;
        private readonly ProductSegmentControl proteinSegmentControl;
        private readonly ProductSegmentControl fatSegmentControl;

        private List<Product> CarbohydrateProducts => AllProducts.GetCarbohydrateProducts();
        private List<Product> ProteinProducts => AllProducts.GetProteinProducts();
        private List<Product> FatProducts => AllProducts.GetFatProducts();
        private List<User> Users => AllUsers.Users;
        private DishCollection DayDishes { get => dayDishes; set => dayDishes = value; }
        private ObservableCollection<Dish> DishesList => dishesList;
        private User CurrentUser { get => GetCurrenUser(); }
        private double CarbohydratesRate { get => CurrentUser.CarbohydratesRate; }
        private double ProteinRate { get => CurrentUser.ProteinRate; }
        private double FatRate { get => CurrentUser.FatRate; }
        private double UserDayCalorific { get => CurrentUser.UserDayCalorific; }
        private double MinCalorificLimit { get => CurrentUser.MinCalorificLimit; }
        private double MaxCalorificLimit { get => CurrentUser.MaxCalorificLimit; }
        private ProductSegmentControl CalorificSegmentControl => calorificSegmentControl;
        private ProductSegmentControl CarbohydrateSegmentControl => carbohydrateSegmentControl;
        private ProductSegmentControl ProteinSegmentControl => proteinSegmentControl;
        private ProductSegmentControl FatSegmentControl => fatSegmentControl; 
        public CalculateDayMenuWindow()
        {
            InitializeComponent();
            dayDishes = new DishCollection();
            lbCarbons.ItemsSource = CarbohydrateProducts;
            lbProts.ItemsSource = ProteinProducts;
            lbFats.ItemsSource = FatProducts;
            cmbUser.ItemsSource = Users;
            lbFoodList.ItemsSource = DishesList;
            slProts.Value = 1;
            calorificSegmentControl = new ProductSegmentControl(NutrientType.Calorific, 0);
            recCalorific.Children.Add(CalorificSegmentControl);
            carbohydrateSegmentControl = new ProductSegmentControl(NutrientType.Carbohydrate, 0);
            recCarbons.Children.Add(CarbohydrateSegmentControl);
            proteinSegmentControl = new ProductSegmentControl(NutrientType.Protein, 0);
            recProts.Children.Add(ProteinSegmentControl);
            fatSegmentControl = new ProductSegmentControl(NutrientType.Fat, 0);
            recFats.Children.Add(FatSegmentControl);

        }

        private void btnAddCarbon_Click(object sender, RoutedEventArgs e)
        {
            Product selProduct = lbCarbons.SelectedItem as Product;
            if (selProduct != null)
            {
                DayDishes.AddCarbohydrateProduct(selProduct);
            }
            UpdateAllSegmentControls();
            dishesList = new ObservableCollection<Dish>(DayDishes);
            lbFoodList.ItemsSource = DishesList;
            lbFoodList.SelectedIndex = lbFoodList.Items.Count - 1;
        }

        private void btnAddProt_Click(object sender, RoutedEventArgs e)
        {
            Product selProduct = lbProts.SelectedItem as Product;
            if (selProduct != null)
            {
                DayDishes.AddProteinProduct(selProduct);
            }
            UpdateAllSegmentControls();
            dishesList = new ObservableCollection<Dish>(DayDishes);
            lbFoodList.ItemsSource = DishesList;
            lbFoodList.SelectedIndex = lbFoodList.Items.Count - 1;
        }

        private void btnAddFat_Click(object sender, RoutedEventArgs e)
        {
            Product selProduct = lbFats.SelectedItem as Product;
            if (selProduct != null)
            {
                DayDishes.AddFatProduct(selProduct);
            }
            UpdateAllSegmentControls();
            dishesList = new ObservableCollection<Dish>(DayDishes);
            lbFoodList.ItemsSource = DishesList;
            lbFoodList.SelectedIndex = lbFoodList.Items.Count - 1;
        }

        private User GetCurrenUser()
        {
            User user = new User();
            User selUser = cmbUser.SelectedItem as User;
            if (selUser != null)
            {
                user = selUser;
            }
            return user;
        }

        private void cmbUser_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            slProts.Value = CurrentUser.ProteinRatePerWeight;
            DayDishes.MaxProtein = ProteinRate;
            DayDishes.MaxCarbohydrate = CarbohydratesRate;
            DayDishes.MaxFat = FatRate;
            DayDishes.MaxCalorific = UserDayCalorific;
            tbCarbons.Text = CarbohydratesRate.ToString("F");
            tbProts.Text = ProteinRate.ToString("F");
            tbFats.Text = FatRate.ToString("F");
            CalorificSegmentControl.MaxDimension = UserDayCalorific;
            CarbohydrateSegmentControl.MaxDimension = CarbohydratesRate;
            ProteinSegmentControl.MaxDimension = ProteinRate;
            FatSegmentControl.MaxDimension = FatRate;
        }

        private void slProts_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (((Slider)sender).Value >= 1 && textProtPerWeight != null)
            {
                double proteinRatePerWeight = ((Slider)sender).Value;
                CurrentUser.ProteinRatePerWeight = proteinRatePerWeight;
                textProtPerWeight.Text = proteinRatePerWeight.ToString("F");
                DayDishes.MaxProtein = ProteinRate;
                DayDishes.MaxCarbohydrate = CarbohydratesRate;
                DayDishes.MaxFat = FatRate;
                DayDishes.MaxCalorific = UserDayCalorific;
                tbCarbons.Text = CarbohydratesRate.ToString("F");
                tbProts.Text = ProteinRate.ToString("F");
                tbFats.Text = FatRate.ToString("F");
                tbCalorific.Text = UserDayCalorific.ToString("F");
                if (UserDayCalorific < MinCalorificLimit)
                {
                    tbCalorific.Foreground = Brushes.Green;
                }
                else if ((MinCalorificLimit <= UserDayCalorific) && (UserDayCalorific <= MaxCalorificLimit))
                {
                    tbCalorific.Foreground = Brushes.Black;
                }
                else if (UserDayCalorific > MaxCalorificLimit)
                {
                    tbCalorific.Foreground = Brushes.Red;
                }
            }
        }

        private void lbFoodList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Dish dish = ((ListBox)sender).SelectedItem as Dish;
            double weight = dish.Weight;
            double calorific = dish.Calorific;
            double carbohydrate = dish.Carbohydrate;
            double protein = dish.Protein;
            double fat = dish.Fat;
            string productName = dish.Product.Name;

            intFoodMass.Value = weight;
            intFoodCarbon.Value = carbohydrate;
            intFoodProt.Value = protein;
            intFoodFat.Value = fat;
            tbFoodCal.Text = calorific.ToString("F");
            tbFoodName.Text = productName;
        }

        private void UpdateCalorificSegmentCollection()
        {
            CalorificSegmentControl.Dishes.Clear();
            foreach (Dish dish in DayDishes)
            {
                CalorificSegmentControl.Dishes.Add(dish);
            }
        }

        private void UpdateCarbohydrateSegmentCollection()
        {
            CarbohydrateSegmentControl.Dishes.Clear();
            foreach (Dish dish in DayDishes)
            {
                CarbohydrateSegmentControl.Dishes.Add(dish);
            }
        }

        private void UpdateProteinSegmentCollection()
        {
            ProteinSegmentControl.Dishes.Clear();
            foreach (Dish dish in DayDishes)
            {
                ProteinSegmentControl.Dishes.Add(dish);
            }
        }

        private void UpdateFatSegmentCollection()
        {
            FatSegmentControl.Dishes.Clear();
            foreach (Dish dish in DayDishes)
            {
                FatSegmentControl.Dishes.Add(dish);
            }
        }

        private void UpdateAllSegmentControls()
        {
            UpdateCalorificSegmentCollection();
            UpdateCarbohydrateSegmentCollection();
            UpdateProteinSegmentCollection();
            UpdateFatSegmentCollection();
        }
    }
}
