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

namespace FinalProject
{
    public partial class Family_History : Form
    {
        private MySqlConnection conn;
        
        public Family_History()
        {
            InitializeComponent();
        }

        private void Family_History_Load(object sender, EventArgs e)
        {
            conn = Functions.ConnectDB();
            string sqlQuery = "SELECT * FROM familyhistory";

            try
            {
                MySqlDataAdapter ad = Functions.LoadTable(sqlQuery, conn);
                DataTable dt = new DataTable();
                ad.Fill(dt);
                showFH.DataSource = dt;
            }

            catch (Exception ex)
            {
                MessageBox.Show("Could not obtain data from database.");
            }

            familyIDText.Text = showFH.Rows[0].Cells["FamilyID"].Value.ToString();
            patientIDText.Text = showFH.Rows[0].Cells["PatientID"].Value.ToString();
            nameText.Text = showFH.Rows[0].Cells["Name"].Value.ToString();
            relationText.Text = showFH.Rows[0].Cells["Relation"].Value.ToString();
            aliveText.Text = showFH.Rows[0].Cells["Alive"].Value.ToString();
            livesWithPatientText.Text = showFH.Rows[0].Cells["Lives with patient"].Value.ToString();
            majorDisorderText.Text = showFH.Rows[0].Cells["MajorDisorder"].Value.ToString();
            sTypeDisorderText.Text = showFH.Rows[0].Cells["SpecificTypeDisorder"].Value.ToString();
        }


        private void naviLogin_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            this.Hide();
            login.Show();
        }

        private void naviSelectPatient_Click(object sender, EventArgs e)
        {
            SelectPatient selectpatient = new SelectPatient();
            this.Hide();
            selectpatient.Show();
        }

        private void naviPatientDemo_Click(object sender, EventArgs e)
        {
            PatientsDemographics patientsdemographics = new PatientsDemographics(conn, 0);
            this.Hide();
            patientsdemographics.Show();
        }

        private void naviGenMed_Click(object sender, EventArgs e)
        {
            GeneralMedical generalMedical = new GeneralMedical();
            this.Hide();
            generalMedical.Show();
        }

        private void naviAllergyHis_Click(object sender, EventArgs e)
        { 
            AllergyHistory allergyHistory= new AllergyHistory();
            this.Hide();
            allergyHistory.Show();
        }

        private void naviFamilyHis_Click(object sender, EventArgs e)
        {
            Family_History familyHistory = new Family_History();
            this.Hide();
            familyHistory.Show();
        }

        private void familyIDText_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
