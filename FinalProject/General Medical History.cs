﻿using MySql.Data.MySqlClient;
using Mysqlx.Prepare;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace FinalProject
{
    public partial class GeneralMedical : Form
    {
        //initiate connection variable, combobox patient variable, patient ID variable, and the patients login ID variable. 
        private MySqlConnection conn;
        int cbIndex;
        int PID;
        private int loginID;

        //initialize mode variable as 2, just to give it a place holder value. Will later be set to 1 or 0 by 
        //Add or Modify buttons.
        int mode = 2;

        public GeneralMedical()
        {
            InitializeComponent();
        }

        //Constructor that recieves the mysql connection, current combox index, and login ID.
        public GeneralMedical(MySqlConnection conn, int cbIndex, int loginID)
        {
            InitializeComponent();
            this.conn = conn;
            this.cbIndex = cbIndex;
            this.loginID = loginID;
        }

        private void GeneralMedical_Load(object sender, EventArgs e)
        {
            //Initialize combobox, fill it with patients.
            Functions.InitPatientList(conn);
            foreach (Patient p in Functions.patients)
            {
                patientListBox.Items.Add(p.Info_Combo());
            }

            //set the selected index and use said index to retrieve the corresponding patients ID
            patientListBox.SelectedIndex = cbIndex;
            PID = Functions.patients[cbIndex].PID;
        }

        //update patient information when selected patient is changed
        private void patientListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            PID = Functions.patients[patientListBox.SelectedIndex].PID;

            getGenMedHis();
            Functions.Logging(loginID, $"Open the general medical history record; PID: {PID}", conn);
        }

        //retrieve patient information for user
        public void getGenMedHis()
        {
            try
            {
                //use a stored procedure to get all values from all columns in table, put those values in fields, and then display those field values in textboxes for the user to see and interact with. 
                using (MySqlCommand command = new MySqlCommand("GetGMH", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@I_PID", PID);

                    command.Parameters.Add(new MySqlParameter("O_GeneralMedicalHistoryID", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
                    command.Parameters.Add(new MySqlParameter("O_PatientID", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
                    command.Parameters.Add(new MySqlParameter("O_MaritalStatus", MySqlDbType.VarChar, 100)).Direction = ParameterDirection.Output;
                    command.Parameters.Add(new MySqlParameter("O_Education", MySqlDbType.VarChar, 100)).Direction = ParameterDirection.Output;
                    command.Parameters.Add(new MySqlParameter("O_BehavioralHistory", MySqlDbType.VarChar, 100)).Direction = ParameterDirection.Output;
                    command.Parameters.Add(new MySqlParameter("O_Tobacco", MySqlDbType.VarChar, 100)).Direction = ParameterDirection.Output;
                    command.Parameters.Add(new MySqlParameter("O_TobaccoDuraton", MySqlDbType.VarChar, 100)).Direction = ParameterDirection.Output;
                    command.Parameters.Add(new MySqlParameter("O_TobaccoQuantity", MySqlDbType.VarChar, 100)).Direction = ParameterDirection.Output;
                    command.Parameters.Add(new MySqlParameter("O_Alcohol", MySqlDbType.VarChar, 100)).Direction = ParameterDirection.Output;
                    command.Parameters.Add(new MySqlParameter("O_AlcoholDuration", MySqlDbType.VarChar, 100)).Direction = ParameterDirection.Output;
                    command.Parameters.Add(new MySqlParameter("O_AlcoholQuantity", MySqlDbType.VarChar, 100)).Direction = ParameterDirection.Output;
                    command.Parameters.Add(new MySqlParameter("O_Drug", MySqlDbType.VarChar, 100)).Direction = ParameterDirection.Output;
                    command.Parameters.Add(new MySqlParameter("O_DrugType", MySqlDbType.VarChar, 100)).Direction = ParameterDirection.Output;
                    command.Parameters.Add(new MySqlParameter("O_DrugDuration", MySqlDbType.VarChar, 100)).Direction = ParameterDirection.Output;
                    command.Parameters.Add(new MySqlParameter("O_Dietary", MySqlDbType.VarChar, 100)).Direction = ParameterDirection.Output;
                    command.Parameters.Add(new MySqlParameter("O_BloodType", MySqlDbType.VarChar, 100)).Direction = ParameterDirection.Output;
                    command.Parameters.Add(new MySqlParameter("O_Rh", MySqlDbType.VarChar, 100)).Direction = ParameterDirection.Output;
                    command.Parameters.Add(new MySqlParameter("O_NumberOfChildren", MySqlDbType.Int32)).Direction = ParameterDirection.Output;
                    command.Parameters.Add(new MySqlParameter("O_LMPStatus", MySqlDbType.VarChar, 100)).Direction = ParameterDirection.Output;
                    command.Parameters.Add(new MySqlParameter("O_MensesMonthlyYes", MySqlDbType.Byte)).Direction = ParameterDirection.Output;
                    command.Parameters.Add(new MySqlParameter("O_MensesMonthlyNo", MySqlDbType.Byte)).Direction = ParameterDirection.Output;
                    command.Parameters.Add(new MySqlParameter("O_MensesFreq", MySqlDbType.VarChar, 100)).Direction = ParameterDirection.Output;
                    command.Parameters.Add(new MySqlParameter("O_MedicalHistoryNotes", MySqlDbType.VarChar, 100)).Direction = ParameterDirection.Output;
                    command.Parameters.Add(new MySqlParameter("O_HxObtainedBy", MySqlDbType.VarChar, 100)).Direction = ParameterDirection.Output;
                    command.Parameters.Add(new MySqlParameter("O_deleted", MySqlDbType.Int32)).Direction = ParameterDirection.Output;

                    command.ExecuteNonQuery();

                    int gmhID = Convert.ToInt32(command.Parameters["O_GeneralMedicalHistoryID"].Value);
                    int pid = Convert.ToInt32(command.Parameters["O_PatientID"].Value);
                    string maritalStatus = command.Parameters["O_MaritalStatus"].Value.ToString();
                    string education = command.Parameters["O_Education"].Value.ToString();
                    string behavioralHistory = command.Parameters["O_BehavioralHistory"].Value.ToString();
                    string tobacco = command.Parameters["O_Tobacco"].Value.ToString();
                    string tobaccoQuantity = command.Parameters["O_TobaccoQuantity"].Value.ToString();
                    string tobaccoDuration = command.Parameters["O_TobaccoDuraton"].Value.ToString();
                    string alcohol = command.Parameters["O_Alcohol"].Value.ToString();
                    string alcoholDuration = command.Parameters["O_AlcoholDuration"].Value.ToString();
                    string alcoholQuantity = command.Parameters["O_AlcoholQuantity"].Value.ToString();
                    string drug = command.Parameters["O_Drug"].Value.ToString();
                    string drugType = command.Parameters["O_DrugType"].Value.ToString();
                    string drugDuration = command.Parameters["O_DrugDuration"].Value.ToString();
                    string dietary = command.Parameters["O_Dietary"].Value.ToString();
                    string bloodType = command.Parameters["O_BloodType"].Value.ToString();
                    string rh = command.Parameters["O_Rh"].Value.ToString();
                    int numbOfChild = Convert.ToInt32(command.Parameters["O_NumberOfChildren"].Value);
                    string lmp = command.Parameters["O_LMPStatus"].Value.ToString();
                    int mmYes = Convert.ToInt32(command.Parameters["O_MensesMonthlyYes"].Value);
                    int mmNo = Convert.ToInt32(command.Parameters["O_MensesMonthlyNo"].Value);
                    string mensesFreq = command.Parameters["O_MensesFreq"].Value.ToString();
                    string mhNotes = command.Parameters["O_MedicalHistoryNotes"].Value.ToString();
                    string hx = command.Parameters["O_HxObtainedBy"].Value.ToString();
                    int deleted = Convert.ToInt32(command.Parameters["O_deleted"].Value);

                    genMedIDTxt.Text = Convert.ToString(gmhID);
                    patientIDTxt.Text = Convert.ToString(pid);
                    marTxt.Text = maritalStatus;
                    eduTxt.Text = education;
                    bhTxt.Text = behavioralHistory;
                    tobTxt.Text = tobacco;
                    tQuanTxt.Text = tobaccoQuantity;
                    tDurTxt.Text = tobaccoDuration;
                    alcTxt.Text = alcohol;
                    aQuanTxt.Text = alcoholQuantity;
                    aDurTxt.Text = alcoholDuration;
                    drugTxt.Text = drug;
                    dTypeTxt.Text = drugType;
                    dDurTxt.Text = drugDuration;
                    dietTxt.Text = dietary;
                    bloodTxt.Text = bloodType;
                    rhTxt.Text = rh;
                    noChildTxt.Text = Convert.ToString(numbOfChild);
                    lmpTxt.Text = lmp;
                    mensesYTxt.Text = (mmYes == 1) ? "Yes" : "No";
                    mensesNTxt.Text = (mmNo == 1) ? "Yes" : "No";
                    mensesFTxt.Text = mensesFreq;
                    medHisNoteTxt.Text = mhNotes;
                    hxTxt.Text = hx;
                    deletedTxt.Text = (deleted == 1) ? "Yes" : "No";
                }
            }
            catch (Exception ex)
            {
                Functions.Logging(loginID, $"Failed to bring data; PID: {PID}", conn);
                MessageBox.Show($"Could Not Obtain Data From Database. Error: {ex.Message}");
            }
        }


        //code for the buttons in the action menu. 
        //Code for the add button, which will set the mode to 0
        private void addBtn_Click(object sender, EventArgs e)
        {
            if (mode == 1)
            {
                MessageBox.Show("You are already in Modify mode!");
                addBtn.Enabled = true;
                addBtn.BackColor = Color.White;
                return;
            }

            mode = 0;
            Functions.DisableReadOnly(this);
            MessageBox.Show("You have entered Add mode. When adding a new entry, please ensure that all boxes have been filled.");
            addBtn.Enabled = false;
            addBtn.BackColor = System.Drawing.Color.Orange;
            Functions.Logging(loginID, "Try to add a new data into the General Medical History table", conn);
        }

        //Code for the modify button, which will set the mode to 1
        private void modBtn_Click(object sender, EventArgs e)
        {
            if (mode == 0)
            {
                MessageBox.Show("You are already in Add mode!");
                modBtn.Enabled = true;
                modBtn.BackColor = Color.White;
                return;
            }

            mode = 1;
            Functions.DisableReadOnly(this);
            MessageBox.Show("You have entered Modify mode.");
            modBtn.Enabled = false;
            modBtn.BackColor = Color.Orange;
            Functions.Logging(loginID, "Try to modify data of the General Medical History table", conn);
        }

        //Code for the save button, which will execute the stored procedures
        //to insert or update the database based on whether the mode was set to 0 or 1
        private void saveBtn_Click(object sender, EventArgs e)
        {
            int newGmhID = Convert.ToInt32(genMedIDTxt.Text);
            int newPid = Convert.ToInt32(patientIDTxt.Text);
            string newMaritalStatus = marTxt.Text;
            string newEducation = eduTxt.Text;
            string newBehavioralHistory = bhTxt.Text;
            string newTobacco = tobTxt.Text;
            string newTobaccoQuantity = tQuanTxt.Text;
            string newTobaccoDuraton = tDurTxt.Text;
            string newAlcohol = alcTxt.Text;
            string newAlcoholDuration = aDurTxt.Text;
            string newAlcoholQuantity = aQuanTxt.Text;
            string newDrug = drugTxt.Text;
            string newDrugType = dTypeTxt.Text;
            string newDrugDuration = dDurTxt.Text;
            string newDietary = dietTxt.Text;
            string newBloodType = bloodTxt.Text;
            string newRh = rhTxt.Text;
            int newNumbOfChild = Convert.ToInt32(noChildTxt.Text);
            string newLmp = lmpTxt.Text;
            int newMmYes = mensesYTxt.Text == "Yes" ? 1 : 0;
            int newMmNo = mensesNTxt.Text == "Yes" ? 1 : 0;
            string newMensesFreq = mensesFTxt.Text;
            string newMhNotes = medHisNoteTxt.Text;
            string NewHx = hxTxt.Text;
            int newDeleted = deletedTxt.Text == "Yes" ? 1 : 0;

            try
            {
                //check if mode is 0. if it was, then the user was in add mode and the insert stored procedure should be ran. 
                if (mode == 0)
                {
                    try
                    {
                        using (MySqlCommand command = new MySqlCommand("AddGMH", conn))
                        {
                            command.CommandType = CommandType.StoredProcedure;

                            command.Parameters.AddWithValue("@I_GeneralMedicalHistoryID", newGmhID);
                            command.Parameters.AddWithValue("@I_PID", newPid);
                            command.Parameters.AddWithValue("@I_MaritalStatus", newMaritalStatus);
                            command.Parameters.AddWithValue("@I_Education", newEducation);
                            command.Parameters.AddWithValue("@I_BehavioralHistory", newBehavioralHistory);
                            command.Parameters.AddWithValue("@I_Tobacco", newTobacco);
                            command.Parameters.AddWithValue("@I_TobaccoDuraton", newTobaccoDuraton);
                            command.Parameters.AddWithValue("@I_TobaccoQuantity", newTobaccoQuantity);
                            command.Parameters.AddWithValue("@I_Alcohol", newAlcohol);
                            command.Parameters.AddWithValue("@I_AlcoholDuration", newAlcoholDuration);
                            command.Parameters.AddWithValue("@I_AlcoholQuantity", newAlcoholQuantity);
                            command.Parameters.AddWithValue("@I_Drug", newDrug);
                            command.Parameters.AddWithValue("@I_DrugType", newDrugType);
                            command.Parameters.AddWithValue("@I_DrugDuration", newDrugDuration);
                            command.Parameters.AddWithValue("@I_Dietary", newDietary);
                            command.Parameters.AddWithValue("@I_BloodType", newBloodType);
                            command.Parameters.AddWithValue("@I_Rh", newRh);
                            command.Parameters.AddWithValue("@I_NumberOfChildren", newNumbOfChild);
                            command.Parameters.AddWithValue("@I_LMPStatus", newLmp);
                            command.Parameters.AddWithValue("@I_MensesMonthlyYes", newMmYes);
                            command.Parameters.AddWithValue("@I_MensesMonthlyNo", newMmNo);
                            command.Parameters.AddWithValue("@I_MensesFreq", newMensesFreq);
                            command.Parameters.AddWithValue("@I_MedicalHistoryNotes", newMhNotes);
                            command.Parameters.AddWithValue("@I_HxObtainedBy", NewHx);
                            command.Parameters.AddWithValue("@I_deleted", newDeleted);

                            int result = command.ExecuteNonQuery();

                            if (result > 0)
                            {
                                MessageBox.Show("New General Medical History added!");
                            }
                            else
                            {
                                MessageBox.Show("Operation Failed!");
                            }

                            addBtn.Enabled = true;
                            addBtn.BackColor = Color.White;

                            getGenMedHis();
                        }
                    }
                    catch (Exception ex)
                    {
                        Functions.Logging(loginID, "Failed to update the General Medical History table", conn);
                        MessageBox.Show($"ERROR ADDING DATA TO DATABASE.\n{ex.Message}");
                    }
                }
                
                //check if mode is set to 1. If it was, then the user was in modify mode and a update stored procedure should be ran.  
                if (mode == 1)
                {
                    try
                    {
                        using (MySqlCommand command = new MySqlCommand("UpdateGMH", conn))
                        {
                            command.CommandType = CommandType.StoredProcedure;

                            command.Parameters.AddWithValue("@I_GeneralMedicalHistoryID", newGmhID);
                            command.Parameters.AddWithValue("@I_PID", newPid);
                            command.Parameters.AddWithValue("@I_MaritalStatus", newMaritalStatus);
                            command.Parameters.AddWithValue("@I_Education", newEducation);
                            command.Parameters.AddWithValue("@I_BehavioralHistory", newBehavioralHistory);
                            command.Parameters.AddWithValue("@I_Tobacco", newTobacco);
                            command.Parameters.AddWithValue("@I_TobaccoDuraton", newTobaccoDuraton);
                            command.Parameters.AddWithValue("@I_TobaccoQuantity", newTobaccoQuantity);
                            command.Parameters.AddWithValue("@I_Alcohol", newAlcohol);
                            command.Parameters.AddWithValue("@I_AlcoholDuration", newAlcoholDuration);
                            command.Parameters.AddWithValue("@I_AlcoholQuantity", newAlcoholQuantity);
                            command.Parameters.AddWithValue("@I_Drug", newDrug);
                            command.Parameters.AddWithValue("@I_DrugType", newDrugType);
                            command.Parameters.AddWithValue("@I_DrugDuration", newDrugDuration);
                            command.Parameters.AddWithValue("@I_Dietary", newDietary);
                            command.Parameters.AddWithValue("@I_BloodType", newBloodType);
                            command.Parameters.AddWithValue("@I_Rh", newRh);
                            command.Parameters.AddWithValue("@I_NumberOfChildren", newNumbOfChild);
                            command.Parameters.AddWithValue("@I_LMPStatus", newLmp);
                            command.Parameters.AddWithValue("@I_MensesMonthlyYes", newMmYes);
                            command.Parameters.AddWithValue("@I_MensesMonthlyNo", newMmNo);
                            command.Parameters.AddWithValue("@I_MensesFreq", newMensesFreq);
                            command.Parameters.AddWithValue("@I_MedicalHistoryNotes", newMhNotes);
                            command.Parameters.AddWithValue("@I_HxObtainedBy", NewHx);
                            command.Parameters.AddWithValue("@I_deleted", newDeleted);

                            int result = command.ExecuteNonQuery();

                            if (result > 0)
                            {
                                MessageBox.Show("General Medical History updated!");
                            }
                            else
                            {
                                MessageBox.Show("Operation Failed!");
                            }

                            modBtn.Enabled = true;
                            modBtn.BackColor = Color.White;

                            getGenMedHis();
                        }
                    }
                    catch (Exception ex)
                    {
                        Functions.Logging(loginID, "Failed to update the General Medical History table", conn);
                        MessageBox.Show($"ERROR UPDATING DATABASE\nERROR: {ex.Message}");
                    }
                }
            }
            catch (Exception ex)
            {
                Functions.Logging(loginID, "Failed to update the General Medical History table", conn);
                MessageBox.Show($"ERROR EXECUTING STORED PROCEDURES!\n{ex.Message}");
            }
            Functions.Logging(loginID, $"Update the General Medical History table; GMHID: {genMedIDTxt.Text}", conn);
        }

        //Code for the undo button which will reset the text in the textboxes
        private void undoBtn_Click(object sender, EventArgs e)
        {
            Functions.ColorClick(undoBtn, Color.Orange);
            getGenMedHis();
            Functions.Logging(loginID, "Undo the changes", conn);
        }

        //Code for the delete button, which will set the deleted value of the currently viewed patient to 1/true
        private void delBtn_Click(object sender, EventArgs e)
        {
            Functions.ColorClick(delBtn, Color.Orange);

            try
            {
                using (MySqlCommand command = new MySqlCommand("DeleteGMH", conn))
                {
                    string oldPID = patientIDTxt.Text;
                    string oldGmhID = genMedIDTxt.Text;

                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@D_GmhID", genMedIDTxt.Text);

                    int result = command.ExecuteNonQuery();

                    if (result > 0)
                    {
                        MessageBox.Show($"Patient {oldPID} with General Medical History ID {oldGmhID} has had their General Medical History record deleted.");
                        Functions.Logging(loginID, $"Delete in the General Medical History table; GMHID: {oldGmhID}", conn);
                    }
                    else
                    {
                        Functions.Logging(loginID, $"Failed to delete in the General Medical History table; GMHID: {oldGmhID}", conn);
                        MessageBox.Show("Unable to delete record.");
                    }

                    getGenMedHis();
                }
            }
            catch (Exception ex)
            {
                Functions.Logging(loginID, $"Failed to delete in the General Medical History table; GMHID: {genMedIDTxt.Text}", conn);
                MessageBox.Show($"ERROR DELETING DATA FROM DATABASE.\nERROR: {ex.Message}");
            }
        }

        //Navigation Methods. These will be copy/pasted to all forms so the user can move between them. 
        //have conn and cbIndex be constructor arguements for each new form created so the forms are created with these arguments passed into them.
        private void naviLogin_Click(object sender, EventArgs e)
        {
            Functions.Logging(loginID, "Move To Login Form", conn);
            Login loginForm = new Login(conn);
            Hide();
            loginForm.ShowDialog();
            Close();
        }

        private void naviSelectPatient_Click(object sender, EventArgs e)
        {
            Functions.Logging(loginID, "Move To Select Patient Form", conn);
            SelectPatient selectPatientForm = new SelectPatient(conn, cbIndex, loginID);
            Hide();
            selectPatientForm.ShowDialog();
            Close();
        }

        private void naviPatientDemo_Click(object sender, EventArgs e)
        {
            Functions.Logging(loginID, "Move To Patient Demographics Form", conn);
            PatientsDemographics patientDemographicsForm = new PatientsDemographics(conn, cbIndex, loginID);
            Hide();
            patientDemographicsForm.ShowDialog();
            Close();
        }

        private void naviAllergyHis_Click(object sender, EventArgs e)
        {
            Functions.Logging(loginID, "Move To Allergy History Form", conn);
            AllergyHistory allergyHistoryForm = new AllergyHistory(conn, cbIndex, loginID);
            Hide();
            allergyHistoryForm.ShowDialog();
            Close();
        }

        private void naviFamilyHis_Click(object sender, EventArgs e)
        {
            Functions.Logging(loginID, "Move To Family History Form", conn);
            Family_History familyHistoryForm = new Family_History(conn, cbIndex, loginID);
            Functions.EnableReadOnly(familyHistoryForm);
            Hide();
            familyHistoryForm.ShowDialog();
            Close();
        }
    }
}