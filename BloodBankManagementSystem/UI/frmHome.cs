using BloodBankManagementSystem.DAL;
using BloodBankManagementSystem.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BloodBankManagementSystem
{
    public partial class frmHome : Form
    {
        public frmHome()
        {
            InitializeComponent();
        }

        //Create the Object of Donor Dal
        donorDAL dal = new donorDAL();

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            //Code to Close this Application
            this.Hide();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Open Users Form
            frmUsers users = new frmUsers();
            users.Show();
        }

        private void donorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Open Manage Donors Form
            frmDonors donors = new frmDonors();
            donors.Show();
        }

        private void frmHome_Load(object sender, EventArgs e)
        {
            //Load all the Blood Donors Count When Form is Loaded
            //Call allDonorCountMethod
            allDonorCount();
        }

        public void allDonorCount()
        {
            //Get the Donor Count from DAtabase and SEt in respective label
            lblOpositiveCount.Text = dal.countDonors("O+");
            lblOnegativeCount.Text = dal.countDonors("O-");
            lblApositiveCount.Text = dal.countDonors("A+");
            lblAnegativeCount.Text = dal.countDonors("A-");
            lblBpositiveCount.Text = dal.countDonors("B+");
            lblBnegativeCount.Text = dal.countDonors("B-");
            lblABpositiveCount.Text = dal.countDonors("AB+");
            lblABnegativeCount.Text = dal.countDonors("AB-");
        }

        private void frmHome_Activated(object sender, EventArgs e)
        {
            //Call allDonorCount Method
            allDonorCount();
        }
    }
}
