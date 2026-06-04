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
    public partial class AdminModifyEnrollment : UserControl
    {
        public AdminModifyEnrollment()
        {
            InitializeComponent();

            DummyAdd("COMP 009", "Object Oriented Programming", "2 - BSIT-SM 2-2 - W/TH 05:30PM-07:30PM/10:30AM-01:30PM");
            DummyAdd("COMP 010", "Information Management", "2 - BSIT-SM 2-2 - S/S 02:30PM-04:30PM/05:00PM-08:00PM");
            DummyAdd("COMP 012", "Network Administration", "2 - BSIT-SM 2-2 - W/W 08:00AM-10:00AM/10:30AM-01:30PM");
            DummyAdd("COMP 013", "Human Computer Interaction", "2 - BSIT-SM 2-2 - S 07:30AM-10:30AM");
            DummyAdd("COMP 014", "Quantitative Methods with Modeling and Simulation",  "2 - BSIT-SM 2-2 - S 07:30AM-10:30AM");
            DummyAdd("ELEC IT-FE2", "BSIT Free Elective 2", "2 - BSIT-SM 2-2 - M 02:30PM-05:30PM");
            DummyAdd("INTE 202", "Integrative Programming and Technologies 1", "2 - BSIT-SM 2-2 - M 02:30PM-05:30PM");
            DummyAdd("PATHFIT 4", "Physical Activity Towards Health and Fitness 4", "2 - BSIT-SM 2-2 - M 02:30PM-05:30PM");

        }

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
