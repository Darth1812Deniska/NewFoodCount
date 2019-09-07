using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewFoodCount
{
    public partial class AddFinishedFood : Form
    {
        private readonly FCP_BD _dB;

        private FCP_BD DB => _dB;

        private string FoodName { get => GetName(); set => SetName(value); }
        private float Protein { get => GetProtein(); set => SetProtein(value); }
        private float Carbohydrate { get => GetCarbohydrate(); set => SetCarbohydrate(value); }
        private float Fat { get => GetFat(); set => SetFat(value); }
        private float Calorific { get => GetCalorific(); set => SetCalorific(value); }

        private string GetName()
        {
            return txtName.Text;
        }

        private void SetName(string value)
        {
            txtName.Text = value;
        }

        private float GetProtein ()
        {
            return (float)numProtein.Value;
        }

        private void SetProtein (float value)
        {
            numProtein.Value = (decimal)value;
        }

        private float GetCarbohydrate()
        {
            return (float)numCarbohydrate.Value;
        }

        private void SetCarbohydrate(float value)
        {
            numCarbohydrate.Value = (decimal)value;
        }

        private float GetFat()
        {
            return (float)numFat.Value;
        }

        private void SetFat(float value)
        {
            numFat.Value = (decimal)value;
        }

        private float GetCalorific()
        {
            return (float)numCalorific.Value;
        }

        private void SetCalorific(float value)
        {
            numCalorific.Value = (decimal)value;
        }

        public AddFinishedFood(FCP_BD db)
        {
            _dB = db;
            InitializeComponent();
            numProtein.Maximum = Int32.MaxValue;
            numCarbohydrate.Maximum = Int32.MaxValue;
            numFat.Maximum = Int32.MaxValue;
            numCalorific.Maximum = Int32.MaxValue;


        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(Name))
            {
                int result = DB.SaveFinishedProduct(FoodName, Protein,Carbohydrate,Fat,Calorific);
            }
            else
            {
                MessageBox.Show("Заполните название");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
