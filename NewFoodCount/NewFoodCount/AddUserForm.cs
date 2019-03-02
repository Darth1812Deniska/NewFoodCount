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
    public enum Gender { Male = 0, Female = 1}
    public enum Purpose { WeightLoss = 1, WeightRetention, WeightGain, Drying }



    public partial class AddUserForm : Form
    {
        private readonly FCP_BD _fCP_BD;

        private FCP_BD FCP_BD => _fCP_BD;
        public AddUserForm(FCP_BD _BD)
        {
            InitializeComponent();
            _fCP_BD = _BD;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string name = txtUserName.Text;
            int gender = cmbGender.SelectedIndex;
            DateTime birthDay = mcBirthDate.SelectionStart;
            float height = Convert.ToSingle( txtGrowth.Text);
            float weight = Convert.ToSingle(txtWeight.Text);
            int userPurposeID = cmbUserPurpose.SelectedIndex + 1;
            int trainingCount = Convert.ToInt32(cmbTrainingCount.Text);

            int result = FCP_BD.SaveUser(name,gender,birthDay,
                height,weight,userPurposeID,trainingCount);
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
