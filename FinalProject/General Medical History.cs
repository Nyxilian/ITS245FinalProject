﻿using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace FinalProject
{
    public partial class GeneralMedical : Form
    {
        private MySqlConnection conn;
        int cbIndex;
        int PID;

        int mode = 2;

        public GeneralMedical(MySqlConnection conn, int cbIndex)
        {
            InitializeComponent();
            this.conn = conn;
            this.cbIndex = cbIndex;
        }

        private void GeneralMedical_Load(object sender, EventArgs e)
        {
            //Connect form to database
            conn = Functions.ConnectDB();

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

        private void patientListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            PID = Functions.patients[patientListBox.SelectedIndex].PID;

            getGenMedHis();
        }

        public void getGenMedHis()
        {
            MessageBox.Show($"{PID}");

            try
            {
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
                    string alcoholDuration = command.Parameters["O_AlcoholDuration"].Value.ToString() ;
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
                MessageBox.Show($"Could Not Obtain Data From Database. Error: {ex.Message}");
            }
        }


        //code for the buttons in the action menu. 
        //Code for the add button, which will set the mode to 0
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

        //Code for the modify button, which will set the mode to 1
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
            modBtn.BackColor = Color.Orange;
        }

        //Code for the save button, which will execute the stored procedures
        //to insert or update the database based on whether the mode was set to 0 or 1
        private void saveBtn_Click(object sender, EventArgs e)
        {
            int newGmhID = Convert.ToInt32(genMedIDTxt.Text);
            int newPid = Convert.ToInt32(patientIDTxt.Text);
            string newMaritalStatus = marTxt.Text;
            string newEducation = eduTxt.Text;
            string newbehavioralHistory = bhTxt.Text;
            string newTobacco = tobTxt.Text;
            string newTobaccoQuantity = tQuanTxt.Text;
            string newTobaccoDuration = tDurTxt.Text;
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
                if (mode == 0)
                {
                    
                }

                if (mode == 1)
                {

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show($"ERROR EXECUTING STORED PROCEDURE!\n{ex.Message}");
            }
        }

        //Code for the undo button which will reset the text in the textboxes
        private void undoBtn_Click(object sender, EventArgs e)
        {
            Functions.ColorClick(undoBtn, Color.Orange);
        }

        //Code for the delete button, which will set the deleted value of the currently viewed patient to 1/true
        private void delBtn_Click(object sender, EventArgs e)
        {

        }

        //Navigation Methods. These will be copy/pasted to all forms so the user can move between them. 
        private void naviLogin_Click(object sender, EventArgs e)
        {
            Login loginForm = new Login(conn);
            Hide();
            loginForm.ShowDialog();
            Close();
        }

        private void naviSelectPatient_Click(object sender, EventArgs e)
        {
            SelectPatient selectPatientForm = new SelectPatient(conn, cbIndex);
            Hide();
            selectPatientForm.ShowDialog();
            Close();
        }

        private void naviPatientDemo_Click(object sender, EventArgs e)
        {
            PatientsDemographics patientDemographicsForm = new PatientsDemographics(conn, cbIndex);
            Hide();
            patientDemographicsForm.ShowDialog();
            Close();
        }

        private void naviGenMed_Click(object sender, EventArgs e)
        {
            GeneralMedical generalMedicalForm = new GeneralMedical(conn, cbIndex);
            Functions.EnableReadOnly(generalMedicalForm);
            Hide();
            generalMedicalForm.ShowDialog();
            Close();
        }

        private void naviAllergyHis_Click(object sender, EventArgs e)
        {
            AllergyHistory allergyHistoryForm = new AllergyHistory(conn, cbIndex);
            Hide();
            allergyHistoryForm.ShowDialog();
            Close();
        }

        private void naviFamilyHis_Click(object sender, EventArgs e)
        {
            Family_History familyHistoryForm = new Family_History(conn, cbIndex);
            Functions.EnableReadOnly(familyHistoryForm);
            Hide();
            familyHistoryForm.Show();
            Close();
        }
    }
}