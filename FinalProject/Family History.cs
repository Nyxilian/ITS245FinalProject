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
        }

        private void naviLogin_Click(object sender, EventArgs e)
        {

        }
    }
}
