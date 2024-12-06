using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
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
        private int loginID;
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
                    btnDelete.Enabled = true;

                    btnAdd.BackColor = Color.White;
                    btnModify.BackColor = Color.White;
                    btnSave.BackColor = Color.LightGray;
                    btnUndo.BackColor = Color.LightGray;
                    btnDelete.BackColor = Color.White;
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

        private void tbClear()
        {
            foreach (Control control in panel4.Controls)
            {
                if (control is TextBox)
                {
                    control.Text = "";
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
                Functions.Logging(loginID, $"Failed to bring data; PID: {pid}", conn);
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
                Functions.Logging(loginID, $"Failed to bring data; AID: {aid}", conn);
                MessageBox.Show("Error with updating textboxes: " + ex.Message);
            }

        }

        public AllergyHistory(MySqlConnection conn, int cbIndex, int loginID)
        {
            InitializeComponent();
            this.conn = conn;
            this.cbIndex = cbIndex;
            this.loginID = loginID;
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
            UpdateDGV(Functions.patients[cbIndex].PID);
            tbClear();
            if (mode != 0)
            {
                ModeChange(0);
            }
            Functions.Logging(loginID, $"Open the Allergy History record; PID: {Functions.patients[cbIndex].PID}", conn);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex < dt.Rows.Count)
            {
                UpdateTB(Convert.ToInt32(dt.Rows[e.RowIndex][0].ToString()));
                if(mode == 1)
                {
                    ModeChange(0);
                }
            }
            Functions.Logging(loginID, $"Open the Allergy History record; AID: {dt.Rows[e.RowIndex][0].ToString()}", conn);
        }

        // Navigation
        private void btnToLogin_Click(object sender, EventArgs e)
        {
            Functions.Logging(loginID, "Move To Login Form", conn);
            Login l = new Login(conn);
            Hide();
            l.ShowDialog();
            Close();
        }

        private void btnToSelectPatient_Click(object sender, EventArgs e)
        {
            Functions.Logging(loginID, "Move To Select Patient Form", conn);
            SelectPatient sp = new SelectPatient(conn, cbIndex, loginID);
            Hide();
            sp.ShowDialog();
            Close();
        }

        private void btnToPatientDemo_Click(object sender, EventArgs e)
        {
            Functions.Logging(loginID, "Move To Patient Demographics Form", conn);
            PatientsDemographics pd = new PatientsDemographics(conn, cbIndex, loginID);
            Hide();
            pd.ShowDialog();
            Close();
        }

        private void btnToGenMedHis_Click(object sender, EventArgs e)
        {
            Functions.Logging(loginID, "Move To General Medical History Form", conn);
            GeneralMedical gm = new GeneralMedical(conn, cbIndex, loginID);
            Functions.EnableReadOnly(gm);
            Hide();
            gm.ShowDialog();
            Close();
        }

        private void btnToFamilyHistory_Click(object sender, EventArgs e)
        {
            Functions.Logging(loginID, "Move To Family History Form", conn);
            Family_History fh = new Family_History(conn, cbIndex, loginID);
            Functions.EnableReadOnly(fh);
            Hide();
            fh.ShowDialog();
            Close();
        }

        // Action Menu
        private void btnAdd_Click(object sender, EventArgs e)
        {
            foreach (Control control in panel4.Controls)
            {
                if (control is TextBox)
                {
                    control.Text = "";
                }
            }
            tbEnable(true);

            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT MAX(AllergyID) FROM allergyhistory;", conn);
                object result = cmd.ExecuteScalar();
                if (result != DBNull.Value)
                {
                    tbAllergyID.Text = (Convert.ToInt16(result.ToString()) + 1).ToString();
                }
                cmd.Dispose();
                Functions.Logging(loginID, "Try to add a new data into the Allergy History table", conn);
            }
            catch (Exception ex)
            {
                Functions.Logging(loginID, "Failed to add a new data into the Allergy History table", conn);
                MessageBox.Show("Error with bringing Max(AllergyID): " + ex.Message);
            }
            tbAllergyID.Enabled = false;
            tbPatientID.Text = Functions.patients[cbIndex].PID.ToString();
            tbPatientID.Enabled = false;
            ModeChange(1);
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            UpdateCB();
            cbPatient.SelectedIndex = cbIndex;
            tbEnable(true);
            ModeChange(2);
            Functions.Logging(loginID, "Try to modify a new data into the Allergy History table", conn);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            MySqlCommand cmd = null;

            if (!Functions.IsValidDate(tbStartDate.Text))
            {
                Functions.Logging(loginID, "Failed to update the Allergy History table", conn);
                MessageBox.Show("Check the AllergyStartDate input format | YYYY-MM-DD");
                return;
            }
            if (!Functions.IsValidDate(tbEndDate.Text))
            {
                Functions.Logging(loginID, "Failed to update the Allergy History table", conn);
                MessageBox.Show("Check the AllergyEndDate input format | YYYY-MM-DD");
                return;
            }

            try
            {
                if (mode == 1) // Add mode
                {
                    cmd = new MySqlCommand("InsertAH", conn);
                }
                if (mode == 2) // Modify mode
                {
                    cmd = new MySqlCommand("UpdateAHByAID", conn);
                }
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("a_AllergyID", tbAllergyID.Text);
                cmd.Parameters.AddWithValue("a_PatientID", tbPatientID.Text);
                cmd.Parameters.AddWithValue("a_Allergen", tbAllergen.Text);
                if (string.IsNullOrEmpty(tbStartDate.Text))
                {
                    cmd.Parameters.AddWithValue("a_AllergyStartDate", null);
                }
                else
                {
                    cmd.Parameters.AddWithValue("a_AllergyStartDate", tbStartDate.Text);
                }
                if (string.IsNullOrEmpty(tbEndDate.Text))
                {
                    cmd.Parameters.AddWithValue("a_AllergyEndDate", null);
                }
                else
                {
                    cmd.Parameters.AddWithValue("a_AllergyEndDate", tbEndDate.Text);
                }
                cmd.Parameters.AddWithValue("a_AllergyDescription", tbDescription.Text);
                cmd.Parameters.AddWithValue("a_deleted", checkDeleted.Checked ? 1 : 0);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                Functions.Logging(loginID, $"Update the Allergy History table; AID : {tbAllergyID.Text}", conn);
            }
            catch (Exception ex)
            {
                Functions.Logging(loginID, "Failed to update the Allergy History table", conn);
                MessageBox.Show("Error with executing query: " + ex.Message);
                return;
            }
            MessageBox.Show("Data Saved Successfully");

            UpdateDGV(Functions.patients[cbIndex].PID);
            UpdateTB(Convert.ToInt32(tbAllergyID.Text));
            ModeChange(0);
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            UpdateDGV(Functions.patients[cbIndex].PID);
            tbClear();
            tbEnable(false);
            ModeChange(0);
            Functions.Logging(loginID, "Undo the changes", conn);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("DeleteByAID", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("aid", tbAllergyID.Text);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                Functions.Logging(loginID, $"Delete in the Allergy History table; AID: {tbAllergyID.Text}", conn);
            }
            catch (Exception ex)
            {
                Functions.Logging(loginID, $"Failed to delete in the Allergy History table; AID: {tbAllergyID.Text}", conn);
                MessageBox.Show("Error with deleting data: " + ex.Message);
            }
            UpdateCB();
            cbPatient.SelectedIndex = 0;
            tbClear();
            ModeChange(0);
            MessageBox.Show("Data Deleted successfully");
        }
    }
}
