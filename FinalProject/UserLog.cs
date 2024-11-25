using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace FinalProject
{
    internal class UserLog : Login 
    {
       public static void CreateLoginFile(ref string username, ref string password)
       {
            if (!File.Exists("C:\\temp\\UserLog.txt"))
            {
                DateTime datetime = DateTime.Now;
                File.Create(@"C:\\temp\\UserLog.txt");

            }

            else
            {
               
            }
       }

        public void UpdateLoginFile(string username, string password)
        {

        }

        public UserLog(string username, string password, string form)
        {
            Username = username;
        }
    }
}
