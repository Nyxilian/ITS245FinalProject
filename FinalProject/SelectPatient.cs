using MySql.Data.MySqlClient;
using Mysqlx.Prepare;
using Org.BouncyCastle.Asn1.X509;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Schema;

namespace FinalProject
{
    public partial class SelectPatient : Form
    {
        private int cbIndex;
        private int loginID;
        private MySqlConnection conn;

        public SelectPatient()
        {
            InitializeComponent();
            conn = Functions.ConnectDB();
            cbIndex = 0;
        }

        public SelectPatient(MySqlConnection conn, int cbIndex, int loginID)
        {
            InitializeComponent();
            this.conn = conn;
            this.cbIndex = cbIndex;
            this.loginID = loginID;
        }

        private void SelectPatient_Load(object sender, EventArgs e)
        {
            Functions.InitPatientList(conn);
            foreach (Patient p in Functions.patients)
            {
                cbPatient.Items.Add(p.Info_Combo());
            }
            cbPatient.SelectedIndex = cbIndex;
        }

        private void cbPatient_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbIndex = cbPatient.SelectedIndex;
            tBFirstName.Text = Functions.patients[cbIndex].PFirstName;
            tBLastName.Text = Functions.patients[cbIndex].PLastName;
            tBPhoneNumber.Text = Functions.patients[cbIndex].PPhoneNum;
            Functions.Logging(loginID, $"Open the record of {Functions.patients[cbIndex].PFirstName}", conn);
        }


        // Navigation
        private void btnToLogin_Click(object sender, EventArgs e)
        {
            Functions.Logging(loginID, "Move To Login Form", conn);
            Login l = new Login(conn);
            Hide();
            l.ShowDialog();
            Close();
        }
        private void btnToPatientDemo_Click(object sender, EventArgs e)
        {
            Functions.Logging(loginID, "Move To Patient Demographics Form", conn);
            PatientsDemographics pd = new PatientsDemographics(conn, cbIndex, loginID);
            Hide();
            pd.ShowDialog();
            Close();
        }
        private void btnToGenMedHis_Click(object sender, EventArgs e)
        {
            Functions.Logging(loginID, "Move To General Medical History Form", conn);
            GeneralMedical gm = new GeneralMedical(conn, cbIndex, loginID);
            Functions.EnableReadOnly(gm);
            Hide();
            gm.ShowDialog();
            Close();
        }
        private void btnToAllergyHistory_Click(object sender, EventArgs e)
        {
            Functions.Logging(loginID, "Move To Allergy History Form", conn);
            AllergyHistory ah = new AllergyHistory(conn, cbIndex, loginID);
            Hide();
            ah.ShowDialog();
            Close();
        }
        private void btnToFamilyHistory_Click(object sender, EventArgs e)
        {
            Functions.Logging(loginID, "Move To Family History Form", conn);
            Family_History fh = new Family_History(conn, cbIndex, loginID);
            Functions.EnableReadOnly(fh);
            Hide();
            fh.ShowDialog();
            Close();
        }


        // Action Menu
        private void button1_Click(object sender, EventArgs e) // Search Command
        {
            string target = tbSearchPatients.Text.ToLower();
            Patient p;
            for (int i = 0; i < Functions.patients.Count; i++)
            {
                p = Functions.patients[i];
                try
                {
                    if (p.PLastName.ToLower().Equals(target))
                    {
                        cbPatient.SelectedIndex = i;
                        Functions.Logging(loginID, $"Search a patient: {target}; Succeed", conn);
                        return;
                    }
                    if (p.PID == Convert.ToInt32(target))
                    {
                        cbPatient.SelectedIndex = i;
                        Functions.Logging(loginID, $"Search a patient: {target}; Succeed", conn);
                        return;
                    }
                }
                catch { }
            }
            Functions.Logging(loginID, $"Search a patient: {target}; Fail", conn);
            MessageBox.Show("No data found with the corresponding input.");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            cbPatient.Items.Clear();
            Functions.InitPatientList(conn);
            foreach (Patient p in Functions.patients)
            {
                cbPatient.Items.Add(p.Info_Combo());
            }
            cbPatient.SelectedIndex = cbIndex;
            Functions.Logging(loginID, $"Update Patient List", conn);
        }

