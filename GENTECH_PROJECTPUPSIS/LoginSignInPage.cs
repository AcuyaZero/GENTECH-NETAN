using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySqlConnector;

namespace GENTECH_PROJECTPUPSIS
{
    public partial class LoginSignInPage : UserControl
    {
        public LoginSignInPage()
        {
            InitializeComponent();
        }

        private static string connectionString =
            "server=127.0.0.1;port=3306;database=gentechdb_admin;uid=root;pwd=1234;";

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

        // UPDATED: Login using DATABASE instead of hardcoded credentials
        private void hrbSignIn_Click(object sender, EventArgs e)
        {
            string username = txtID.Text;
            string password = txtPassword.Text;

            // Validate input (don't allow placeholder text)
            if (username == "ID" || string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show("Please enter your ID/Email", "Login Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (password == "Password" || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter your password", "Login Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check database for user authentication
            string role = AuthenticateUser(username, password);

            switch (role)
            {
                case "ADMIN":
                    AdminMainForm admin = new AdminMainForm();
                    admin.Show();
                    this.FindForm()?.Hide();
                    break;
                case "FACULTY":
                    FacultyMainForm faculty = new FacultyMainForm();
                    faculty.Show();
                    this.FindForm()?.Hide();
                    break;
                case "STUDENT":
                    StudentMainForm student = new StudentMainForm();
                    student.Show();
                    this.FindForm()?.Hide();
                    break;
                case "ENROLLMENT":
                    EnrollmentMainForm enrollment = new EnrollmentMainForm();
                    enrollment.Show();
                    this.FindForm()?.Hide();
                    break;
                case "ERROR":
                    // Error message already shown in AuthenticateUser
                    break;
                default:
                    MessageBox.Show("Invalid ID/Email or Password", "Login Failed",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }

        // NEW: Authenticate user against database tables
        private string AuthenticateUser(string username, string password)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    // Check ADMIN table (using Email field)
                    if (CheckUserCredentials(conn, "admin", "Email", username, password))
                        return "ADMIN";

                    // Check FACULTY table (using Email field)
                    if (CheckUserCredentials(conn, "faculty", "Email", username, password))
                        return "FACULTY";

                    // Check STUDENT table (using Email field)
                    if (CheckUserCredentials(conn, "student", "Email", username, password))
                        return "STUDENT";

                    // Check ENROLLMENT table (using Email field)
                    // Note: Change 'enrollment_staff' to your actual enrollment table name
                    if (CheckUserCredentials(conn, "enrollment_staff", "Email", username, password))
                        return "ENROLLMENT";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database connection error: " + ex.Message,
                    "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "ERROR";
            }

            return "NONE";
        }

        // NEW: Helper method to check credentials in a specific table
        private bool CheckUserCredentials(MySqlConnection conn, string tableName, string usernameField, string username, string password)
        {
            string query = $"SELECT COUNT(*) FROM {tableName} WHERE {usernameField} = @username AND Password = @password";

            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);

                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
        }

        // UPDATED: Forgot Password using DATABASE
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string input = Interaction.InputBox("Enter your email address:", "Forgot Password", "");

            if (string.IsNullOrWhiteSpace(input))
            {
                return; // user cancelled or provided nothing
            }

            string email = input.Trim();

            // Check if email exists in any user table
            if (EmailExistsInDatabase(email))
            {
                // In a real application, you would send an email with password reset link
                // For now, just show a success message
                MessageBox.Show($"Password reset link has been sent to {email}\n\n" +
                    "(Note: In production, an actual email would be sent. " +
                    "Please contact your system administrator for password reset.)",
                    "Forgot Password", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Email address does not exist in our system, please try again!",
                    "Forgot Password", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // NEW: Check if email exists in any user table
        private bool EmailExistsInDatabase(string email)
        {
            string query = @"
                SELECT COUNT(*) FROM (
                    SELECT Email FROM admin WHERE Email = @email
                    UNION ALL
                    SELECT Email FROM faculty WHERE Email = @email
                    UNION ALL
                    SELECT Email FROM student WHERE Email = @email
                    UNION ALL
                    SELECT Email FROM enrollment_staff WHERE Email = @email
                ) AS combined";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@email", email);
                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error: " + ex.Message);
                return false;
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

        private void OpenUrl(string url)
        {
            if (!Uri.TryCreate(url, UriKind.Absolute, out _)) return;

            try
            {
                Process.Start(url); // works on .NET Framework 4.8
            }
            catch
            {
                // Robust fallback
                Process.Start(new ProcessStartInfo { FileName = url, UseShellExecute = true });
            }
        }

        private void roundedButton1_Click(object sender, EventArgs e)
        {
            OpenUrl("https://www.facebook.com/pupsmbofficial");
        }

        private void roundedButton4_Click(object sender, EventArgs e)
        {
            OpenUrl("https://www.facebook.com/HMSocietyPUPSMB");
        }

        private void roundedButton3_Click(object sender, EventArgs e)
        {
            OpenUrl("https://www.facebook.com/pupsmb.isite");
        }

        private void roundedButton2_Click(object sender, EventArgs e)
        {
            OpenUrl("https://www.facebook.com/acespupsmb");
        }

        private void roundedButton5_Click(object sender, EventArgs e)
        {
            OpenUrl("https://www.facebook.com/pupsmbiskolarium");
        }
    }
}