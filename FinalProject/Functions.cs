using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace FinalProject
{
    public class Functions
    {
        // Open Connection with MySql
        public static MySqlConnection ConnectDB()
        {
            string connStr = "server=127.0.0.1;uid=root;pwd=Nyxilian@0908;database=its245final";
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            return conn;
        }

        //Load DataTable with an input Query
        public static DataTable LoadTable(string sqlQuery, MySqlConnection conn)
        {
            MySqlCommand cmd = new MySqlCommand();
            DataTable dt = new DataTable();
            try
            {
                cmd = new MySqlCommand(sqlQuery, conn);
                MySqlDataAdapter ad = new MySqlDataAdapter(cmd);
                ad.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                cmd.Dispose();
            }
            return null;
        }


        public static List<Patient> patients = new List<Patient>();
        public static void InitPatientList(MySqlConnection conn)
        {
            patients.Clear();
            try
            {
                List<int> l = new List<int>();
                string query = "select PatientID from its245final.patientdemographics where deleted = 0";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            l.Add(dr.GetInt32(0));
                        }
                    }
                }
                foreach (int i in l)
                {
                    patients.Add(new Patient(i, conn));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("InitPatientList Error: " + ex.Message);
            }
        }


        public static bool IsValidDate(string inputDate)
        {
            if (string.IsNullOrEmpty(inputDate))
                return true;
            // Format "YYYY-MM-DD"
            string pattern = @"^\d{4}-\d{2}-\d{2}$";

            if (Regex.IsMatch(inputDate, pattern))
            {
                DateTime parsedDate;
                return DateTime.TryParse(inputDate, out parsedDate);
            }

            return false;
        }

        public static void EnableReadOnly(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                if (control is TextBox textBox)
                {
                    textBox.Enabled = false;
                    textBox.ReadOnly = true;
                    textBox.BackColor = System.Drawing.Color.Gray;
                    textBox.BorderStyle = BorderStyle.FixedSingle;
                }
                if (control.HasChildren)
                {
                    EnableReadOnly(control);
                }
                if (control is Panel panel)
                {
                    panel.BackColor = System.Drawing.Color.LightSlateGray;
                }
            }
            parent.BackColor = System.Drawing.Color.White;
        }

        // used to exit read only mode when button method is attatched to is clicked, changing the visual style of the form in the process to indicate the change.
        public static void DisableReadOnly(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                if (control is TextBox textBox)
                {
                    textBox.Enabled = true;
                    textBox.ReadOnly = false;
                    textBox.BackColor = System.Drawing.Color.White;
                    textBox.BorderStyle = BorderStyle.FixedSingle;
                }
                if (control.HasChildren)
                {
                    DisableReadOnly(control);

                }
                if (control is Panel panel)
                {
                    panel.BackColor = System.Drawing.Color.SteelBlue;
                }
            }
            parent.BackColor = System.Drawing.Color.LightBlue;
        }

        public static void ColorClick(Button button, Color newColor)
        {
            Color ogColor = Color.White;
            button.BackColor = newColor;
            int timerDurr = 500;

            Timer timer = new Timer();
            timer.Interval = timerDurr;
            timer.Tick += (s, e) =>
            {
                button.BackColor = ogColor;
                timer.Stop();
                timer.Dispose();
            };
            timer.Start();
        }
    }
}
