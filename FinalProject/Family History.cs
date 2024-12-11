using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Configuration;
using System.Globalization;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Math.Field;

namespace FinalProject
{
    public partial class Family_History : Form
    {
        private MySqlConnection conn;
        private int cbIndex;
        private int loginID;
        private int mode = 2;

        public Family_History()
        {
            InitializeComponent();
        }

        public Family_History(MySqlConnection conn, int cbIndex, int loginID)
        {
            InitializeComponent();
            Functions.EnableReadOnly(this);
            this.cbIndex = cbIndex;
            this.conn = conn;
            this.loginID = loginID;
        }

        private void Family_History_Load(object sender, EventArgs e)
        {
            //Initialize combobox and fill combobox with patients while preserving index.
            Functions.InitPatientList(conn);
            foreach (Patient p in Functions.patients)
            {
                patientListBox.Items.Add(p.Info_Combo());
            }
            patientListBox.SelectedIndex = cbIndex;

            //Populate DataGridView
            PopulateShowFH(Functions.patients[cbIndex].PID);
        }

        private void PopulateShowFH(int pid)
        {
            //Initialize datagridview. Hide all columns that aren't FamilyID, Relation, and Major Disorder
            string sqlQuery = $"SELECT * FROM familyhistory WHERE PatientID = {pid}";

            try
            {
                DataTable dt = Functions.LoadTable(sqlQuery, conn);
                showFH.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Could not obtain data from database. Error: {ex.Message}");
            }

            foreach (DataGridViewColumn column in showFH.Columns)
            {
                if (column.Name != "FamilyID" && column.Name != "Relation" && column.Name != "MajorDisorder")
                {
                    column.Visible = false;
                }
            }
        }

        private void patientListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //set cbIndex the index of the new selected patient so that patients information is dispalyed in the textboxes. 
            cbIndex = patientListBox.SelectedIndex;
            PopulateShowFH(Functions.patients[cbIndex].PID);
        }

        private void showFH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Initialize index for datagrid. Index is set to whatever row the user clicks. 
            int i = e.RowIndex;

            // display all information in the cells of the row the index is currently on in the corresponding textboxes
            string familyID = showFH.Rows[i].Cells["FamilyID"].Value.ToString();
            familyIDText.Text = $"{familyID}";
            string patientID = showFH.Rows[i].Cells["PatientID"].Value.ToString();
            patientIDText.Text = $"{patientID}";
            string name = showFH.Rows[i].Cells["Name"].Value.ToString();
            nameText.Text = $"{name}";
            string relation = showFH.Rows[i].Cells["Relation"].Value.ToString();
            relationText.Text = $"{relation}";
            int alive = Convert.ToInt32(showFH.Rows[i].Cells["Alive"].Value);
            aliveText.Text = alive == 1 ? "True" : "False";
            int lwp = Convert.ToInt32(showFH.Rows[i].Cells["Lives With Patient"].Value);
            livesWithPatientText.Text = lwp == 1 ? "True" : "False";
            string majorDisorder = showFH.Rows[i].Cells["MajorDisorder"].Value.ToString();
            majorDisorderText.Text = $"{majorDisorder}";
            string sTypeDisorder = showFH.Rows[i].Cells["SpecificTypeDisorder"].Value.ToString();
            sTypeDisorderText.Text = $"{sTypeDisorder}";
            int deleted = Convert.ToInt32(showFH.Rows[i].Cells["deleted"].Value);
            deletedText.Text = deleted == 1 ? "True" : "False";

