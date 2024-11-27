using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.X509;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject
{
    public partial class SelectPatient : Form
    {
        private int cbIndex;
        MySqlConnection conn;

        public SelectPatient()
        {
            InitializeComponent();
            conn = Functions.ConnectDB();
            cbIndex = 0;
        }

        public SelectPatient(MySqlConnection conn, int cbIndex)
        {
            InitializeComponent();
            this.conn = conn;
            this.cbIndex = cbIndex;
        }

        private void SelectPatient_Load(object sender, EventArgs e)
        {
            Functions.InitPatientList(conn);
            foreach(Patient p in Functions.patients)
            {
                cbPatient.Items.Add(p.Info_Combo());
            }
            cbPatient.SelectedIndex = cbIndex;
        }

        private void cbPatient_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbIndex = cbPatient.SelectedIndex;
        }

        // Navigation
        private void btnToPatientDemo_Click(object sender, EventArgs e)
        {
            PatientsDemographics pd = new PatientsDemographics(conn, cbIndex);
            pd.Show();
        }
        private void btnToAllergyHistory_Click(object sender, EventArgs e)
        {

        }

        // Action Menu
        private void button1_Click(object sender, EventArgs e) // Search Command
        {
          
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        
    }
}
