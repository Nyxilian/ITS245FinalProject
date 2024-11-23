using MySql.Data.MySqlClient;
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

namespace FinalProject
{
    public partial class Login : Form
    {
        public static bool LogCred;
        public static string username;
        public static string password;

        private MySqlConnection conn;

        private void Login_Load(object sender, EventArgs e)
        {
            conn = Functions.ConnectDB();
        }

        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            username = textBox1.Text;
            password = textBox2.Text;

            ValidationMethod(username, password);
        }

        private void ValidationMethod(string username, string password)
        {
            using(MySqlCommand cmd = new MySqlCommand("login_confirm", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("UN", username);
                cmd.Parameters["UN"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add("PW", MySqlDbType.VarChar);
                cmd.Parameters["PW"].Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();

                string storedpassword = cmd.Parameters["PW"].Value?.ToString();

                if (storedpassword == password)
                {
                    MessageBox.Show("Logging In...");
                    LogCred = true;

                    SelectPatient selectPatientForm = new SelectPatient();
                    this.Hide();
                    selectPatientForm.ShowDialog();
                }
                else if (storedpassword != password)
                {
                    MessageBox.Show("Invalid Credentials. Please Try Inputting Your Username and/or Password Again.");
                    LogCred = false;
                    textBox1.Clear();
                    textBox2.Clear();
                }
            }
        }
    }
}
