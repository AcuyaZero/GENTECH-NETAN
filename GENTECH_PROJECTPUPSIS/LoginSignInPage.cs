using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GENTECH_PROJECTPUPSIS
{
    public partial class LoginSignInPage : UserControl
    {
        public LoginSignInPage()
        {
            InitializeComponent();
        }

        private void txtID_Enter(object sender, EventArgs e)
        {

            if (txtID.Text == "ID")
            {
                txtID.Text = "";
                txtID.ForeColor = Color.Black;
            }

        }

        private void txtID_Leave(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtID.Text))
            {
                txtID.Text = "ID";
                txtID.ForeColor = Color.Gray;
            }

        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {

            if (txtPassword.Text == "Password")
            {
                txtPassword.Text = "";
                txtPassword.ForeColor = Color.Black;
                txtPassword.UseSystemPasswordChar = true;
            }

        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (txtPassword.Text == "")
            {
                txtPassword.Text = "Password";
                txtPassword.ForeColor = Color.Gray;
                txtPassword.UseSystemPasswordChar = false;
            }
        }

        // for login base sa role
        private void hrbSignIn_Click(object sender, EventArgs e)
        {
            string username = txtID.Text;
            string password = txtPassword.Text;

            // ADMIN
            if (username == "admin" && password == "123")
            {
                AdminMainForm admin = new AdminMainForm();
                admin.Show();
                this.Hide();
            }
            // FACULTY
            else if (username == "faculty" && password == "123")
            {
                FacultyMainForm faculty = new FacultyMainForm();
                faculty.Show();
                this.Hide();
            }
            // STUDENT
            else if (username == "student" && password == "123")
            {
                StudentMainForm student = new StudentMainForm();
                student.Show();
                this.Hide();
            }
            // ENROLLMENT
            else if (username == "enrollment" && password == "123")
            {
                EnrollmentMainForm student = new EnrollmentMainForm();
                student.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid Username or Password", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnShowPass_Click_1(object sender, EventArgs e)
        {

            if (txtPassword.UseSystemPasswordChar)
            {
                txtPassword.UseSystemPasswordChar = false;
                btnShowPass.Text = "Hide Password";
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
                btnShowPass.Text = "Show Password";
            }

        }
    }
}