            Functions.Logging(loginID, $"Open the Family History record; FID: {familyID}", conn);
        }

        //Enter Add mode. This will change the mode variable's value to 0, disable read only mode, and display a tutorial messagebox to the user.
        private void addBtn_Click(object sender, EventArgs e)
        {
            if (mode == 1)
            {
                MessageBox.Show("You are already in modify mode!");
                addBtn.Enabled = true;
                addBtn.BackColor = Color.White;
                return;
            }

            mode = 0;
            Functions.DisableReadOnly(this);
            MessageBox.Show("You have entered ADD mode. When adding a new entry, please ensure that all boxes have been filled.");
            addBtn.Enabled = false;
            addBtn.BackColor = System.Drawing.Color.Orange;
            Functions.Logging(loginID, "Try to add a new data into the Family History table", conn);
        }

        //Enter Modify mode. This will set the mode variable's value to 0, disable read only mode, and dispaly a tutorial messagebox to the user. 
        private void modBtn_Click(object sender, EventArgs e)
        {
            if (mode == 0)
            {
                MessageBox.Show("You are already in add mode!");
                modBtn.Enabled = true;
                modBtn.BackColor = Color.White;
                return;
            }

            mode = 1;
            Functions.DisableReadOnly(this);
            MessageBox.Show("You have entered Modify mode.");
            modBtn.Enabled = false;
            modBtn.BackColor = System.Drawing.Color.Orange;
            Functions.Logging(loginID, "Try to modify data of the Family History table", conn);
        }

        //Saves changes made in the textboxes to the SQL database. If mode=0, the data in the entry boxes will be used in a stored procedure to insert a new customer.
        //If mode = 1, the data will be sent to 
        private void saveBtn_Click(object sender, EventArgs e)
        {
            //Saves additions to family history table via AddFamily stored procedure. 
            if (mode == 0)
            {
                string newFamilyID = familyIDText.Text;
                string newPatientID = patientIDText.Text;
                string newName = nameText.Text;
                string newRelation = relationText.Text;
                string newAlive = aliveText.Text.ToLower() == "True" ? "1" : "0";
                string newLwp = livesWithPatientText.Text.ToLower() == "True" ? "1" : "0";
                string newMajorDis = majorDisorderText.Text;
                string newSpType = sTypeDisorderText.Text;
                string newDeleted = deletedText.Text.ToLower() == "True" ? "1" : "0";

                try
                {
                    using (MySqlCommand command = new MySqlCommand("AddFamily", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@inFamilyID", Convert.ToInt32(newFamilyID));
                        command.Parameters.AddWithValue("@inPatientID", Convert.ToInt32(newPatientID));
                        command.Parameters.AddWithValue("@inName", newName);
                        command.Parameters.AddWithValue("@inRelation", newRelation);
                        command.Parameters.AddWithValue("@inAlive", Convert.ToInt32(newAlive));
                        command.Parameters.AddWithValue("@inLWP", Convert.ToInt32(newLwp));
                        command.Parameters.AddWithValue("@inMajorDis", newMajorDis);
                        command.Parameters.AddWithValue("@inSpecificType", newSpType);
                        command.Parameters.AddWithValue("@inDeleted", Convert.ToInt32(newDeleted));

                        int result = command.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("New Family History Added!");
                            Functions.Logging(loginID, $"Update the Family History table; FID : {newFamilyID}", conn);
                        }
                        else
                        {
                            MessageBox.Show("Operation Failed!");
                            Functions.Logging(loginID, "Failed to update the Family History table", conn);
                        }

                        addBtn.Enabled = true;
                        addBtn.BackColor = System.Drawing.Color.White;

                        PopulateShowFH(Functions.patients[0].PID);

                        return;
                    }
                }
                catch (Exception ex)
                {
                    Functions.Logging(loginID, "Failed to update the Family History table", conn);
                    MessageBox.Show($"ERROR WITH STORED PROCEDURE. PLEASE CONTACT IT DEPARTMENT!\nERROR:{ex.Message.ToUpper()}");
                }
            }

            //Saves updates to mysql via the UpdateFamily stored procedure. 
            if (mode == 1)
            {
                string newFamilyID = familyIDText.Text;
                string newPatientID = patientIDText.Text;
                string newName = nameText.Text;
                string newRelation = relationText.Text;
                string newAlive = aliveText.Text.ToLower() == "True" ? "1" : "0";
                string newLwp = livesWithPatientText.Text.ToLower() == "True" ? "1" : "0";
                string newMajorDis = majorDisorderText.Text;
                string newSpType = sTypeDisorderText.Text;
                string newDeleted = deletedText.Text.ToLower() == "True" ? "1" : "0";

                try
                {
                    using (MySqlCommand command = new MySqlCommand("UpdateFamily", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@inFamilyID", Convert.ToInt32(newFamilyID));
                        command.Parameters.AddWithValue("@inPatientID", Convert.ToInt32(newPatientID));
                        command.Parameters.AddWithValue("@inName", newName);
                        command.Parameters.AddWithValue("@inRelation", newRelation);
                        command.Parameters.AddWithValue("@inAlive", Convert.ToInt32(newAlive));
                        command.Parameters.AddWithValue("@inLWP", Convert.ToInt32(newLwp));
                        command.Parameters.AddWithValue("@inMajorDis", newMajorDis);
                        command.Parameters.AddWithValue("@inSpecificType", newSpType);
                        command.Parameters.AddWithValue("@inDeleted", Convert.ToInt32(newDeleted));

                        int result = command.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("Successfuly Updated Family History!");
                            Functions.Logging(loginID, $"Update the Family History table; FID : {newFamilyID}", conn);
                        }
                        else
                        {
                            MessageBox.Show("Operation Failed!");
                            Functions.Logging(loginID, "Failed to update the Family History table", conn);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Functions.Logging(loginID, "Failed to update the Family History table", conn);
                    MessageBox.Show($"Error With Stored Procedure. Error: {ex.Message}");
                }
            }

            modBtn.Enabled = true;
            modBtn.BackColor = System.Drawing.Color.White;

            PopulateShowFH(Functions.patients[0].PID);

            return;
        }

        private void undoBtn_Click(object sender, EventArgs e)
        {
            Functions.ColorClick(undoBtn, Color.Orange);

            //have an index mapped to the currently selected row in the datagridview.
            //This allows the correct data to be brought back into the textboxes, undoing any changes the user made to the patient's information
            int i = showFH.CurrentRow.Index;

            string familyID = showFH.Rows[i].Cells["FamilyID"].Value.ToString();
            familyIDText.Text = $"{familyID}";
            string patientID = showFH.Rows[i].Cells["PatientID"].Value.ToString();
            patientIDText.Text = $"{patientID}";
            string name = showFH.Rows[i].Cells["Name"].Value.ToString();
            nameText.Text = $"{name}";
            string relation = showFH.Rows[i].Cells["Relation"].Value.ToString();
            relationText.Text = $"{relation}";
            int alive = Convert.ToInt32(showFH.Rows[i].Cells["Alive"].Value);
            aliveText.Text = alive == 1 ? "True" : "False";
            int lwp = Convert.ToInt32(showFH.Rows[i].Cells["Lives With Patient"].Value);
            livesWithPatientText.Text = lwp == 1 ? "True" : "False";
            string majorDisorder = showFH.Rows[i].Cells["MajorDisorder"].Value.ToString();
            majorDisorderText.Text = $"{majorDisorder}";
            string sTypeDisorder = showFH.Rows[i].Cells["SpecificTypeDisorder"].Value.ToString();
            sTypeDisorderText.Text = $"{sTypeDisorder}";
            int deleted = Convert.ToInt32(showFH.Rows[i].Cells["deleted"].Value);
            deletedText.Text = deleted == 1 ? "True" : "False";

            Functions.Logging(loginID, "Undo the changes", conn);
        }

        private void delBtn_Click(object sender, EventArgs e)
        {
            try
            {
                using (MySqlCommand command = new MySqlCommand("DeleteFamily", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@inFamilyID", Convert.ToInt32(familyIDText.Text));

                    int result = command.ExecuteNonQuery();

                    if (result > 0)
                    {
                        MessageBox.Show("Entry Has Been Marked For Deletion.");
                        Functions.Logging(loginID, $"Delete in the Family History table; AID: {familyIDText.Text}", conn);
                    }
                    else
                    {
                        MessageBox.Show("Operation Failed");
                        Functions.Logging(loginID, $"Failed to delete in the Family History table; AID: {familyIDText.Text}", conn);
                    }

                    PopulateShowFH(Functions.patients[0].PID);
                }
            }
            catch (Exception ex)
            {
                Functions.Logging(loginID, $"Delete in the Family History table; AID: {familyIDText.Text}", conn);
                MessageBox.Show($"Could Not Delete Record! Error: {ex.Message}");
            }
        }

        // Navigation functions to allow user to change forms. The form objects have parameters that pass the current patient index, loginID, and SQL connection to the next form. 
        private void naviLogin_Click(object sender, EventArgs e)
        {
            Functions.Logging(loginID, "Move To Login Form", conn);
            Login login = new Login(conn);
            Hide();
            login.ShowDialog();
            Close();
        }

        private void naviSelectPatient_Click(object sender, EventArgs e)
        {
            Functions.Logging(loginID, "Move To Select Patient Form", conn);
            SelectPatient selectpatient = new SelectPatient(conn, cbIndex, loginID);
            Hide();
            selectpatient.ShowDialog();
            Close();
        }

        private void naviPatientDemo_Click(object sender, EventArgs e)
        {
            Functions.Logging(loginID, "Move To Patient Demographics Form", conn);
            PatientsDemographics patientsdemographics = new PatientsDemographics(conn, cbIndex, loginID);
            Hide();
            patientsdemographics.ShowDialog();
            Close();
        }

        private void naviGenMed_Click(object sender, EventArgs e)
        {
            Functions.Logging(loginID, "Move To General Medical History Form", conn);
            GeneralMedical generalMedical = new GeneralMedical(conn, cbIndex, loginID);
            Functions.EnableReadOnly(generalMedical);
            Hide();
            generalMedical.ShowDialog();
            Close();
        }

        private void naviAllergyHis_Click(object sender, EventArgs e)
        {
            Functions.Logging(loginID, "Move To Allergy History Form", conn);
            AllergyHistory allergyHistory = new AllergyHistory(conn, cbIndex, loginID);
            Hide();
            allergyHistory.ShowDialog();
            Close();
        }

        
    }
}
