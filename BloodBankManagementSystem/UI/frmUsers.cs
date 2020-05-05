using BloodBankManagementSystem.BLL;
using BloodBankManagementSystem.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BloodBankManagementSystem.UI
{
    public partial class frmUsers : Form
    {
        public frmUsers()
        {
            InitializeComponent();
        }

        //Create Objects of userBLL and userDAL
        userBLL u = new userBLL();
        userDAL dal = new userDAL();

        string imageName = "no-image.jpg";
        string sourcePath = "";
        string destinationPath = "";

        //Global Variabel for the image to delete
        string rowHeaderImage;

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            //Add functionality to close this form
            this.Hide();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //Step 1: Get the Values from UI
            u.full_name = txtFullName.Text;
            u.email = txtEmail.Text;
            u.username = txtUsername.Text;
            u.password = txtPassword.Text;
            u.contact = txtContact.Text;
            u.address = txtAddress.Text;
            u.added_date = DateTime.Now;
            u.image_name = imageName;

            //Upload the image if it is selected
            //check whether the user has selected the image or not
            if(imageName != "no-image.jpg")
            {
                //User has selected the image
                File.Copy(sourcePath, destinationPath);
            }

            //Step2: Adding the Values from UI to the Database
            //Create a Boolean Variable to check whether the data is inserted successfully or not
            bool success = dal.Insert(u);

            //Step 3: Check whether the Data is Inserted Successfully or Not
            if(success==true)
            {
                //Data or User Added Successfully
                MessageBox.Show("New User added Successfully.");

                //Display the user in DataGrid View
                DataTable dt = dal.Select();
                dgvUsers.DataSource = dt;

                //Clear TextBoxes
                Clear();
            }
            else
            {
                //Failed to Add User
                MessageBox.Show("Failed to Add New User.");
            }
        }

        //Method or Function to Clear TextBoxes
        public void Clear()
        {
            txtFullName.Text = "";
            txtEmail.Text = "";
            txtUsername.Text = "";
            txtContact.Text = "";
            txtAddress.Text = "";
            txtPassword.Text = "";
            txtUserID.Text = "";
            //Path to Destination Folder
            //Get the Image path
            string paths = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10));
            string imagePath = paths + "\\images\\no-image.jpg";
            //Diplay in Picture Box
            pictureBoxProfilePicture.Image = new Bitmap(imagePath);
        }

        private void dgvUsers_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //Find the Row Index of the Row Clicked on Users Data Frid View
            int RowIndex = e.RowIndex;
            txtUserID.Text = dgvUsers.Rows[RowIndex].Cells[0].Value.ToString();
            txtUsername.Text = dgvUsers.Rows[RowIndex].Cells[1].Value.ToString();
            txtEmail.Text = dgvUsers.Rows[RowIndex].Cells[2].Value.ToString();
            txtPassword.Text = dgvUsers.Rows[RowIndex].Cells[3].Value.ToString();
            txtFullName.Text = dgvUsers.Rows[RowIndex].Cells[4].Value.ToString();
            txtContact.Text = dgvUsers.Rows[RowIndex].Cells[5].Value.ToString();
            txtAddress.Text = dgvUsers.Rows[RowIndex].Cells[6].Value.ToString();
            imageName = dgvUsers.Rows[RowIndex].Cells[8].Value.ToString();

            //Update the Value of Global Variable rowHeaderImage
            rowHeaderImage = imageName;

            //Display the Image of SElected User
            //Get the Image path
            string paths = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10));

            if(imageName != "no-image.jpg")
            {
                //Path to Destination Folder
                string imagePath = paths + "\\images\\" + imageName;
                //Diplay in Picture Box
                pictureBoxProfilePicture.Image = new Bitmap(imagePath);
            }
            else
            {
                //Path to Destination Folder
                string imagePath = paths + "\\images\\no-image.jpg";
                //Diplay in Picture Box
                pictureBoxProfilePicture.Image = new Bitmap(imagePath);
            }
        }

        private void frmUsers_Load(object sender, EventArgs e)
        {
            //Display the Users in DAtagrid View When the Form is Loaded
            DataTable dt = dal.Select();
            dgvUsers.DataSource = dt;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //Step1: Get the Values from UI
            u.user_id = int.Parse(txtUserID.Text);
            u.full_name = txtFullName.Text;
            u.email = txtEmail.Text;
            u.username = txtUsername.Text;
            u.password = txtPassword.Text;
            u.contact = txtContact.Text;
            u.address = txtAddress.Text;
            u.added_date = DateTime.Now;
            u.image_name = imageName;


            //Upload New Image
            //check whether the user has selected the image or not
            if (imageName != "no-image.jpg")
            {
                //User has selected the image
                File.Copy(sourcePath, destinationPath);
            }

            //Step 2: Create a Boolean variable to check whether the data is updated successfully or not
            bool success = dal.Update(u);

            //Remove the previous Image
            if (rowHeaderImage != "no-image.jpg")
            {
                //Path of the Project Folder
                string paths = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10));
                //Give the Path to the Image Folder
                string imagePath = paths + "\\images\\" + rowHeaderImage;

                //Call Clear Function to clear all the textboxes and Picturebox
                Clear();

                //Call Garbage  Collection Function
                GC.Collect();
                GC.WaitForPendingFinalizers();

                //Delete hte Physical File of the User Profile
                File.Delete(imagePath);
            }


            //Let's check whether the data is updated or not
            if (success==true)
            {
                //Data Udated Successfully
                MessageBox.Show("User Updated Successfully.");

                //Refresh DAta Grid View
                DataTable dt = dal.Select();
                dgvUsers.DataSource = dt;

                //Clear the TextBoxes
                Clear();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //Step 1: Get the UserID from Text Box to Delete the User
            u.user_id = int.Parse(txtUserID.Text);

            //REmove the Physical file of the User Profile

            if(rowHeaderImage != "no-image.jpg")
            {
                //Path of the Project Folder
                string paths = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10));
                //Give the Path to the Image Folder
                string imagePath = paths + "\\images\\" + rowHeaderImage;

                //Call Clear Function to clear all the textboxes and Picturebox
                Clear();

                //Call Garbage  Collection Function
                GC.Collect();
                GC.WaitForPendingFinalizers();

                //Delete hte Physical File of the User Profile
                File.Delete(imagePath);
            }

            //Step Create the Boolean value to check whether the user deleted or not
            bool success = dal.Delete(u);

            //Let's check whteher the user is Deleted or Not
            if(success==true)
            {
                //User Deleted Successfully
                MessageBox.Show("User Deleted Successfully.");

                //Refresh DataGrid View
                DataTable dt = dal.Select();
                dgvUsers.DataSource = dt;

                //Clear the TextBoxes
                Clear();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            //Call the user Function
            Clear();
        }

        private void btnSelectImage_Click(object sender, EventArgs e)
        {
            //Write the Code to Upload the Image of User
            //Open Dialog Box t Select Image
            OpenFileDialog open = new OpenFileDialog();

            //Filter the File Type, Only Allow Image File Types
            open.Filter = "Image Files (*.jpg; *.jpeg; *.png; *.PNG; *.gif;)|*.jpg; *.jpeg; *.png; *.PNG; *.gif;";

            //Check if the file is selected or Not
            if(open.ShowDialog()==DialogResult.OK)
            {
                //Check if the file exists or not
                if(open.CheckFileExists)
                {
                    //DIsplay the Selected File on Picture Box
                    pictureBoxProfilePicture.Image = new Bitmap(open.FileName);

                    //Rename the Image we selected
                    //1. Get the Extension of Image
                    string ext = Path.GetExtension(open.FileName);

                    //2. Generate Random Integer
                    Random random = new Random();
                    int RandInt = random.Next(0, 1000);

                    //3. REname the Image
                    imageName = "Blood_Bank_MS_" + RandInt + ext;

                    //4. Get the path of SElected Image
                    sourcePath = open.FileName;

                    //5. Get the Path of Destination
                    string paths = Application.StartupPath.Substring(0, Application.StartupPath.Length - 10);
                    //Paths to Destination Folder
                    destinationPath = paths + "\\images\\" + imageName;

                    //6. Copy image to the Destination Folder
                    //File.Copy(sourcePath, destinationPath);

                    //7. Display Message
                    //MessageBox.Show("Image Successfully Uploaded.");
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            //Write the Code to Get the users BAsed on Keywords
            //1. Get the Keywords from the TExtBox
            String keywords = txtSearch.Text;

            //Check whether the textbox is empty or not
            if(keywords!=null)
            {
                //TextBox is not empty, display users on DAta Grid View based on the keywords
                DataTable dt = dal.Search(keywords);
                dgvUsers.DataSource = dt;
            }
            else
            {
                //TExtbox is Empty and display all the users on DAta Grid View
                DataTable dt = dal.Select();
                dgvUsers.DataSource = dt;
            }
        }
    }
}
