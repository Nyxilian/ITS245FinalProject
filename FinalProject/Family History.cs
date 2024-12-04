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
        private int mode = 2;

        public Family_History()
        {
            InitializeComponent();
        }

        public Family_History(MySqlConnection conn, int cbIndex)
        {
            InitializeComponent();
            Functions.EnableReadOnly(this);
            this.cbIndex = cbIndex;
            this.conn = conn;
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
            PopulateShowFH();
        }

        private void PopulateShowFH()
        {
            //Initialize datagridview. Hide all columns that aren't FamilyID, Relation, and Major Disorder
            string sqlQuery = "SELECT * FROM familyhistory";

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
        }

        //Enter Add mode. This will change the mode variable's value to 0, disable read only mode, and display a tutorial messagebox to the user
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
                        }
                        else
                        {
                            MessageBox.Show("Operation Failed!");
                        }

                        addBtn.Enabled = true;
                        addBtn.BackColor = System.Drawing.Color.White;

                        PopulateShowFH();

                        return;
                    }
                }
                catch (Exception ex)
                {
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
                        }
                        else
                        {
                            MessageBox.Show("Operation Failed!");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error With Stored Procedure. Error: {ex.Message}");
                }
            }

            modBtn.Enabled = true;
            modBtn.BackColor = System.Drawing.Color.White;

            PopulateShowFH();

            return;
        }

        private void undoBtn_Click(object sender, EventArgs e)
        {
            Functions.ColorClick(undoBtn, Color.Orange);

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
                    }
                    else
                    {
                        MessageBox.Show("Operation Failed");
                    }

                    PopulateShowFH();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Could Not Delete Record! Error: {ex.Message}");
            }
        }

        // Navigation functions to allow user to change forms. The form objects have parameters that pass the current patient index and the SQL connection to the next form. 
        private void naviLogin_Click(object sender, EventArgs e)
        {
            Login login = new Login(conn);
            Hide();
            login.ShowDialog();
            Close();
        }

        private void naviSelectPatient_Click(object sender, EventArgs e)
        {
            SelectPatient selectpatient = new SelectPatient(conn, cbIndex);
            Hide();
            selectpatient.ShowDialog();
            Close();
        }

        private void naviPatientDemo_Click(object sender, EventArgs e)
        {
            PatientsDemographics patientsdemographics = new PatientsDemographics(conn, cbIndex);
            Hide();
            patientsdemographics.ShowDialog();
            Close();
        }

        private void naviGenMed_Click(object sender, EventArgs e)
        {
            GeneralMedical generalMedical = new GeneralMedical(conn, cbIndex);
            Functions.EnableReadOnly(generalMedical);
            Hide();
            generalMedical.ShowDialog();
            Close();
        }

        private void naviAllergyHis_Click(object sender, EventArgs e)
        {
            AllergyHistory allergyHistory = new AllergyHistory(conn, cbIndex);
            Hide();
            allergyHistory.ShowDialog();
            Close();
        }

        private void naviFamilyHis_Click(object sender, EventArgs e)
        {
            Family_History familyHistory = new Family_History(conn, cbIndex);
            Functions.EnableReadOnly(familyHistory);
            Hide();
            familyHistory.ShowDialog();
            Close();
        }

        private void patientListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
