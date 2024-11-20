﻿using System;
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
    public partial class AllergyHistory : Form
    {
        MySqlConnection conn = new MySqlConnection();
        MySqlDataAdapter ad = new MySqlDataAdapter();
        DataTable dt = new DataTable();
        // 0: View, 1: Add, 2: Modify
        private int mode = 0;

        public AllergyHistory()
        {
            InitializeComponent();
        }

        public AllergyHistory(MySqlConnection conn)
        {
            InitializeComponent();
            this.conn = conn;
        }

        private void ModeChange(int m)
        {
            if (m == 0) // View mode
            {
                dataGridView1.AllowUserToAddRows = false;
                mode = 0;
                // button
                btnAdd.Enabled = true;
                btnModify.Enabled = true;
                btnSave.Enabled = false;
                btnUndo.Enabled = false;
                btnDelete.Enabled = false;

                dataGridView1.ReadOnly = true; // disabling editing
                dataGridView1.BackgroundColor = Color.LightGray;
            }
            else if (m == 1) // Add mode
            {
                mode = 1;
                // button
                btnAdd.Enabled = false;
                btnModify.Enabled = true;
                btnSave.Enabled = true;
                btnUndo.Enabled = true;
                btnDelete.Enabled = false;

                dataGridView1.ReadOnly = false; // allowing editing
                dataGridView1.BackgroundColor = Color.White;
            }
            else // Modify mode
            {
                mode = 2;
                btnAdd.Enabled = true;
                btnModify.Enabled = false;
                btnSave.Enabled = true;
                btnUndo.Enabled = true;
                btnDelete.Enabled = true;

                dataGridView1.ReadOnly = false; // allowing editing
                dataGridView1.BackgroundColor = Color.White;
            }
        }

        private void UpdateListBox()
        {
            string query = "SELECT * FROM its245final.allergyhistory";
            ad = Functions.LoadTable(query, conn);
            ad.Fill(dt);
            foreach (DataRow row in dt.Rows)
            {
                listBox1.Items.Add(row["Allergen"].ToString());
            }
        }

        private void AllergyHistory_Load(object sender, EventArgs e)
        {
            UpdateListBox();
            ModeChange(0);
            btnAdd.Enabled = false;
            btnModify.Enabled = false;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRow[] filteredRows = dt.Select($"Allergen = '{listBox1.Items[listBox1.SelectedIndex]}'");

            DataTable filteredTable = dt.Clone();
            foreach (var row in filteredRows)
            {
                filteredTable.ImportRow(row);
            }
            dataGridView1.DataSource = filteredTable;

            btnAdd.Enabled = true;
            btnModify.Enabled = true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ModeChange(1); // Add mode
            dt.Clear();
            ad.Fill(dt); // initiating the dataTable if it had any changes

            DataRow dr = dt.NewRow(); // a new row for dataTable
            dataGridView1.Rows[0].ReadOnly = true; // unable editing the existing values

            string query = "SELECT MAX(AllergyID) from its245final.allergyhistory;";
            try
            {
                MySqlCommand cmd = new MySqlCommand(query, conn);
                object result = cmd.ExecuteScalar(); // bringing the last # of PatientID
                if (result != DBNull.Value)
                {
                    dr[0] = Convert.ToInt32(result) + 1;
                    dt.Rows.Add(dr); // Add the smallest value of PatientID that doesn't exsit
                }
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            dataGridView1.DataSource = dt; // update dataGridView with the updated data
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            ModeChange(2); // Notice Modify mode
            dataGridView1.ReadOnly = false;
            dataGridView1.AllowUserToAddRows = false;
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
