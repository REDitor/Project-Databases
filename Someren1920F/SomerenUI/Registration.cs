using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SomerenModel;
using SomerenLogic;


namespace SomerenUI
{
    public partial class Registration_form : Form
    {
        
        const string LICENSE = "XsZAb - tgz3PsD - qYh69un - WQCEx";
        User_Service user_service = new User_Service();
        public Registration_form()
        {
            InitializeComponent();
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            // check if all text boxes are empty
            if(username_in.Text == "")
            {
                MessageBox.Show("you need to enter a valid username!!");
                return;
            }
            if(Password_in.Text == "")
            {
                MessageBox.Show("you need to enter a password!!");
                return;
            }
            if (txtPassConfirm.Text != Password_in.Text)
            {
                MessageBox.Show("you need to enter matching passwords");
                return;
            }
            if (Verification_key_in.Text != LICENSE)
            {
                MessageBox.Show("you need to enter a valid licence key!!");
                return;
            }

            string passConfirm = txtPassConfirm.Text;
            string license = Verification_key_in.Text;

            User user = new User()
            {
                Username = username_in.Text,
                Password = Password_in.Text,
                roleId = 1
            };

            bool success = user_service.RegisterUser(user);
            if(success)
            {
                DialogResult result = MessageBox.Show("User Registered. Do you wish to log in?\nPress 'Cancel' to exit the application.", "Confirmation", MessageBoxButtons.OKCancel);

                if (result == DialogResult.OK)
                {
                    Close();
                }
                else
                {
                    Application.Exit();
                }
                    
            }
           
        }

        private void Registration_form_Load(object sender, EventArgs e)
        {

        }

        private void Label1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
