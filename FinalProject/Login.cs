using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.X509;
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

        //set properties to store inputted Username and Password
        public string Username { get; set; }
        public string Password { get; set; }

        //set conn equal to the conn returned by ConnectDB, which enables this conn to be used to bridge the connection between the program and the mysql database. 
        private void Login_Load(object sender, EventArgs e)
        {
            conn = Functions.ConnectDB();
        }

        //initialize form
        public Login()
        {
            InitializeComponent();
        }

        //initialize form and set conn. 
        public Login(MySqlConnection conn)
        {
            InitializeComponent();
            this.conn = conn;
        }

        //set Username and Password properties equal to corresponding textboxes. 
        private void button1_Click(object sender, EventArgs e)
        {
            Username = textBox1.Text;
            Password = textBox2.Text;

            ValidationMethod(Username, Password);
        }

        //Use stored procedure to validate users credentials. Take user's username and password
        //and compares them against username and password returned by stored procedure. 
        public void ValidationMethod(string username, string password)
        {
            using (MySqlCommand cmd = new MySqlCommand("login_confirm", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                //Take username as an input variable for stored procedure
                cmd.Parameters.AddWithValue("UN", username);
                cmd.Parameters["UN"].Direction = ParameterDirection.Input;
                
                //output password and user id that corresponds to inputted username
                cmd.Parameters.Add("PW", MySqlDbType.VarChar);
                cmd.Parameters["PW"].Direction = ParameterDirection.Output;

                cmd.Parameters.Add("LID", MySqlDbType.VarChar);
                cmd.Parameters["LID"].Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();

                //store database user and password in strings. 
                string storedpassword = cmd.Parameters["PW"].Value?.ToString();
                string storedusername = cmd.Parameters["UN"].Value?.ToString();
                int loginID = Convert.ToInt32(cmd.Parameters["LID"].Value.ToString());

                if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                {
                    MessageBox.Show("Missing username/password! Please fill both boxes with your credentials!");
                }

                //compare user's inputted username and password against the db username and password.
                //if credentials are correct, proceed to the select patient form.
                else if (storedpassword == password && storedusername == username)
                {
                    MessageBox.Show("Logging In...");
                    SelectPatient selectPatientForm = new SelectPatient(conn, 0, loginID);
                    Functions.Logging(loginID, "Logged In", conn);
                    Functions.Logging(loginID, "Move to Select Patient Form", conn);
                    this.Hide();
                    selectPatientForm.ShowDialog();
                    this.Close();
                }

                //if user's username and/or password are incorrect, clear textboxes and tell user to try again
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