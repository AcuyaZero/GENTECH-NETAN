using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
<<<<<<< HEAD
using static System.Net.Mime.MediaTypeNames;
=======
using MySqlConnector;
>>>>>>> a83721eeed923229ae7731dc76476239a0cb8541

namespace GENTECH_PROJECTPUPSIS
{
    public partial class AdminModifyEnrollment : UserControl
    {
        public AdminModifyEnrollment()
        {
            InitializeComponent();

<<<<<<< HEAD



        }

        private void DummyAdd(string code, string description, string schedule)
        {

        }
        private void SetupDataGridView()
        {
            dvgModifyEnrollment.Columns.Clear();

            // =========================================
            // DESIGN
            // =========================================
            dvgModifyEnrollment.AllowUserToAddRows = false;
            dvgModifyEnrollment.RowHeadersVisible = false;
            dvgModifyEnrollment.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dvgModifyEnrollment.MultiSelect = false;
            dvgModifyEnrollment.RowTemplate.Height = 38;
            dvgModifyEnrollment.BorderStyle = BorderStyle.None;
            dvgModifyEnrollment.BackgroundColor = Color.White;
            dvgModifyEnrollment.GridColor = Color.Gainsboro;

            // =========================================
            // HEADER STYLE
            // =========================================
            dvgModifyEnrollment.EnableHeadersVisualStyles = false;
            dvgModifyEnrollment.ColumnHeadersHeight = 42;
            dvgModifyEnrollment.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            dvgModifyEnrollment.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkRed;
            dvgModifyEnrollment.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dvgModifyEnrollment.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 10, FontStyle.Bold);

            // =========================================
            // CELL STYLE
            // =========================================
            dvgModifyEnrollment.DefaultCellStyle.Font =
                new Font("Segoe UI", 10);

            dvgModifyEnrollment.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(240, 240, 240);

            dvgModifyEnrollment.DefaultCellStyle.SelectionForeColor =
                Color.Black;

            // =========================================
            // CHECKBOX COLUMN
            // =========================================
            DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
            chk.HeaderText = "";
            chk.Width = 50;

            // =========================================
            // SUBJECT CODE
            // =========================================
            DataGridViewTextBoxColumn code = new DataGridViewTextBoxColumn();
            code.HeaderText = "Subject Code";
            code.Width = 160;

            // =========================================
            // DESCRIPTION
            // =========================================
            DataGridViewTextBoxColumn desc = new DataGridViewTextBoxColumn();
            desc.HeaderText = "Description";
            desc.Width = 280;

            // =========================================
            // UNITS
            // =========================================
            DataGridViewTextBoxColumn units = new DataGridViewTextBoxColumn();
            units.HeaderText = "Units";
            units.Width = 80;

            // =========================================
            // CLEANER COMBOBOX COLUMN
            // =========================================
            DataGridViewComboBoxColumn sched = new DataGridViewComboBoxColumn();

            sched.HeaderText = "Schedules";
            sched.Width = 260;
            sched.FlatStyle = FlatStyle.Flat;

            // Cleaner schedule options
            sched.Items.Add("MWF • 8:00 AM - 9:00 AM");
            sched.Items.Add("TTH • 1:00 PM - 2:30 PM");

            // =========================================
            // ADD COLUMNS
            // =========================================
            dvgModifyEnrollment.Columns.Add(chk);
            dvgModifyEnrollment.Columns.Add(code);
            dvgModifyEnrollment.Columns.Add(desc);
            dvgModifyEnrollment.Columns.Add(units);
            dvgModifyEnrollment.Columns.Add(sched);
        }

        private void LoadSubjects()
        {
            dvgModifyEnrollment.Rows.Add(false, "IT101", "Introduction to Computing", 3, "MWF • 8:00 AM - 9:00 AM");

            dvgModifyEnrollment.Rows.Add(false, "CS102", "Programming 1", 3, "TTH • 1:00 PM - 2:30 PM");

            dvgModifyEnrollment.Rows.Add(false, "MATH101", "College Algebra", 3, "MWF • 8:00 AM - 9:00 AM");

            dvgModifyEnrollment.Rows.Add(false, "ENG101", "Purposive Communication", 3, "TTH • 1:00 PM - 2:30 PM");

            dvgModifyEnrollment.Rows.Add(false, "NSTP101", "National Service Training Program", 3, "MWF • 8:00 AM - 9:00 AM");

            dvgModifyEnrollment.Rows.Add(false, "PE101", "Physical Fitness", 2, "TTH • 1:00 PM - 2:30 PM");

            dvgModifyEnrollment.Rows.Add(false, "HIST101", "Readings in Philippine History", 3, "MWF • 8:00 AM - 9:00 AM");

            dvgModifyEnrollment.Rows.Add(false, "SCI101", "General Biology", 3, "TTH • 1:00 PM - 2:30 PM");
        }

