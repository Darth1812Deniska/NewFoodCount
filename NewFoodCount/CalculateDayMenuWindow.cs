using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
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
using Xceed.Wpf.Toolkit;

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
        private readonly IFormatProvider formatter = new NumberFormatInfo { NumberDecimalSeparator = "," };

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
            LbCarbons.ItemsSource = CarbohydrateProducts;
            LbProts.ItemsSource = ProteinProducts;
            LbFats.ItemsSource = FatProducts;
            CmbUser.ItemsSource = Users;
            LbFoodList.ItemsSource = DishesList;
            SlProts.Value = 1;
            calorificSegmentControl = new ProductSegmentControl(NutrientType.Calorific, 0);
            RecCalorific.Children.Add(CalorificSegmentControl);
            carbohydrateSegmentControl = new ProductSegmentControl(NutrientType.Carbohydrate, 0);
            RecCarbons.Children.Add(CarbohydrateSegmentControl);
            proteinSegmentControl = new ProductSegmentControl(NutrientType.Protein, 0);
            RecProts.Children.Add(ProteinSegmentControl);
            fatSegmentControl = new ProductSegmentControl(NutrientType.Fat, 0);
            RecFats.Children.Add(FatSegmentControl);
            SetControlsEnabled();

        }

        private void btnAddCarbon_Click(object sender, RoutedEventArgs e)
        {
            UnsubscribeSpinnersEvents();
            Product selProduct = LbCarbons.SelectedItem as Product;
            if (selProduct != null)
            {
                DayDishes.AddCarbohydrateProduct(selProduct);
            }
            UpdateAllSegmentControls();
            dishesList = new ObservableCollection<Dish>(DayDishes);
            LbFoodList.ItemsSource = DishesList;
            LbFoodList.SelectedIndex = LbFoodList.Items.Count - 1;
            SubscribeSpinnersEvents();
        }

        private void btnAddProt_Click(object sender, RoutedEventArgs e)
        {
            UnsubscribeSpinnersEvents();
            Product selProduct = LbProts.SelectedItem as Product;
            if (selProduct != null)
            {
                DayDishes.AddProteinProduct(selProduct);
            }
            UpdateAllSegmentControls();
            dishesList = new ObservableCollection<Dish>(DayDishes);
            LbFoodList.ItemsSource = DishesList;
            LbFoodList.SelectedIndex = LbFoodList.Items.Count - 1;
            SubscribeSpinnersEvents();
        }

        private void btnAddFat_Click(object sender, RoutedEventArgs e)
        {
            UnsubscribeSpinnersEvents();
            Product selProduct = LbFats.SelectedItem as Product;
            if (selProduct != null)
            {
                DayDishes.AddFatProduct(selProduct);
            }
            UpdateAllSegmentControls();
            dishesList = new ObservableCollection<Dish>(DayDishes);
            LbFoodList.ItemsSource = DishesList;
            LbFoodList.SelectedIndex = LbFoodList.Items.Count - 1;
            SubscribeSpinnersEvents();
        }

        private User GetCurrenUser()
        {
            User user = new User();
            User selUser = CmbUser.SelectedItem as User;
            if (selUser != null)
            {
                user = selUser;
            }
            return user;
        }

        private void cmbUser_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SlProts.Value = CurrentUser.ProteinRatePerWeight;
            DayDishes.MaxProtein = ProteinRate;
            DayDishes.MaxCarbohydrate = CarbohydratesRate;
            DayDishes.MaxFat = FatRate;
            DayDishes.MaxCalorific = UserDayCalorific;
            TbCarbons.Text = CarbohydratesRate.ToString("F", formatter);
            TbProts.Text = ProteinRate.ToString("F", formatter);
            TbFats.Text = FatRate.ToString("F", formatter);
            CalorificSegmentControl.MaxDimension = UserDayCalorific;
            CarbohydrateSegmentControl.MaxDimension = CarbohydratesRate;
            ProteinSegmentControl.MaxDimension = ProteinRate;
            FatSegmentControl.MaxDimension = FatRate;
            SetControlsEnabled();
        }

        private void slProts_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (((Slider)sender).Value >= 1 && TextProtPerWeight != null)
            {
                double proteinRatePerWeight = ((Slider)sender).Value;
                CurrentUser.ProteinRatePerWeight = proteinRatePerWeight;
                TextProtPerWeight.Text = proteinRatePerWeight.ToString("F", formatter);
                DayDishes.MaxProtein = ProteinRate;
                DayDishes.MaxCarbohydrate = CarbohydratesRate;
                DayDishes.MaxFat = FatRate;
                DayDishes.MaxCalorific = UserDayCalorific;
                TbCarbons.Text = CarbohydratesRate.ToString("F", formatter);
                TbProts.Text = ProteinRate.ToString("F", formatter);
                TbFats.Text = FatRate.ToString("F", formatter);
                TbCalorific.Text = UserDayCalorific.ToString("F", formatter);
                if (UserDayCalorific < MinCalorificLimit)
                {
                    TbCalorific.Foreground = Brushes.Green;
                }
                else if ((MinCalorificLimit <= UserDayCalorific) && (UserDayCalorific <= MaxCalorificLimit))
                {
                    TbCalorific.Foreground = Brushes.Black;
                }
                else if (UserDayCalorific > MaxCalorificLimit)
                {
                    TbCalorific.Foreground = Brushes.Red;
                }
            }
        }

        private void lbFoodList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SetFoodControlsEnabledValue(true);
            Dish dish = ((ListBox)sender).SelectedItem as Dish;
            if (dish != null)
            {
                double weight = dish.Weight;
                double calorific = dish.Calorific;
                double carbohydrate = dish.Carbohydrate;
                double protein = dish.Protein;
                double fat = dish.Fat;
                string productName = dish.Product.Name;
                UnsubscribeSpinnersEvents();
                IntFoodMass.Value = weight;
                IntFoodCarbon.Value = carbohydrate;
                IntFoodProt.Value = protein;
                IntFoodFat.Value = fat;
                TbFoodCal.Text = calorific.ToString("F", formatter);
                TbFoodName.Text = productName;
                RFoodColor.Fill = dish.DishColor;
                SubscribeSpinnersEvents();
            }
            else
            {
                UnsubscribeSpinnersEvents();
                IntFoodMass.Text = string.Empty;
                IntFoodCarbon.Text = string.Empty;
                IntFoodProt.Text = string.Empty;
                IntFoodFat.Text = string.Empty;
                TbFoodCal.Text = string.Empty;
                TbFoodName.Text = string.Empty;
                RFoodColor.Fill = Brushes.Transparent;
                SubscribeSpinnersEvents();
            }
            
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
            UpdateAllTbCounts();
        }

        private void SetControlsEnabled()
        {
            if (CmbUser.SelectedIndex > -1)
            {
                SetControlsEnabledTrue();
            }
            else
            {
                SetControlsEnabledFalse();
            }
        }

        private void SetControlsEnabledTrue()
        {
            SetControlsEnabledValue(true);
        }
        private void SetControlsEnabledFalse()
        {
            SetControlsEnabledValue(false);
            SetFoodControlsEnabledValue(false);
        }

        private void SetControlsEnabledValue(bool value)
        {
            LbCarbons.IsEnabled = value;
            LbProts.IsEnabled = value;
            LbFats.IsEnabled = value;
            BtnAddCarbon.IsEnabled = value;
            BtnAddProt.IsEnabled = value;
            BtnAddFat.IsEnabled = value;
            LbFoodList.IsEnabled = value;
        }

        private void SetFoodControlsEnabledValue(bool value)
        {
            BtnDeleteFood.IsEnabled = value;
            IntFoodMass.IsEnabled = value;
            IntFoodCarbon.IsEnabled = value;
            IntFoodProt.IsEnabled = value;
            IntFoodFat.IsEnabled = value;
        }

        private void btnDeleteFood_Click(object sender, RoutedEventArgs e)
        {
            Dish selDish = LbFoodList.SelectedItem as Dish;
            if (selDish != null)
            {
                DayDishes.Remove(selDish);
            }
            UpdateAllSegmentControls();
            dishesList = new ObservableCollection<Dish>(DayDishes);
            LbFoodList.ItemsSource = DishesList;
        }

        private void intFoodMass_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            UnsubscribeSpinnersEvents();
            Dish dish = LbFoodList.SelectedItem as Dish;
            if (dish != null)
            {
                double weight = (double)(sender as DoubleUpDown).Value;
                Dish result = DayDishes.EditDishWeight(dish, weight);
                IntFoodCarbon.Value = result.Carbohydrate;
                IntFoodProt.Value = result.Protein;
                IntFoodFat.Value = result.Fat;
            }
            UpdateAllSegmentControls();
            dishesList = new ObservableCollection<Dish>(DayDishes);
            SubscribeSpinnersEvents();
        }

        private void intFoodCarbon_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            UnsubscribeSpinnersEvents();
            Dish dish = LbFoodList.SelectedItem as Dish;
            if (dish != null)
            {
                double weight = (double)(sender as DoubleUpDown).Value;
                Dish result = DayDishes.EditDishCarbohydrate(dish, weight);
                IntFoodMass.Value = result.Weight;
                IntFoodProt.Value = result.Protein;
                IntFoodFat.Value = result.Fat;
            }
            UpdateAllSegmentControls();
            dishesList = new ObservableCollection<Dish>(DayDishes);
            SubscribeSpinnersEvents();
        }

        private void intFoodProt_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            UnsubscribeSpinnersEvents();
            Dish dish = LbFoodList.SelectedItem as Dish;
            if (dish != null)
            {
                double weight = (double)(sender as DoubleUpDown).Value;
                Dish result = DayDishes.EditDishProtein(dish, weight);
                IntFoodMass.Value = result.Weight;
                IntFoodCarbon.Value = result.Carbohydrate;
                IntFoodFat.Value = result.Fat;
            }
            UpdateAllSegmentControls();
            dishesList = new ObservableCollection<Dish>(DayDishes);
            SubscribeSpinnersEvents();
        }

        private void intFoodFat_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            UnsubscribeSpinnersEvents();
            Dish dish = LbFoodList.SelectedItem as Dish;
            if (dish != null)
            {
                double weight = (double)(sender as DoubleUpDown).Value;
                Dish result = DayDishes.EditDishFat(dish, weight);
                IntFoodMass.Value = result.Weight;
                IntFoodCarbon.Value = result.Carbohydrate;
                IntFoodProt.Value = result.Protein;
            }
            UpdateAllSegmentControls();
            dishesList = new ObservableCollection<Dish>(DayDishes);
            SubscribeSpinnersEvents();
        }

        private void UnsubscribeSpinnersEvents()
        {
            IntFoodMass.ValueChanged -= intFoodMass_ValueChanged;
            IntFoodCarbon.ValueChanged -= intFoodCarbon_ValueChanged;
            IntFoodProt.ValueChanged -= intFoodProt_ValueChanged;
            IntFoodFat.ValueChanged -= intFoodFat_ValueChanged;
        }
        private void SubscribeSpinnersEvents()
        {
            IntFoodMass.ValueChanged += intFoodMass_ValueChanged;
            IntFoodCarbon.ValueChanged += intFoodCarbon_ValueChanged;
            IntFoodProt.ValueChanged += intFoodProt_ValueChanged;
            IntFoodFat.ValueChanged += intFoodFat_ValueChanged;
        }

        private void UpdateTbCalorificCount()
        {
            string currentMass = DayDishes.CurrentCalorificMass.ToString("F", formatter);
            string maxString = DayDishes.MaxCalorific.ToString("F", formatter);
            string text = currentMass + "ккал / " + maxString + "ккал";
            TbCalorificCount.Text = text;
        }

        private void UpdateTbCarbonsCount()
        {
            string currentCarbohydrateMass = DayDishes.CurrentCarbohydrateMass.ToString("F", formatter);
            string maxString = DayDishes.MaxCarbohydrate.ToString("F", formatter);
            string text = currentCarbohydrateMass + "г / " + maxString + "г";
            TbCarbonsCount.Text = text;
        }

        private void UpdateTbProtsCount()
        {
            string currentProteinMass = DayDishes.CurrentProteinMass.ToString("F", formatter);
            string maxString = DayDishes.MaxProtein.ToString("F", formatter);
            string text = currentProteinMass + "г / " + maxString + "г";
            TbProtsCount.Text = text;
        }

        private void UpdateTbFatsCount()
        {
            string currentFatMass = DayDishes.CurrentFatMass.ToString("F", formatter);
            string maxString = DayDishes.MaxFat.ToString("F", formatter);
            string text = currentFatMass + "г / " + maxString + "г";
            TbFatsCount.Text = text;
        }

        private void UpdateAllTbCounts()
        {
            UpdateTbCalorificCount();
            UpdateTbCarbonsCount();
            UpdateTbProtsCount();
            UpdateTbFatsCount();
        }

        private void btnSetCarbonsToMax_Click(object sender, RoutedEventArgs e)
        {
            DayDishes.RecalculationCarbohydrateToMax();
            UpdateAllSegmentControls();
        }

        private void btnSetProtsToMax_Click(object sender, RoutedEventArgs e)
        {
            DayDishes.RecalculationProteinToMax();
            UpdateAllSegmentControls();
        }

        private void btnSetFatsToMax_Click(object sender, RoutedEventArgs e)
        {
            DayDishes.RecalculationFatToMax();
            UpdateAllSegmentControls();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            SavingWindow savingWindow = new SavingWindow(DayDishes, CurrentUser);
            savingWindow.Show();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
