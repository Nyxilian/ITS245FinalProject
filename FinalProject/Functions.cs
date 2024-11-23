﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
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
            string connStr = "server=127.0.0.1;uid=root;pwd=toor;database=patientdb";
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
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(dt);
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
            MessageBox.Show("Unable to retrieve data from DB.");
            return null;
        }
    }
}
