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
        MySqlConnection conn;
        public SelectPatient()
        {
            InitializeComponent();
        }

        public SelectPatient(MySqlConnection conn)
        {
            this.conn = conn;
        }


        private void SelectPatient_Load(object sender, EventArgs e)
        {
            conn = Functions.ConnectDB();
            Functions.InitPatientList(conn);
            foreach(Patient p in Functions.patients)
            {
                cbPatient.Items.Add(p.Info_Combo());
            }
        }

        // Navigation
        private void btnToPatientDemo_Click(object sender, EventArgs e)
        {
            
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
