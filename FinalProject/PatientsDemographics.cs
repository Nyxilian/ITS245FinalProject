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
    public partial class PatientsDemographics : Form
    {
        private MySqlConnection conn = new MySqlConnection();
        private int pid;
        public PatientsDemographics()
        {
            InitializeComponent();
        }

        public PatientsDemographics(MySqlConnection conn, int pid)
        {
            this.conn = conn;
            this.pid = pid;
        }

        private void PatientsDemographics_Load(object sender, EventArgs e)
        {

        }
    }
}
