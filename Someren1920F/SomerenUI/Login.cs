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
        private Registration_form registration_Form;
        private SomerenUI form;
        private User_Service userService;
        public User user;

        public LoginForm()
        {
            InitializeComponent();
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

            registration_Form = new Registration_form();
            registration_Form.ShowDialog();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                userService = new User_Service();
                form = new SomerenUI();

                if (userService.UserExists(txtUserName.Text, txtPassword.Text))
                {
                    user = userService.GetUserByUserName(txtUserName.Text);
                    this.Hide();
                }
                form.formUser = user;
                form.SetUIDetailsAndPermissions();
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