        private void TextBox_Enter(object sender, EventArgs e)
        {
            var txt = sender as ComponentFactory.Krypton.Toolkit.KryptonTextBox;
            if (txt.Text == "Student ID")
            {
                txt.Text = "";
                txt.StateCommon.Content.Color1 = Color.Black;
            }
        }

        private void TextBox_Leave(object sender, EventArgs e)
        {
            var txt = sender as ComponentFactory.Krypton.Toolkit.KryptonTextBox;

            string noSpace = txt.Text.Replace(" ", "");

            if (noSpace == "")
            {
                txt.Text = txt.Tag.ToString();
                txt.StateCommon.Content.Color1 = Color.DarkGray;
            }
        }

        private void kryptonDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtStudentID.Text == "2024-00136-SM-0")
            {
                dvgModifyEnrollment.Rows.Clear();
                SetupDataGridView();
                LoadSubjects();
                lblName.Visible = true;
                lblProgram.Visible = true;
                lblSection.Visible = true;
                lblStudentID.Visible = true;

                btnClear.Enabled = true;
                btnClear.PrimaryColor = Color.Maroon;

                lblStatus.Text = "Regular";
                lblUnitsOverload.Text = "0";
                lblUnitsEnrolled.Text = "23";
                lblUnitsAllowed.Text = "23";

                btnAddSubjects.Enabled = true;
                btnDropSubjects.Enabled = true;
                btnAddSubjects.PrimaryColor = Color.Maroon;
                btnDropSubjects.PrimaryColor = Color.Maroon;

                btnSaveChanges.Enabled = true;
                btnSaveChanges.PrimaryColor = Color.Maroon;

            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            dvgModifyEnrollment.Rows.Clear();
            lblName.Visible = false;
            lblProgram.Visible = false;
            lblSection.Visible = false;
            lblStudentID.Visible = false;

            btnClear.Enabled = false;
            btnClear.PrimaryColor = Color.FromArgb(32, 34, 37);

            lblStatus.Text = "--";
            lblUnitsOverload.Text = "--";
            lblUnitsEnrolled.Text = "--";
            lblUnitsAllowed.Text = "--";

            btnAddSubjects.Enabled = false;
            btnDropSubjects.Enabled = false;
            btnAddSubjects.PrimaryColor = Color.FromArgb(32, 34, 37);
            btnDropSubjects.PrimaryColor = Color.FromArgb(32, 34, 37);

            txtStudentID.Text = txtStudentID.Tag.ToString();
            txtStudentID.StateCommon.Content.Color1 = Color.DarkGray;

            btnSaveChanges.Enabled = false;
            btnSaveChanges.PrimaryColor = Color.FromArgb(32, 34, 37);
        }

        private void btnDropSubjects_Click(object sender, EventArgs e)
        {

            for (int i = dvgModifyEnrollment.Rows.Count - 1; i >= 0; i--)
            {
                DataGridViewRow row = dvgModifyEnrollment.Rows[i];

                if (row.Cells[0].Value != null &&
                    (bool)row.Cells[0].Value == true)
                {
                    dvgModifyEnrollment.Rows.RemoveAt(i);
                }
            }
        }

        private void btnAddSubjects_Click(object sender, EventArgs e)
        {
            // Create selection form
            Form pickForm = new Form();
            pickForm.Text = "Select Subject";
            pickForm.Size = new Size(400, 300);
            pickForm.StartPosition = FormStartPosition.CenterScreen;

            // ListBox
            ListBox listSubjects = new ListBox();
            listSubjects.Dock = DockStyle.Top;
            listSubjects.Height = 180;
            listSubjects.Font = new Font("Segoe UI", 10);

            // Subjects
            listSubjects.Items.Add("IT201 - Data Structures");
            listSubjects.Items.Add("CS202 - Algorithms");
            listSubjects.Items.Add("WEB101 - Web Development");
            listSubjects.Items.Add("DB101 - Database Management");
            listSubjects.Items.Add("NET101 - Networking");
            listSubjects.Items.Add("OOP101 - Object-Oriented Programming");
            listSubjects.Items.Add("MOB101 - Mobile Development");
            listSubjects.Items.Add("AI101 - Introduction to AI");

            // Add Button
            Button btnAdd = new Button();
            btnAdd.Text = "Add Subject";
            btnAdd.Dock = DockStyle.Bottom;
            btnAdd.Height = 40;

            btnAdd.Click += (s, ev) =>
            {
                if (listSubjects.SelectedItem != null)
                {
                    string selected = listSubjects.SelectedItem.ToString();

                    // Add selected subject
                    switch (selected)
                    {
                        case "IT201 - Data Structures":
                            dvgModifyEnrollment.Rows.Add(false, "IT201", "Data Structures", 3, "MWF • 8:00 AM - 9:00 AM");
                            break;

                        case "CS202 - Algorithms":
                            dvgModifyEnrollment.Rows.Add(false, "CS202", "Algorithms", 3, "TTH • 1:00 PM - 2:30 PM");
                            break;

                        case "WEB101 - Web Development":
                            dvgModifyEnrollment.Rows.Add(false, "WEB101", "Web Development", 3, "MWF • 8:00 AM - 9:00 AM");
                            break;

                        case "DB101 - Database Management":
                            dvgModifyEnrollment.Rows.Add(false, "DB101", "Database Management", 3, "TTH • 1:00 PM - 2:30 PM");
                            break;

                        case "NET101 - Networking":
                            dvgModifyEnrollment.Rows.Add(false, "NET101", "Networking", 3, "MWF • 8:00 AM - 9:00 AM");
                            break;

                        case "OOP101 - Object-Oriented Programming":
                            dvgModifyEnrollment.Rows.Add(false, "OOP101", "Object-Oriented Programming", 3, "TTH • 1:00 PM - 2:30 PM");
                            break;

                        case "MOB101 - Mobile Development":
                            dvgModifyEnrollment.Rows.Add(false, "MOB101", "Mobile Development", 3, "MWF • 8:00 AM - 9:00 AM");
                            break;

                        case "AI101 - Introduction to AI":
                            dvgModifyEnrollment.Rows.Add(false, "AI101", "Introduction to AI", 3, "TTH • 1:00 PM - 2:30 PM");
                            break;
                    }

                    pickForm.Close();
                }
                else
                {
                    MessageBox.Show("Please select a subject.");
                }
            };

            // Add controls
            pickForm.Controls.Add(listSubjects);
            pickForm.Controls.Add(btnAdd);

            // Show form
            pickForm.ShowDialog();
        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            int selectedSubjects = 0;
            int totalUnits = 0;
            int maxUnits = 23;

            // COUNT CHECKED SUBJECTS
            // ======================================
            foreach (DataGridViewRow row in dvgModifyEnrollment.Rows)
            {
                bool isChecked = false;

                if (row.Cells[0].Value != null)
                {
                    isChecked = (bool)row.Cells[0].Value;
                }

                if (isChecked)
                {
                    selectedSubjects++;

                    totalUnits += Convert.ToInt32(row.Cells[3].Value);
                }
            }
            DialogResult result = MessageBox.Show(
                     "Selected Subjects: " + selectedSubjects +
                     "\nTotal Units: " + totalUnits +
                     "\n\nAre you sure you want to save the changes?",
                     "Confirm Changes",
                     MessageBoxButtons.YesNo,
                     MessageBoxIcon.Question
                 );

            // If NO, stop the method
            if (result == DialogResult.No)
            {
                return;
            }



            

            // ======================================
            // CHECK MAX UNITS
            // ======================================
            if (totalUnits > maxUnits)
            {
                MessageBox.Show(
                    "Total units exceeded!\n\n" +
                    "Maximum Units Allowed: " + maxUnits +
                    "\nYour Total Units: " + totalUnits,

                    "Unit Limit Reached",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            // ======================================
            // SAVE SUCCESS
            // ======================================
            MessageBox.Show(
                "Changes saved successfully!\n\n" +
                "Selected Subjects: " + selectedSubjects +
                "\nTotal Units: " + totalUnits,

                "Saved",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
           
        }

        private void UpdateEnrollmentSummary() //Update the summary labels based on the current subjects in the DataGridView
        {
            int totalUnits = 0;

            foreach (DataGridViewRow row in dvgModifyEnrollment.Rows)
            {
                if (row.Cells[4].Value != null)
                {
                    int units;
                    if (int.TryParse(row.Cells[4].Value.ToString(), out units))
                    {
                        totalUnits += units;
                    }
                }
            }

            lblUnitsEnrolled.Text = "Units Enrolled: " + totalUnits;

        }
    }
}


=======
            DummyAdd("COMP 009", "Object Oriented Programming", "2 - BSIT-SM 2-2 - W/TH 05:30PM-07:30PM/10:30AM-01:30PM");
            DummyAdd("COMP 010", "Information Management", "2 - BSIT-SM 2-2 - S/S 02:30PM-04:30PM/05:00PM-08:00PM");
            DummyAdd("COMP 012", "Network Administration", "2 - BSIT-SM 2-2 - W/W 08:00AM-10:00AM/10:30AM-01:30PM");
            DummyAdd("COMP 013", "Human Computer Interaction", "2 - BSIT-SM 2-2 - S 07:30AM-10:30AM");
            DummyAdd("COMP 014", "Quantitative Methods with Modeling and Simulation",  "2 - BSIT-SM 2-2 - S 07:30AM-10:30AM");
            DummyAdd("ELEC IT-FE2", "BSIT Free Elective 2", "2 - BSIT-SM 2-2 - M 02:30PM-05:30PM");
            DummyAdd("INTE 202", "Integrative Programming and Technologies 1", "2 - BSIT-SM 2-2 - M 02:30PM-05:30PM");
            DummyAdd("PATHFIT 4", "Physical Activity Towards Health and Fitness 4", "2 - BSIT-SM 2-2 - M 02:30PM-05:30PM");

        }

        private static string connectionString =
           "server=127.0.0.1;port=3306;database=gentechdb_admin;uid=root;pwd=1234;";

        private void DummyAdd(string code, string description, string schedule)
        {
            int index = kryptonDataGridView1.Rows.Add();
            DataGridViewRow row = kryptonDataGridView1.Rows[index];

            row.Cells[0].Value = false;
            row.Cells[1].Value = code;
            row.Cells[2].Value = description;
            row.Cells[3].Value = schedule;
        }


        private void kryptonDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
         
        }

        private void hopeRoundButton3_Click(object sender, EventArgs e)
        {
            label1.Visible = true;
            label2.Visible = true;
            label5.Visible = true;
            DataTable table = new DataTable();

            table.Columns.Add("Select", typeof(bool));
            table.Columns.Add("Subject Code");
            table.Columns.Add("Description");
            table.Columns.Add("Schedule");

            table.Rows.Add(false, "IT101", "Introduction to Computing", "Mon 8:00-10:00 AM");
            table.Rows.Add(false, "IT102", "Computer Programming 1", "Tue 10:00-12:00 PM");
            table.Rows.Add(false, "IT103", "Discrete Mathematics", "Wed 1:00-3:00 PM");
            table.Rows.Add(false, "IT104", "Data Structures", "Thu 8:00-10:00 AM");
            table.Rows.Add(false, "IT105", "Database Management", "Fri 10:00-12:00 PM");
            table.Rows.Add(false, "IT106", "Web Development", "Sat 1:00-4:00 PM");
            table.Rows.Add(false, "IT107", "Human Computer Interaction", "Mon 3:00-5:00 PM");
            table.Rows.Add(false, "IT108", "Information Assurance", "Wed 8:00-10:00 AM");

            kryptonDataGridView1.DataSource = table;

            kryptonDataGridView1.Columns["Select"].Width = 60;
            kryptonDataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            kryptonDataGridView1.RowHeadersVisible = false;
            kryptonDataGridView1.AllowUserToAddRows = false;
            kryptonDataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void hopeRoundButton1_Click(object sender, EventArgs e)
        {
            hopeRoundButton1.Text = "Add";
            SetupPopup();
            panel2.Visible = true;
            kryptonDataGridView1.Enabled = false;
            btn_Back.Visible = true;
            btn_add.Visible = true;
            txt_AddCode.Text = "Suject Code";
            txt_AddDesc.Text = "Description";
            txt_AddSched.Text = "Schedule";

            
        }
        private void kryptonDataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (kryptonDataGridView1.IsCurrentCellDirty)
            {
                kryptonDataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void kryptonDataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            bool isChecked = Convert.ToBoolean(kryptonDataGridView1.Rows[e.RowIndex].Cells[0].Value);
            kryptonDataGridView1.Rows[e.RowIndex].Cells[0].Value = !isChecked;

            kryptonDataGridView1.EndEdit();
        }
        private void kryptonDataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex >= 0)
            {
                kryptonDataGridView1.EndEdit();
            }
        }


        //---------------------------
        //CHANGE SUBJECT BUTTON
        //---------------------------
        private void hopeRoundButton2_Click(object sender, EventArgs e)
        {
            DataGridViewRow rowToEdit = null;

            foreach (DataGridViewRow row in kryptonDataGridView1.Rows)
            {
                // Check if the cell is not null and actually True
                if (row.Cells[0].Value != null && (bool)row.Cells[0].Value == true)
                {
                    rowToEdit = row;
                    break;
                }
            }

            if (rowToEdit != null)
            {
                // Map the data to your edit fields
                txt_AddCode.Text = rowToEdit.Cells[1].Value?.ToString();
                txt_AddDesc.Text = rowToEdit.Cells[2].Value?.ToString();
                txt_AddSched.Text = rowToEdit.Cells[3].Value?.ToString();

                btn_add.Text = "Update";
                btn_add.Visible = true;
                btn_Back.Visible = true;

                SetupPopup();
                panel2.Visible = true;
                kryptonDataGridView1.Enabled = false;
            }
            else
            {
                MessageBox.Show("Please check the 'Select' box for the subject you want to edit.");
            }
        }
        private void hopeRoundButton4_Click(object sender, EventArgs e)
        {
            List<DataGridViewRow> rowsToDelete = new List<DataGridViewRow>();

            foreach (DataGridViewRow row in kryptonDataGridView1.Rows)
            {
                if (Convert.ToBoolean(row.Cells[0].Value) == true)
                {
                    rowsToDelete.Add(row);
                }
            }

            if (rowsToDelete.Count > 0)
            {
                if (MessageBox.Show($"Drop {rowsToDelete.Count} subject(s)?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    foreach (var row in rowsToDelete)
                    {
                        kryptonDataGridView1.Rows.Remove(row);
                    }
                }
            }
        }

        private void panel2_Click(object sender, EventArgs e)
        {

        }
        private void SetupPopup()
        {
            panel2.Size = new Size(500, 300); 
                                               
            panel2.Location = new Point(
                (this.ClientSize.Width - panel2.Width) / 2,
                (this.ClientSize.Height - panel2.Height) / 2
            );
            panel2.BringToFront(); 
        }

     

        private void hopeRichTextBox3_Click(object sender, EventArgs e)
        {
            txt_AddSched.Text = " ";
        }

        private void nightLabel3_Click(object sender, EventArgs e)
        {

        }

        private void btn_Back_Click(object sender, EventArgs e)
        {
           ClosePopup();  
        }
        private void ClosePopup()
        {
            txt_AddCode.Clear();
            txt_AddDesc.Clear();
            txt_AddSched.Clear();
            panel2.Visible = false;
            kryptonDataGridView1.Enabled = true;
            btn_add.Visible = false;
            btn_Back.Visible = false;
        }

        private void AdminModifyEnrollment_Load(object sender, EventArgs e)
        {

        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_AddCode.Text)) return;

            if (btn_add.Text == "Update")
            {
                foreach (DataGridViewRow row in kryptonDataGridView1.Rows)
                {
                    if (Convert.ToBoolean(row.Cells[0].Value) == true)
                    {
                        row.Cells[1].Value = txt_AddCode.Text;
                        row.Cells[2].Value = txt_AddDesc.Text;
                        row.Cells[3].Value = txt_AddSched.Text;

                        row.Cells[0].Value = false;
                        break;
                    }
                }
            }
            else
            {
 
                DummyAdd(txt_AddCode.Text, txt_AddDesc.Text, txt_AddSched.Text);
            }

            ClosePopup();
            btn_add.Text = "Add";
        }

        private void kryptonDataGridView1_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void txt_AddCode_Click(object sender, EventArgs e)
        {
            txt_AddCode.Text = " ";
        }

        private void txt_AddDesc_Click(object sender, EventArgs e)
        {
            txt_AddDesc.Text = " ";
        }

        private void kryptonTextBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void kryptonTextBox1_Click(object sender, EventArgs e)
        {
            kryptonTextBox1.Text = " ";
        }
    }
}
>>>>>>> a83721eeed923229ae7731dc76476239a0cb8541
