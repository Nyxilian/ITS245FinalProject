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
        private MySqlConnection conn;

        public string Username { get; set; }
        public string Password { get; set; }

        private void Login_Load(object sender, EventArgs e)
        {
            conn = Functions.ConnectDB();
        }
        public Login()
        {
            InitializeComponent();
        }
        public Login(MySqlConnection conn)
        {
            InitializeComponent();
            this.conn = conn;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Username = textBox1.Text;
            Password = textBox2.Text;

            ValidationMethod(Username, Password);
        }

        public void ValidationMethod(string username, string password)
        {
            using (MySqlCommand cmd = new MySqlCommand("login_confirm", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("UN", username);
                cmd.Parameters["UN"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add("PW", MySqlDbType.VarChar);
                cmd.Parameters["PW"].Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();

                string storedpassword = cmd.Parameters["PW"].Value?.ToString();
                string storedusername = cmd.Parameters["UN"].Value?.ToString();

                if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                {
                    MessageBox.Show("Missing username/password! Please fill both boxes with your credentials!");
                }

                else if (storedpassword == password && storedusername == username)
                {
                    MessageBox.Show("Logging In...");
                    //UserLog.CreateLoginFile(ref username, ref password);
                    SelectPatient selectPatientForm = new SelectPatient();
                    this.Hide();
                    selectPatientForm.ShowDialog();
                    this.Close();
                }

                else if (storedpassword != password || storedusername != username)
                {
                    MessageBox.Show("Invalid Credentials. Please Try Inputting Your Username and/or Password Again.");
                    textBox1.Clear();
                    textBox2.Clear();
                }
            }
        }
    }
}