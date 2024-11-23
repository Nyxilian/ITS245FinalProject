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
    public partial class GeneralMedical : Form
    {
        private MySqlConnection conn;

        public GeneralMedical()
        {
            InitializeComponent();
        }


        private void GeneralMedical_Load(object sender, EventArgs e)
        { 
            
        }

        //Navigation Methods. These will be copy/pasted to all forms so the user can move between them. 
        private void naviLogin_Click(object sender, EventArgs e)
        {
            Login loginForm = new Login();
            this.Hide();
            loginForm.ShowDialog();
        }

        private void naviSelectPatient_Click(object sender, EventArgs e)
        {
            SelectPatient selectPatientForm = new SelectPatient();
            this.Hide();
            selectPatientForm.ShowDialog();
        }

        private void naviPatientDemo_Click(object sender, EventArgs e)
        {
            PatientsDemographics patientDemographicsForm = new PatientsDemographics();
            this.Hide();
            patientDemographicsForm.ShowDialog();
        }

        private void naviGenMed_Click(object sender, EventArgs e)
        {
            GeneralMedical generalMedicalForm = new GeneralMedical();
            this.Hide();
            generalMedicalForm.Show();
        }

        private void naviAllergyHis_Click(object sender, EventArgs e)
        {
            AllergyHistory allergyHistoryForm = new AllergyHistory();
            this.Hide();
            allergyHistoryForm.Show();
        }

        private void naviFamilyHis_Click(object sender, EventArgs e)
        {
            Family_History familyHistoryForm = new Family_History();
            this.Hide();
            familyHistoryForm.Show();
        }
    }
}