        private void PatientReportBtn_Click(object sender, EventArgs e)
        {
            int PID = Functions.patients[cbIndex].PID;
            string folderDirectory = "C:\\Patient Reports";
            string fileName = $"Patient PID [{PID}] - {Functions.patients[cbIndex].PFirstName.ToString()} {Functions.patients[cbIndex].PLastName.ToString()}.txt";
            string fullPath = Path.Combine(folderDirectory, fileName);

            try
            {
                if (!Directory.Exists(folderDirectory))
                {
                    Directory.CreateDirectory(folderDirectory);
                }

                if (File.Exists(fullPath))
                {
                    File.Delete(fullPath);
                }

                FileStream file = new FileStream(fullPath, FileMode.Create, FileAccess.Write);
                StreamWriter writer = new StreamWriter(file);

                writer.WriteLine($"Patient Name: {Functions.patients[cbIndex].PFirstName.ToString()} {Functions.patients[cbIndex].PLastName.ToString()}  || Patient ID: {PID}. ");
                writer.WriteLine("\n");
                writer.WriteLine("Patient Demographics: ");

                string getPatientDemo = $"SELECT * FROM patientdemographics WHERE PatientID = {PID}";
                using (MySqlCommand cmd = new MySqlCommand(getPatientDemo, conn))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                writer.WriteLine($"{reader.GetName(i)}:  {reader[i]}");
                            }
                        }
                    }
                }

                writer.WriteLine("\n");
                writer.WriteLine("General MedicalHistory: ");

                string getGMH = $"SELECT * FROM  generalmedicalhistory WHERE PatientID = {PID}";
                using (MySqlCommand cmd = new MySqlCommand(getGMH, conn))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                writer.WriteLine($"{reader.GetName(i)}:  {reader[i]}");
                            }
                        }
                    }
                }

                writer.WriteLine("\n");
                writer.WriteLine(" Allergy History: ");

                string getAllergy = $"SELECT * FROM allergyhistory WHERE PatientID = {PID}";
                using (MySqlCommand cmd = new MySqlCommand(getAllergy, conn))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                writer.WriteLine($"{reader.GetName(i)}:  {reader[i]}");
                            }
                        }
                    }
                }

                writer.WriteLine("\n");
                writer.WriteLine("Family History: ");

                string getFamily = $"SELECT * FROM allergyhistory WHERE PatientID = {PID}";
                using (MySqlCommand cmd = new MySqlCommand(getFamily, conn))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                writer.WriteLine($"{reader.GetName(i)}:  {reader[i]}");
                            }
                        }
                    }
                }

                writer.Flush();
                writer.Close();
                file.Close();
                Functions.Logging(loginID, $"Make a report of a patient; PID: {PID}", conn);
            }
            catch (Exception ex)
            {
                Functions.Logging(loginID, $"Failed to make a report of a patient; PID: {PID}", conn);
                MessageBox.Show("Error Creating File!\nError: " + ex.Message);
            }
        }
    }
}

//string getFamily = $"SELECT * FROM familyhistory WHERE PatientID = {PID}";
//string getGMH = $"SELECT * FROM  generalmedicalhistory WHERE PatientID = {PID}";
//string getAllergy = $"SELECT * FROM allergyhistory WHERE PatientID = {PID}";
//string getPatientDemo = $"SELECT * FROM patientdemographics WHERE PatientID = {PID}";

////MySqlCommand cmdPatientDemo = new MySqlCommand(getPatientDemo, conn);
////MySqlCommand cmdGMH = new MySqlCommand(getGMH, conn);
////MySqlCommand cmdAllergy = new MySqlCommand(getAllergy, conn);
////MySqlCommand cmdFamily = new MySqlCommand(getFamily, conn);

////MySqlDataReader cmdPatientDemoReader = cmdPatientDemo.ExecuteReader();
////MySqlDataReader cmdGMHReader = cmdGMH.ExecuteReader();
////MySqlDataReader cmdAllergyReader = cmdAllergy.ExecuteReader();
////MySqlDataReader cmdFamilyReader = cmdFamily.ExecuteReader();

//writer.WriteLine($"Patient Name: {Functions.patients[cbIndex].PFirstName.ToString()} {Functions.patients[cbIndex].PLastName.ToString()}. Patient ID: {PID}. ");

////cmdPatientDemoReader.Close();
////cmdGMHReader.Close();
////cmdAllergyReader.Close();
////cmdFamilyReader.Close();
