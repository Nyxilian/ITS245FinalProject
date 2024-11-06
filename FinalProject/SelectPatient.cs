using MySql.Data.MySqlClient;
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
        private void SelectPatient_Load(object sender, EventArgs e)
        {
            conn = Functions.ConnectDB();
            string query = "SELECT * FROM its245final.patientdemographics;";
            dataGridView1.DataSource = Functions.LoadTable(query, conn);
        }
    }
}
