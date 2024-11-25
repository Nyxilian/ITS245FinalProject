using System;
using System.Collections;
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
        MySqlConnection conn;
        
        public PatientsDemographics()
        {
            InitializeComponent();
        }
        public PatientsDemographics(MySqlConnection conn)
        {
            InitializeComponent();
            this.conn = conn;
        }

        private void PatientsDemographics_Load(object sender, EventArgs e)
        {
            
        }

        // Action Menu
        private void btnAdd_Click(object sender, EventArgs e)
        {
           
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
           
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
           
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
           
        }
    }
}
