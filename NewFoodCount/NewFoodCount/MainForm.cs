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
    public partial class MainForm : Form
    {
        private readonly FCP_BD _fCP_BD;

        private FCP_BD FCP_BD => _fCP_BD;
        public MainForm()
        {
            InitializeComponent();
            _fCP_BD = new FCP_BD("DSERVPC", "FCP", "sa", "sql");

        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            AddUserForm userForm = new AddUserForm(FCP_BD);
            userForm.ShowDialog();
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            AddFinishedFood finishedFood = new AddFinishedFood(FCP_BD);
            finishedFood.ShowDialog();
        }
    }
}
