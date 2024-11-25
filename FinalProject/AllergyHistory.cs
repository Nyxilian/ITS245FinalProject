using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace FinalProject
{
    public partial class AllergyHistory : Form
    {

        public AllergyHistory()
        {
            InitializeComponent();
        }

        public AllergyHistory(MySqlConnection conn)
        {
            InitializeComponent();
        }

        private void AllergyHistory_Load(object sender, EventArgs e)
        {
            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
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
