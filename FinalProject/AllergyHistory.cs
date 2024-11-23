using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace FinalProject
{
    public partial class AllergyHistory : Form
    {
        MySqlConnection conn = new MySqlConnection();
        MySqlDataAdapter ad = new MySqlDataAdapter();
        DataTable dt = new DataTable();
        // 0: View, 1: Add, 2: Modify
        private int mode = 0;

        public AllergyHistory()
        {
            InitializeComponent();
        }

        public AllergyHistory(MySqlConnection conn)
        {
            InitializeComponent();
            this.conn = conn;
        }

        private void ModeChange(int m)
        {
            if (m == 0) // View mode
            {
                dataGridView1.AllowUserToAddRows = false;
                mode = 0;
                // button
                btnAdd.Enabled = true;
                btnModify.Enabled = true;
                btnSave.Enabled = false;
                btnUndo.Enabled = false;
                btnDelete.Enabled = false;

                dataGridView1.ReadOnly = true; // disabling editing
                dataGridView1.BackgroundColor = Color.LightGray;
            }
            else if (m == 1) // Add mode
            {
                mode = 1;
                // button
                btnAdd.Enabled = false;
                btnModify.Enabled = true;
                btnSave.Enabled = true;
                btnUndo.Enabled = true;
                btnDelete.Enabled = false;

                dataGridView1.ReadOnly = false; // allowing editing
                dataGridView1.BackgroundColor = Color.White;
            }
            else // Modify mode
            {
                mode = 2;
                btnAdd.Enabled = true;
                btnModify.Enabled = false;
                btnSave.Enabled = true;
                btnUndo.Enabled = true;
                btnDelete.Enabled = true;

                dataGridView1.ReadOnly = false; // allowing editing
                dataGridView1.BackgroundColor = Color.White;
            }
        }

        private void UpdateListBox()
        {
            string query = "SELECT * FROM its245final.allergyhistory WHERE deleted = 0;";
            ad = Functions.LoadTable(query, conn);
            ad.Fill(dt);
            foreach (DataRow row in dt.Rows)
            {
                if (!listBox1.Items.Contains(row["Allergen"]))
                {
                    listBox1.Items.Add(row["Allergen"].ToString());
                }
            }
        }

        private void AllergyHistory_Load(object sender, EventArgs e)
        {
            UpdateListBox();
            ModeChange(0);
            btnAdd.Enabled = false;
            btnModify.Enabled = false;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRow[] filteredRows = dt.Select($"Allergen = '{listBox1.Items[listBox1.SelectedIndex]}'");

            DataTable filteredTable = dt.Clone();
            foreach (var row in filteredRows)
            {
                filteredTable.ImportRow(row);
            }
            dataGridView1.DataSource = filteredTable;

            btnAdd.Enabled = true;
            btnModify.Enabled = true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ModeChange(1); // Add mode
            dt.Clear();
            ad.Fill(dt); // initiating the dataTable if it had any changes

            DataRow dr = dt.NewRow(); // a new row for dataTable
            dataGridView1.Rows[0].ReadOnly = true; // unable editing the existing values

            string query = "SELECT MAX(AllergyID) from its245final.allergyhistory;";
            try
            {
                MySqlCommand cmd = new MySqlCommand(query, conn);
                object result = cmd.ExecuteScalar(); // bringing the last # of PatientID
                if (result != DBNull.Value)
                {
                    dr[0] = Convert.ToInt32(result) + 1;
                    dt.Rows.Add(dr); // Add the smallest value of PatientID that doesn't exsit
                }
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            dataGridView1.DataSource = dt; // update dataGridView with the updated data
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            ModeChange(2); // Notice Modify mode
            dataGridView1.ReadOnly = false;
            dataGridView1.AllowUserToAddRows = false;
        }

        // Basically same codes with Patients Demographics Form
        // Adding small details on the WHERE clauses
        private void btnSave_Click(object sender, EventArgs e)
        {
            // strings for query to INSERT or UPDATE the data into MySQL
            List<string> targetColumnNames = new List<string>();
            List<string> targetCellValues = new List<string>();
            string query = "";
            string temp = "";
            int aid;

            // Add the name of columns and their values into the lists
            // if it has any values
            foreach (DataGridViewRow row in dt.Rows)
            {
                aid = Convert.ToInt32(row.Cells[0].Value); // AllergyID
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (!string.IsNullOrEmpty(cell.Value.ToString()))
                    {
                        targetColumnNames.Add($"`{dataGridView1.Columns[cell.ColumnIndex].Name}`");
                        if (cell.Value is DateTime) // Check if the cell contains a DateTime
                        {
                            DateTime dateValue = (DateTime)cell.Value;
                            targetCellValues.Add($"\'{dateValue.ToString("yyyy/MM/dd")}\'");
                        }
                        else if (cell.Value is bool) // Check if the cell contains a boolean
                        {
                            bool boolValue = (bool)cell.Value;
                            int t;
                            t = boolValue ? 1 : 0;
                            targetCellValues.Add($"{t}");
                        }
                        else
                        {
                            targetCellValues.Add($"\'{cell.Value}\'");
                        }
                    }
                }
                if (mode == 1) // Add mode
                {
                    temp = string.Join(", ", targetColumnNames);
                    query = "INSERT INTO its245final.allergyhistory (" + temp + ") " +
                        "VALUES (";
                    temp = string.Join(", ", targetCellValues);
                    query += temp + ");";
                }
                if (mode == 2) // Modify mode
                {
                    query = "UPDATE its245final.allergyhistory " +
                        "SET ";
                    // no need to be compare the count of another list
                    // because two lists have same size
                    for (int i = 0; i < targetColumnNames.Count; i++)
                    {
                        if (i != 0)
                        {
                            temp += ", ";
                        }
                        temp += targetColumnNames[i] + " = " + targetCellValues[i];
                    }
                    query += temp + $" WHERE PatientID = {aid};";
                }
                try // Executing Query
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            ModeChange(0); // Returning to View mode
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            dt.Clear();
            ad.Fill(dt);
            ModeChange(0);
            if (mode == 1)
            {
                btnAdd.Enabled = true;
            }
            if (mode == 2)
            {
                btnModify.Enabled = true;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }
    }
}
