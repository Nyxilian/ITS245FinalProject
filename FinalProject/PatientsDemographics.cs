using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;

namespace FinalProject
{
    public partial class PatientsDemographics : Form
    {
        private int cbIndex;
        private int cbIndexCopy; // Copy the value of cbIndex when the user uses Add mode
        MySqlConnection conn;
        // View 0, Add 1, Modify 2
        private int mode = 0;

        private void ModeChange(int m)
        {
            switch (m)
            {
                case 0:
                    btnAdd.Enabled = true;
                    btnModify.Enabled = true;
                    btnSave.Enabled = false;
                    btnUndo.Enabled = false;
                    btnDelete.Enabled = false;

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
                    btnUndo.BackColor= Color.White;
                    btnDelete.BackColor = Color.White;
                    break;
            }
            mode = m;
        }
        
        public PatientsDemographics(MySqlConnection conn, int cbIndex)
        {
            InitializeComponent();
            this.conn = conn;
            this.cbIndex = cbIndex;
        }

        private void PatientsDemographics_Load(object sender, EventArgs e)
        {
            UpdateCB();
            cbPatient.SelectedIndex = cbIndex;
            tbEnable(false);
            UpdateTB(Functions.FindPIDBycbIndex(cbPatient.Items[cbIndex].ToString()));
            ModeChange(0);
        }

