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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NewFoodCount
{
    public enum NutrientType
    {
        Protein,
        Carbohydrate,
        Fat,
        Calorific
    }
    /// <summary>
    /// Логика взаимодействия для ProductSegmentControl.xaml
    /// </summary>
    public partial class ProductSegmentControl : UserControl
    {
        private readonly NutrientType _nutrientType;
        private  ObservableCollection<Dish> _dishes;
        private NutrientType NutrientType => _nutrientType;
        public ObservableCollection<Dish> Dishes => _dishes;
        public double MaxDimension { get; set; }


        public ProductSegmentControl(NutrientType nutrientType,  double maxDimension)
        {
            InitializeComponent();
            _nutrientType = nutrientType;
            _dishes = new ObservableCollection<Dish>();
            MaxDimension = maxDimension;
            Dishes.CollectionChanged += Dishes_CollectionChanged;
            
        }

        private void Dishes_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            Redraw();
        }

        private void MainGrid_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            Redraw();
        }

        private void Redraw()
        {
            MainPanel.Children.Clear();
            foreach (Dish dish in Dishes)
            {
                double dimension = 0;
                switch (NutrientType)
                {
                    case NutrientType.Carbohydrate:
                        dimension = dish.Carbohydrate;
                        break;
                    case NutrientType.Protein:
                        dimension = dish.Protein;
                        break;
                    case NutrientType.Fat:
                        dimension = dish.Fat;
                        break;
                    case NutrientType.Calorific:
                        dimension = dish.Calorific;
                        break;
                }
                if (!double.IsNaN(dimension))
                {
                    var width = Math.Round(dimension * this.ActualWidth / MaxDimension);
                    int newRecWidth = Convert.ToInt32(width);
                    Rectangle rectangle = new Rectangle
                    {
                        Width = newRecWidth,
                        Height = this.Height,
                        Fill = dish.DishColor
                    };
                    MainPanel.Children.Add(rectangle);
                }
            }
        }
    }
}
