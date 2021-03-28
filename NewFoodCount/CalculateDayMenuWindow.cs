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
            SetControlsEnabled();

        }

        private void btnAddCarbon_Click(object sender, RoutedEventArgs e)
        {
            UnsubscribeSpinnersEvents();
            Product selProduct = lbCarbons.SelectedItem as Product;
            if (selProduct != null)
            {
                DayDishes.AddCarbohydrateProduct(selProduct);
            }
            UpdateAllSegmentControls();
            dishesList = new ObservableCollection<Dish>(DayDishes);
            lbFoodList.ItemsSource = DishesList;
            lbFoodList.SelectedIndex = lbFoodList.Items.Count - 1;
            SubscribeSpinnersEvents();
        }

        private void btnAddProt_Click(object sender, RoutedEventArgs e)
        {
            UnsubscribeSpinnersEvents();
            Product selProduct = lbProts.SelectedItem as Product;
            if (selProduct != null)
            {
                DayDishes.AddProteinProduct(selProduct);
            }
            UpdateAllSegmentControls();
            dishesList = new ObservableCollection<Dish>(DayDishes);
            lbFoodList.ItemsSource = DishesList;
            lbFoodList.SelectedIndex = lbFoodList.Items.Count - 1;
            SubscribeSpinnersEvents();
        }

        private void btnAddFat_Click(object sender, RoutedEventArgs e)
        {
            UnsubscribeSpinnersEvents();
            Product selProduct = lbFats.SelectedItem as Product;
            if (selProduct != null)
            {
                DayDishes.AddFatProduct(selProduct);
            }
            UpdateAllSegmentControls();
            dishesList = new ObservableCollection<Dish>(DayDishes);
            lbFoodList.ItemsSource = DishesList;
            lbFoodList.SelectedIndex = lbFoodList.Items.Count - 1;
            SubscribeSpinnersEvents();
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
            tbCarbons.Text = CarbohydratesRate.ToString("F", formatter);
            tbProts.Text = ProteinRate.ToString("F", formatter);
            tbFats.Text = FatRate.ToString("F", formatter);
            CalorificSegmentControl.MaxDimension = UserDayCalorific;
            CarbohydrateSegmentControl.MaxDimension = CarbohydratesRate;
            ProteinSegmentControl.MaxDimension = ProteinRate;
            FatSegmentControl.MaxDimension = FatRate;
            SetControlsEnabled();
        }

        private void slProts_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (((Slider)sender).Value >= 1 && textProtPerWeight != null)
            {
                double proteinRatePerWeight = ((Slider)sender).Value;
                CurrentUser.ProteinRatePerWeight = proteinRatePerWeight;
                textProtPerWeight.Text = proteinRatePerWeight.ToString("F", formatter);
                DayDishes.MaxProtein = ProteinRate;
                DayDishes.MaxCarbohydrate = CarbohydratesRate;
                DayDishes.MaxFat = FatRate;
                DayDishes.MaxCalorific = UserDayCalorific;
                tbCarbons.Text = CarbohydratesRate.ToString("F", formatter);
                tbProts.Text = ProteinRate.ToString("F", formatter);
                tbFats.Text = FatRate.ToString("F", formatter);
                tbCalorific.Text = UserDayCalorific.ToString("F", formatter);
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
                intFoodMass.Value = weight;
                intFoodCarbon.Value = carbohydrate;
                intFoodProt.Value = protein;
                intFoodFat.Value = fat;
                tbFoodCal.Text = calorific.ToString("F", formatter);
                tbFoodName.Text = productName;
                rFoodColor.Fill = dish.DishColor;
                SubscribeSpinnersEvents();
            }
            else
            {
                UnsubscribeSpinnersEvents();
                intFoodMass.Text = string.Empty;
                intFoodCarbon.Text = string.Empty;
                intFoodProt.Text = string.Empty;
                intFoodFat.Text = string.Empty;
                tbFoodCal.Text = string.Empty;
                tbFoodName.Text = string.Empty;
                rFoodColor.Fill = Brushes.Transparent;
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
            if (cmbUser.SelectedIndex > -1)
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
            lbCarbons.IsEnabled = value;
            lbProts.IsEnabled = value;
            lbFats.IsEnabled = value;
            btnAddCarbon.IsEnabled = value;
            btnAddProt.IsEnabled = value;
            btnAddFat.IsEnabled = value;
            lbFoodList.IsEnabled = value;
        }

        private void SetFoodControlsEnabledValue(bool value)
        {
            btnDeleteFood.IsEnabled = value;
            intFoodMass.IsEnabled = value;
            intFoodCarbon.IsEnabled = value;
            intFoodProt.IsEnabled = value;
            intFoodFat.IsEnabled = value;
        }

        private void btnDeleteFood_Click(object sender, RoutedEventArgs e)
        {
            Dish selDish = lbFoodList.SelectedItem as Dish;
            if (selDish != null)
            {
                DayDishes.Remove(selDish);
            }
            UpdateAllSegmentControls();
            dishesList = new ObservableCollection<Dish>(DayDishes);
            lbFoodList.ItemsSource = DishesList;
        }

        private void intFoodMass_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            UnsubscribeSpinnersEvents();
            Dish dish = lbFoodList.SelectedItem as Dish;
            if (dish != null)
            {
                double weight = (double)(sender as DoubleUpDown).Value;
                Dish result = DayDishes.EditDishWeight(dish, weight);
                intFoodCarbon.Value = result.Carbohydrate;
                intFoodProt.Value = result.Protein;
                intFoodFat.Value = result.Fat;
            }
            UpdateAllSegmentControls();
            dishesList = new ObservableCollection<Dish>(DayDishes);
            SubscribeSpinnersEvents();
        }

        private void intFoodCarbon_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            UnsubscribeSpinnersEvents();
            Dish dish = lbFoodList.SelectedItem as Dish;
            if (dish != null)
            {
                double weight = (double)(sender as DoubleUpDown).Value;
                Dish result = DayDishes.EditDishCarbohydrate(dish, weight);
                intFoodMass.Value = result.Weight;
                intFoodProt.Value = result.Protein;
                intFoodFat.Value = result.Fat;
            }
            UpdateAllSegmentControls();
            dishesList = new ObservableCollection<Dish>(DayDishes);
            SubscribeSpinnersEvents();
        }

        private void intFoodProt_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            UnsubscribeSpinnersEvents();
            Dish dish = lbFoodList.SelectedItem as Dish;
            if (dish != null)
            {
                double weight = (double)(sender as DoubleUpDown).Value;
                Dish result = DayDishes.EditDishProtein(dish, weight);
                intFoodMass.Value = result.Weight;
                intFoodCarbon.Value = result.Carbohydrate;
                intFoodFat.Value = result.Fat;
            }
            UpdateAllSegmentControls();
            dishesList = new ObservableCollection<Dish>(DayDishes);
            SubscribeSpinnersEvents();
        }

        private void intFoodFat_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            UnsubscribeSpinnersEvents();
            Dish dish = lbFoodList.SelectedItem as Dish;
            if (dish != null)
            {
                double weight = (double)(sender as DoubleUpDown).Value;
                Dish result = DayDishes.EditDishFat(dish, weight);
                intFoodMass.Value = result.Weight;
                intFoodCarbon.Value = result.Carbohydrate;
                intFoodProt.Value = result.Protein;
            }
            UpdateAllSegmentControls();
            dishesList = new ObservableCollection<Dish>(DayDishes);
            SubscribeSpinnersEvents();
        }

        private void UnsubscribeSpinnersEvents()
        {
            intFoodMass.ValueChanged -= intFoodMass_ValueChanged;
            intFoodCarbon.ValueChanged -= intFoodCarbon_ValueChanged;
            intFoodProt.ValueChanged -= intFoodProt_ValueChanged;
            intFoodFat.ValueChanged -= intFoodFat_ValueChanged;
        }
        private void SubscribeSpinnersEvents()
        {
            intFoodMass.ValueChanged += intFoodMass_ValueChanged;
            intFoodCarbon.ValueChanged += intFoodCarbon_ValueChanged;
            intFoodProt.ValueChanged += intFoodProt_ValueChanged;
            intFoodFat.ValueChanged += intFoodFat_ValueChanged;
        }

        private void UpdateTbCalorificCount()
        {
            string currentMass = DayDishes.CurrentCalorificMass.ToString("F", formatter);
            string maxString = DayDishes.MaxCalorific.ToString("F", formatter);
            string text = currentMass + "ккал / " + maxString + "ккал";
            tbCalorificCount.Text = text;
        }

        private void UpdateTbCarbonsCount()
        {
            string currentCarbohydrateMass = DayDishes.CurrentCarbohydrateMass.ToString("F", formatter);
            string maxString = DayDishes.MaxCarbohydrate.ToString("F", formatter);
            string text = currentCarbohydrateMass + "г / " + maxString + "г";
            tbCarbonsCount.Text = text;
        }

        private void UpdateTbProtsCount()
        {
            string currentProteinMass = DayDishes.CurrentProteinMass.ToString("F", formatter);
            string maxString = DayDishes.MaxProtein.ToString("F", formatter);
            string text = currentProteinMass + "г / " + maxString + "г";
            tbProtsCount.Text = text;
        }

        private void UpdateTbFatsCount()
        {
            string currentFatMass = DayDishes.CurrentFatMass.ToString("F", formatter);
            string maxString = DayDishes.MaxFat.ToString("F", formatter);
            string text = currentFatMass + "г / " + maxString + "г";
            tbFatsCount.Text = text;
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