        private void tbEnable(bool b)
        {
            foreach (Control control in panel4.Controls)
            {
                if(control is TextBox)
                {
                    control.Enabled = b;
                    if(b)
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

        private void UpdateTB(int pid)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("SelectPDByPID", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("p_PatientID", pid);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        tbHospitalMR.Text = reader["HospitalMR#"].ToString();
                        tbPtLastName.Text = reader["PtLastName"].ToString();
                        tbPtPreviousLastName.Text = reader["PtPreviousLastName"].ToString();
                        tbPtFirstName.Text = reader["PtFirstName"].ToString();
                        tbPtMiddleInitial.Text = reader["PtMiddleInitial"].ToString();
                        tbSuffix.Text = reader["Suffix"].ToString();
                        tbHomeAddress.Text = reader["HomeAddress"].ToString();
                        tbHomeCity.Text = reader["HomeCity"].ToString();
                        tbHSPR.Text = reader["HomeState/Province/Region"].ToString();
                        tbHomeZip.Text = reader["HomeZip"].ToString();
                        tbCountry.Text = reader["Country"].ToString();
                        tbCitizenship.Text = reader["Citizenship"].ToString();
                        tbPtHomePhone.Text = reader["PtHomePhone"].ToString();
                        tbEmerPhoneNum.Text = reader["EmergencyPhoneNumber"].ToString();
                        tbEmailAddress.Text = reader["EmailAddress"].ToString();
                        tbSSN.Text = reader["SSN"].ToString();

                        if (DateTime.TryParse(reader["DOB"].ToString(), out DateTime dob))
                        {
                            if (dob.Year > DateTime.Now.Year)
                            {
                                dob = dob.AddYears(-100);
                            }
                            tbDOB.Text = dob.ToString("yyyy-MM-dd");
                        }
                        else
                        {
                            tbDOB.Text = string.Empty; // If the value is not a valid date
                        }

                        tbGender.Text = reader["Gender"].ToString();
                        tbEthnicAssoication.Text = reader["EthnicAssociation"].ToString();
                        tbReligion.Text = reader["Religion"].ToString();
                        tbMarital.Text = reader["MaritalStatus"].ToString();
                        tbEmploymentStatus.Text = reader["EmploymentStatus"].ToString();

                        if (DateTime.TryParse(reader["DateofExpire"].ToString(), out DateTime dateOfExpire))
                        {
                            if (dateOfExpire.Year > DateTime.Now.Year)
                            {
                                dateOfExpire = dateOfExpire.AddYears(-100);
                            }
                            tbDateOfExpire.Text = dateOfExpire.ToString("yyyy-MM-dd");
                        }
                        else
                        {
                            tbDateOfExpire.Text = string.Empty; // If the value is not a valid date
                        }

                        tbReferral.Text = reader["Referral"].ToString();
                        tbCurrentPrimaryHCPId.Text = reader["CurrentPrimaryHCPId"].ToString();
                        tbComments.Text = reader["Comments"].ToString();

                        if (DateTime.TryParse(reader["DateEntered"].ToString(), out DateTime dateEntered))
                        {
                            if (dateEntered.Year > DateTime.Now.Year)
                            {
                                dateEntered = dateEntered.AddYears(-100);
                            }
                            tbDateEntered.Text = dateEntered.ToString("yyyy-MM-dd");
                        }
                        else
                        {
                            tbDateEntered.Text = string.Empty; // If the value is not a valid date
                        }

                        tbNOKID.Text = reader["NextOfKinID"].ToString();
                        tbNOKRTP.Text = reader["NextOfKinRelationshipToPatient"].ToString();

                        checkDeleted.Checked = reader["deleted"].ToString() == "1";
                    }
                    else
                    {
                        MessageBox.Show("No data found for the given PatientID.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error with Updating TextBoxes: " + ex.Message);
            }
        }

        private void cbPatient_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbIndex = cbPatient.SelectedIndex;
            if (!string.IsNullOrEmpty(cbPatient.Items[cbIndex].ToString()))
            {
                UpdateTB(Functions.FindPIDBycbIndex(cbPatient.Items[cbIndex].ToString()));
            }
        }

        // Navigation
        private void btnToLogin_Click(object sender, EventArgs e)
        {

        }

        private void btnToSelectPatient_Click(object sender, EventArgs e)
        {

        }

        private void btnToGenMedHis_Click(object sender, EventArgs e)
        {

        }

        private void btnToAllergyHistory_Click(object sender, EventArgs e)
        {

        }

        private void btnToFamilyHistory_Click(object sender, EventArgs e)
        {

        }

        // Action Menu
        private void btnAdd_Click(object sender, EventArgs e)
        {
            cbIndexCopy = cbIndex;
            UpdateCB();
            cbPatient.Items.Add("");
            cbPatient.SelectedIndex = cbPatient.Items.Count - 1;
            foreach (Control control in panel4.Controls)
            {
                if (control is TextBox)
                {
                    control.Text = "";
                }
            }
            tbEnable(true);
            ModeChange(1);
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            UpdateCB();
            tbEnable(true);
            ModeChange(2);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            MySqlCommand cmd = null;

            // Check Date Input Format
            if (!Functions.IsValidDate(tbDOB.Text))
            {
                MessageBox.Show("Check the DOB input format | YYYY-MM-DD");
                return;
            }
            if (!Functions.IsValidDate(tbDateOfExpire.Text))
            {
                MessageBox.Show("Check the DateOfExpire input format | YYYY-MM-DD");
                return;
            }
            if (!Functions.IsValidDate(tbDateEntered.Text))
            {
                MessageBox.Show("Check the DateEntered input format | YYYY-MM-DD");
                return;
            }


            try
            {
                if(mode == 1) // Add mode
                {
                   cmd = new MySqlCommand("InsertPD", conn);
                }
                if (mode == 2) // Modify mode
                {
                    cmd = new MySqlCommand("UpdatePDByPID", conn);
                    cmd.Parameters.AddWithValue("p_PatientID", tbPatientID.Text);
                }
                
                cmd.CommandType = CommandType.StoredProcedure;

                // Add parameters to the command object
                cmd.Parameters.AddWithValue("p_HospitalMR", tbHospitalMR.Text);
                cmd.Parameters.AddWithValue("p_PtLastName", tbPtLastName.Text);
                cmd.Parameters.AddWithValue("p_PtPreviousLastName", tbPtPreviousLastName.Text);
                cmd.Parameters.AddWithValue("p_PtFirstName", tbPtFirstName.Text);
                cmd.Parameters.AddWithValue("p_PtMiddleInitial", tbPtMiddleInitial.Text);
                cmd.Parameters.AddWithValue("p_Suffix", tbSuffix.Text);
                cmd.Parameters.AddWithValue("p_HomeAddress", tbHomeAddress.Text);
                cmd.Parameters.AddWithValue("p_HomeCity", tbHomeCity.Text);
                cmd.Parameters.AddWithValue("p_HomeState", tbHSPR.Text);
                cmd.Parameters.AddWithValue("p_HomeZip", tbHomeZip.Text);
                cmd.Parameters.AddWithValue("p_Country", tbCountry.Text);
                cmd.Parameters.AddWithValue("p_Citizenship", tbCitizenship.Text);
                cmd.Parameters.AddWithValue("p_PtHomePhone", tbPtHomePhone.Text);
                cmd.Parameters.AddWithValue("p_EmergencyPhoneNumber", tbEmerPhoneNum.Text);
                cmd.Parameters.AddWithValue("p_EmailAddress", tbEmailAddress.Text);
                cmd.Parameters.AddWithValue("p_SSN", tbSSN.Text);
                cmd.Parameters.AddWithValue("p_DOB", tbDOB.Text);
                cmd.Parameters.AddWithValue("p_Gender", tbGender.Text);
                cmd.Parameters.AddWithValue("p_EthnicAssociation", tbEthnicAssoication.Text);
                cmd.Parameters.AddWithValue("p_Religion", tbReligion.Text);
                cmd.Parameters.AddWithValue("p_MaritalStatus", tbMarital.Text);
                cmd.Parameters.AddWithValue("p_EmploymentStatus", tbEmploymentStatus.Text);
                cmd.Parameters.AddWithValue("p_DateofExpire", tbDateOfExpire.Text);
                cmd.Parameters.AddWithValue("p_Referral", tbReferral.Text);
                cmd.Parameters.AddWithValue("p_CurrentPrimaryHCPId", tbCurrentPrimaryHCPId.Text);
                cmd.Parameters.AddWithValue("p_Comments", tbComments.Text);
                cmd.Parameters.AddWithValue("p_DateEntered", tbDateEntered.Text);
                cmd.Parameters.AddWithValue("p_NextOfKinID", tbNOKID.Text);
                cmd.Parameters.AddWithValue("p_NextOfKinRelationshipToPatient", tbNOKRTP.Text);
                cmd.Parameters.AddWithValue("p_Deleted", checkDeleted.Checked ? 1 : 0);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error with executing query: " + ex.Message);
                return;
            }
            MessageBox.Show("Data Saved Successfully");

            Functions.InitPatientList(conn);
            foreach (Patient p in Functions.patients)
            {
                cbPatient.Items.Add(p.Info_Combo());
            }
            cbPatient.SelectedIndex = cbIndex;
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            if(mode == 1)
            {
                cbIndex = cbIndexCopy;
            }
            Functions.InitPatientList(conn);
            foreach (Patient p in Functions.patients)
            {
                cbPatient.Items.Add(p.Info_Combo());
            }
            cbPatient.SelectedIndex = cbIndex;
            UpdateTB(Functions.FindPIDBycbIndex(cbPatient.Items[cbIndex].ToString()));
            tbEnable(false);
            ModeChange(0);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
           
        }
    }
}
