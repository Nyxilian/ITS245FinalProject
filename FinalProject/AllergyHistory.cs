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
        private MySqlConnection conn;
        private int cbIndex;
        DataTable dt = new DataTable();

        // View 0, Add 1, Modify 2
        private int mode = 0;

        private void ModeChange(int m) // bascially for controlling Action menu
        {
            switch (m)
            {
                case 0:
                    btnAdd.Enabled = true;
                    btnModify.Enabled = true;
                    btnSave.Enabled = false;
                    btnUndo.Enabled = false;
                    btnDelete.Enabled = false;

                    btnAdd.BackColor = Color.White;
                    btnModify.BackColor = Color.White;
                    btnSave.BackColor = Color.LightGray;
                    btnUndo.BackColor = Color.LightGray;
                    btnDelete.BackColor = Color.LightGray;
                    break;
                case 1:
                    btnAdd.Enabled = false;
                    btnSave.Enabled = true;
                    btnUndo.Enabled = true;
                    btnDelete.Enabled = true;

                    btnAdd.BackColor = Color.LightGray;
                    btnSave.BackColor = Color.White;
                    btnUndo.BackColor = Color.White;
                    btnDelete.BackColor = Color.White;
                    break;
                case 2:
                    btnModify.Enabled = false;
                    btnSave.Enabled = true;
                    btnUndo.Enabled = true;
                    btnDelete.Enabled = true;

                    btnModify.BackColor = Color.LightGray;
                    btnSave.BackColor = Color.White;
                    btnUndo.BackColor = Color.White;
                    btnDelete.BackColor = Color.White;
                    break;
            }
            mode = m;
        }

        private void tbEnable(bool b)
        {
            foreach (Control control in panel4.Controls)
            {
                if (control is TextBox)
                {
                    control.Enabled = b;
                    if (b)
                    {
                        control.BackColor = Color.White;
                    }
                    else
                    {
                        control.BackColor = Color.LightGray;
                    }
                }
            }
        }

        private void UpdateCB()
        {
            cbPatient.Items.Clear();
            Functions.InitPatientList(conn);
            foreach (Patient p in Functions.patients)
            {
                cbPatient.Items.Add(p.Info_Combo());
            }
        }

        private void UpdateDGV(int pid)
        {
            try
            {
                dt.Clear();
                dt = Functions.LoadTable($"SELECT AllergyID, Allergen FROM allergyhistory WHERE PatientID = {pid} AND deleted = 0;", conn);
                dataGridView1.DataSource = dt;
                dataGridView1.Columns["AllergyID"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error with updating DGV: " + ex.Message);
            }
        }

        private void UpdateTB(int aid)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("SelectAHByPID", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("a_AllergyID", aid);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        tbAllergyID.Text = reader["AllergyID"].ToString();
                        tbPatientID.Text = reader["PatientID"].ToString();
                        tbAllergen.Text = reader["Allergen"].ToString();
                        tbStartDate.Text = reader["AllergyStartDate"].ToString();
                        tbEndDate.Text = reader["AllergyEndDate"].ToString();
                        tbDescription.Text = reader["AllergyDescription"].ToString();
                        checkDeleted.Checked = reader["deleted"].ToString() == "1";
                    }
                }
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error with updating textboxes: " + ex.Message);
            }

        }

        public AllergyHistory(MySqlConnection conn, int cbIndex)
        {
            InitializeComponent();
            this.conn = conn;
            this.cbIndex = cbIndex;
        }

        private void AllergyHistory_Load(object sender, EventArgs e)
        {
            UpdateCB();
            cbPatient.SelectedIndex = cbIndex;
            tbEnable(false);
            ModeChange(0);
        }

        private void cbPatient_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbIndex = cbPatient.SelectedIndex;
            UpdateDGV(Functions.FindPIDBycbIndex(cbPatient.Items[cbIndex].ToString()));
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex < dt.Rows.Count)
            {
                UpdateTB(Convert.ToInt32(dt.Rows[e.RowIndex][0].ToString()));
            }
        }

        // Navigation
        private void btnToLogin_Click(object sender, EventArgs e)
        {

        }

        private void btnToSelectPatient_Click(object sender, EventArgs e)
        {
            SelectPatient sp = new SelectPatient(conn, cbIndex);
            sp.Show();
        }

        private void btnToPatientDemo_Click(object sender, EventArgs e)
        {
            PatientsDemographics pd = new PatientsDemographics(conn, cbIndex);
            pd.Show();
        }

        private void btnToGenMedHis_Click(object sender, EventArgs e)
        {

        }

        private void btnToFamilyHistory_Click(object sender, EventArgs e)
        {

        }

        // Action Menu
        private void btnAdd_Click(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToAddRows = true;
            dataGridView1.ReadOnly = true;
            dataGridView1.Rows[dataGridView1.RowCount - 1].ReadOnly = false;
            foreach (Control control in panel4.Controls)
            {
                if (control is TextBox)
                {
                    control.Text = "";
                }
            }
            tbEnable(true);
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }


    }
}
