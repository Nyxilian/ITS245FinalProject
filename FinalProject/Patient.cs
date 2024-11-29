using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;

namespace FinalProject
{
    public class Patient
    {
        public int PID { get; set; }
        public string PLastName { get; set; }
        public string PFirstName { get; set; }
        public DateTime DOB { get; set; }
        public string PPhoneNum { get; set; }

        public Patient(int pid, MySqlConnection conn)
        {
            PID = pid;
            try
            {
                MySqlCommand cmd = new MySqlCommand("RetrieveBasicInfoByPID", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@I_PID", pid);
                cmd.Parameters["@I_PID"].Direction = ParameterDirection.Input;

                cmd.Parameters.Add("@O_LAST", MySqlDbType.VarChar);
                cmd.Parameters["@O_LAST"].Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@O_FIRST", MySqlDbType.VarChar);
                cmd.Parameters["@O_FIRST"].Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@O_DOB", MySqlDbType.DateTime);
                cmd.Parameters["@O_DOB"].Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@O_PHONENUM", MySqlDbType.VarChar);
                cmd.Parameters["@O_PHONENUM"].Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();

                PLastName = cmd.Parameters["@O_LAST"].Value.ToString();
                PFirstName = cmd.Parameters["@O_FIRST"].Value.ToString();
                DOB = (DateTime)cmd.Parameters["@O_DOB"].Value;
                PPhoneNum = cmd.Parameters["@O_PHONENUM"].Value.ToString();

                cmd.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Patient Constructor Error: " + ex.Message);
            }
        }

        public string Info_Combo()
        {
            int age = DateTime.Now.Year - DOB.Year;

            // Check if the birthday has already occurred this year
            if (DateTime.Now.DayOfYear < DOB.DayOfYear)
            {
                age--; // Subtract 1 if the birthday hasn't happened yet this year
            }
            if(age < 0)
            {
                age += 100;
            }
            return PFirstName + " " + PLastName + " / " + age.ToString();
        }
    }
}
