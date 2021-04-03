using SomerenLogic;
using SomerenModel;
using SomerenUI.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SomerenUI
{
    public partial class LoginForm : Form
    {
        private SomerenUI form;

        public LoginForm()
        {
            InitializeComponent();
        }

        private void DisableButtons()
        {
            
        }

        private void DeterminePermissions(User user)
        {
            if (user.roleId == 2)
            {

            }
        }

        public void LoginForm_Load(object sender, EventArgs e)
        {
            
        }

        private void lnkSignUp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //Suggestion for Taher: Add new form to the SomerenUI. Write code for signing up here and closing the sign up form
            //or MessageBox.Show("User Created Successfully. Do you wish to log in? yes/no thing and
            //if yes -->    LoginForm loginForm = new LoginForm();
            //              loginForm.ShowDialog();
            //if no -->     close loginform(if open after signing up)
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                User_Service userService = new User_Service();
                User user = userService.GetUserByLoginInfo(txtUserName.Text, txtPassword.Text);

                this.Hide();
                form = new SomerenUI();
                form.lblLoggedAs.Text = $"Logged In as: {user.Username}";
                form.lblUserID.Text = $"User ID: {user.UserID}";
                form.Text = $"SomerenApp | {user.Username}";
                form.Closed += (s, args) => this.Close();
                form.Show();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }

        }
    }
}
