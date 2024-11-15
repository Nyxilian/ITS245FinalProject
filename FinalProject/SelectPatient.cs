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
        MySqlDataAdapter ad;
        public SelectPatient()
        {
            InitializeComponent();
        }

        //2.b.i.2
        //Initialize the datagridview 
        private void SelectPatient_Load(object sender, EventArgs e)
        {
            conn = Functions.ConnectDB();
            //2.b.i.3
            string query = "SELECT PatientID, PtFirstName, PtLastName, PtHomePhone, DOB " +
                "FROM its245final.patientdemographics " +
                "WHERE deleted = 0;";
            DataTable dt = new DataTable();

            ad = Functions.LoadTable(query, conn);
            ad.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns["PatientID"].Visible = false;
            dataGridView1.Columns["DOB"].Visible = false;
        }
        //2.b.i.5
        private void btnToPatientDemo_Click(object sender, EventArgs e)
        {
            int patientID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["PatientID"].Value);
            PatientsDemographics pd = new PatientsDemographics(conn, patientID);
            pd.Show();
        }

        //2.b.i.6
        //Find the index of the target value if the data is in dataGridView
        //If not, return -1
        private int SearchData(string target)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[0].Value.ToString().Equals(target)) //By PID
                    return row.Index;
                if (row.Cells[2].Value.ToString().ToLower().Equals(target.ToLower())) //By LastName
                    return row.Index;
            }
            return -1;
        }

        private void button1_Click(object sender, EventArgs e) //Initiate the search command
        {
            int target = SearchData(TBSearchPatients.Text);
            if (target != -1)
            {
                dataGridView1.CurrentRow.Selected = false;
                dataGridView1.CurrentCell = dataGridView1.Rows[target].Cells[1];
                dataGridView1.Rows[target].Selected = true;
            }
            else
            {
                MessageBox.Show("Unable to find a paitent with the corresponding data");
            }
        }
    }
}
