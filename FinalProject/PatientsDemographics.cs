//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;
//using MySql.Data.MySqlClient;

//namespace FinalProject
//{
//    public partial class PatientsDemographics : Form
//    {
//        private MySqlConnection conn = new MySqlConnection();
//        private MySqlDataAdapter ad = new MySqlDataAdapter();
//        private DataTable dt = new DataTable();
//        private int pid;
//        // 0: View, 1: Add, 2: Modify
//        private int mode = 0;

//        public PatientsDemographics(MySqlConnection conn, int pid)
//        {
//            InitializeComponent();
//            this.conn = conn;
//            this.pid = pid;
//        }

//        private void ModeChange(int m)
//        {
//            if(m == 0) // View mode
//            {
//                mode = 0;
//                // button
//                btnAdd.Enabled = true;
//                btnModify.Enabled = true;
//                btnSave.Enabled = false;
//                btnUndo.Enabled = false;
//                btnDelete.Enabled = false;
                
//                dataGridView1.ReadOnly = true; // disabling editing
//                dataGridView1.BackgroundColor = Color.LightGray;
//            }
//            else if(m == 1) // Add mode
//            {
//                mode = 1;
//                // button
//                btnAdd.Enabled = false;
//                btnModify.Enabled = true;
//                btnSave.Enabled = true;
//                btnUndo.Enabled = true;
//                btnDelete.Enabled = false;

//                dataGridView1.ReadOnly = false; // allowing editing
//                dataGridView1.BackgroundColor = Color.White;
//            }
//            else // Modify mode
//            {
//                mode = 2;
//                btnAdd.Enabled = true;
//                btnModify.Enabled = false;
//                btnSave.Enabled = true;
//                btnUndo.Enabled = true;
//                btnDelete.Enabled = true;

//                dataGridView1.ReadOnly = false; // allowing editing
//                dataGridView1.BackgroundColor = Color.White;
//            }
//        }

//        private void PatientsDemographics_Load(object sender, EventArgs e)
//        {
//            ModeChange(0); // View mode
//            // the mode is initially set to View
//            string query = "SELECT * " +
//                "FROM its245final.patientdemographics " +
//                $"WHERE PatientID = {pid};";
            

//            ad = Functions.LoadTable(query, conn);
//            ad.Fill(dt);
//            dataGridView1.DataSource = dt;
//            //dataGridView1.Columns["deleted"].Visible = false;
//        }

//        private void btnAdd_Click(object sender, EventArgs e)
//        {
//            ModeChange(1); // Add mode
//            dt.Clear();
//            ad.Fill(dt); // initiating the dataTable if it had any changes
            
//            DataRow dr = dt.NewRow(); // a new row for dataTable
//            dataGridView1.Rows[0].ReadOnly = true; // unable editing the existing values

//            string query = "SELECT MAX(PatientID) from its245final.patientdemographics;";
//            try
//            {
//                MySqlCommand cmd = new MySqlCommand(query, conn);
//                object result = cmd.ExecuteScalar(); // bringing the last # of PatientID
//                if (result != DBNull.Value)
//                {
//                    dr[0] = Convert.ToInt32(result) + 1;
//                    dt.Rows.Add(dr); // Add the smallest value of PatientID that doesn't exsit
//                }
//                cmd.Dispose();
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show(ex.Message);
//            }
//            dataGridView1.DataSource = dt; // update dataGridView with the updated data
//        }

//        private void btnModify_Click(object sender, EventArgs e)
//        {
//            ModeChange(2); // Notice Modify mode
//            dataGridView1.ReadOnly = false;
//            dataGridView1.AllowUserToAddRows = false;
//        }

//        private void btnSave_Click(object sender, EventArgs e)
//        {
//            // strings for query to INSERT or UPDATE the data into MySQL
//            List<string> targetColumnNames = new List<string>();
//            List<string> targetCellValues = new List<string>();
//            string query = "";
//            string temp = "";
//            DataGridViewRow row = null;
            
//            // Setting the index of the row looping
//            if (mode == 1) // Add mode only loops the newly added row
//            {
//                row = dataGridView1.Rows[1];
//            }
//            if (mode == 2) // Modify mode only loops the existing row
//            {
//                row = dataGridView1.Rows[0];
//            }

//            // Add the name of columns and their values into the lists
//            // if it has any values
//            foreach (DataGridViewCell cell in row.Cells)
//            {
//                if (!string.IsNullOrEmpty(cell.Value.ToString()))
//                {
//                    targetColumnNames.Add($"`{dataGridView1.Columns[cell.ColumnIndex].Name}`");
//                    if (cell.Value is DateTime) // Check if the cell contains a DateTime
//                    {
//                        DateTime dateValue = (DateTime)cell.Value;
//                        targetCellValues.Add($"\'{dateValue.ToString("yyyy/MM/dd")}\'");
//                    }
//                    else if (cell.Value is bool) // Check if the cell contains a boolean
//                    {
//                        bool boolValue = (bool)cell.Value;
//                        int t;
//                        t = boolValue ? 1 : 0;
//                        targetCellValues.Add($"{t}");
//                    }
//                    else
//                    {
//                        targetCellValues.Add($"\'{cell.Value}\'");
//                    }
//                }
//            }
//            if (mode == 1) // Add mode
//            {
//                temp = string.Join(", ", targetColumnNames);
//                query = "INSERT INTO its245final.patientdemographics (" + temp + ") " +
//                    "VALUES (";
//                temp = string.Join(", ", targetCellValues);
//                query += temp + ");";
//            }
//            if (mode == 2) // Modify mode
//            {
//                query = "UPDATE its245final.patientdemographics " +
//                    "SET ";
//                // no need to be compare the count of another list
//                // because two lists have same size
//                for (int i = 0; i < targetColumnNames.Count; i++)
//                {
//                    if (i != 0)
//                    {
//                        temp += ", ";
//                    }
//                    temp += targetColumnNames[i] + " = " + targetCellValues[i];
//                }
//                query += temp + $" WHERE PatientID = {pid};";
//            }
//            try // Executing Query
//            {
//                MySqlCommand cmd = new MySqlCommand(query, conn);
//                cmd.ExecuteNonQuery();
//                cmd.Dispose();
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show(ex.Message);
//            }
//            ModeChange(0); // Returning to View mode
//        }

//        private void btnUndo_Click(object sender, EventArgs e)
//        {
//            dt.Clear();
//            ad.Fill(dt);
//            ModeChange(0);
//            if(mode == 1)
//            {
//                btnAdd.Enabled = true;
//            }
//            if(mode == 2)
//            {
//                btnModify.Enabled = true;
//            }
//        }

//        private void btnDelete_Click(object sender, EventArgs e)
//        {
//            try
//            {
//                MySqlCommand cmd = new MySqlCommand("DeleteByPID", conn);
//                cmd.CommandType = CommandType.StoredProcedure;
//                cmd.Parameters.AddWithValue("@pid", pid);
//                cmd.ExecuteNonQuery();
//                MessageBox.Show("Successfully deleted the data");
//            }
//            catch(Exception ex) 
//            { 
//                MessageBox.Show(ex.Message);
//            }
//            // Retrieving data from DB again.
//            dt.Clear();
//            ad.Fill(dt);
//            ModeChange(0); // Returning to View mode
//        }
//    }
//}
