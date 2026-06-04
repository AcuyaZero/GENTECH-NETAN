using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace GENTECH_PROJECTPUPSIS
{
    public partial class EnrollmentHome : UserControl
    {
        public EnrollmentHome()
        {
            InitializeComponent();
        }

        private void lblDownload_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();

            save.Filter = "PNG Image|*.png";
            save.Title = "Save Image";
            save.FileName = "COR.png";

            if (save.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image.Save(save.FileName,
                System.Drawing.Imaging.ImageFormat.Png);

                MessageBox.Show(
                 "Image saved successfully!",
                 "Success",
                 MessageBoxButtons.OK,
                 MessageBoxIcon.Information
             );
            }
        }

        private void EnrollmentHome_Load(object sender, EventArgs e)
        {
            DummiesBasicToKungfu("Comp 001", "Object-Oriented Programming", 3);
            DummiesBasicToKungfu("Comp 002", "Data Structures and Algorithms", 3);
            DummiesBasicToKungfu("Comp 003", "Database Management Systems", 3);
            DummiesBasicToKungfu("Comp 004", "Web Development", 3);
            DummiesBasicToKungfu("Comp 005", "Computer Networks", 3);
            DummiesBasicToKungfu("Comp 006", "Software Engineering", 3);
            DummiesBasicToKungfu("Comp 007", "Operating Systems", 3);
            DummiesBasicToKungfu("Comp 008", "Human-Computer Interaction", 2);
        }

        private void DummiesBasicToKungfu(string code, string description, int unit)
        {
            int index = dvgEnrolled.Rows.Add();
            DataGridViewRow row = dvgEnrolled.Rows[index];

            row.Cells[0].Value = code;
            row.Cells[1].Value = description;
            row.Cells[2].Value = unit;
        }

        private void btnEnrollNow_Click(object sender, EventArgs e)
        {
            EnrollmentMainForm main = (EnrollmentMainForm)this.FindForm();
            main.LoadControl(new EnrollmentConfirmation());
        }
        
    }
}
