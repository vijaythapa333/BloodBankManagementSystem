using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BloodBankManagementSystem.UI
{
    public partial class frmDonors : Form
    {
        public frmDonors()
        {
            InitializeComponent();
        }

        private void frmDonors_Load(object sender, EventArgs e)
        {

        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            //Close this form
            this.Hide();
        }
    }
}
