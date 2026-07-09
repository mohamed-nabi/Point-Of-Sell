using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration; 

namespace NewPOS
{
    
    internal static class Program
    {


        private static string masterConnectionString = "Server=.;Database=master;Trusted_Connection=True;";
        private static string dbConnectionString = "Server=.;Database=POS_DB;User ID=sa;Password=123456;";

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            try
            {
                //This is 2 method i was maked to simulate database setup in production envioronement

                //EnsureDatabaseAndTables();
                //EnsureDatabaseSeeded();
            }
            catch (Exception ex)
            {
                return;
            }


        //   Application.Run(new frmTest());
            Application.Run(new frmMain());
        }

       
        private static void EnsureDatabaseAndTables()
        {
            using(SqlConnection connection  = new SqlConnection(masterConnectionString))
            {
                connection.Open();

                string checkDbQuery = "if ISNULL(DB_ID('POS_DB') ,0) = 0" +
                    "\nbegin" +
                    "\nCREATE DATABASE POS_DB" + 
                    "\nend";

                SqlCommand command = new SqlCommand(checkDbQuery, connection);  
                command.ExecuteNonQuery();

                connection.Close();

                string migrationSql =
                        File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Migration.sql"));

                using (SqlConnection dbConnection = new SqlConnection(dbConnectionString))
                {
                    dbConnection.Open();


                    string[] commands = migrationSql.Split(new[] { "GO\r\n", "GO\n", "GO\r" }, StringSplitOptions.RemoveEmptyEntries);


                    foreach (var cmdText in commands)
                    {
                        if (!string.IsNullOrEmpty(cmdText))
                        {
                            using (SqlCommand migrationCmd = new SqlCommand(cmdText, dbConnection))
                            {
                                migrationCmd.ExecuteNonQuery();
                            }
                        }
                    }
                }
            }
        }

        private static void EnsureDatabaseSeeded()
        {
            using(SqlConnection connection = new SqlConnection(dbConnectionString))
            {
                connection.Open();

                string SeederSql =
                    File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Seeder.sql"));

                string[] commands = SeederSql.Split(new[] { "GO\r\n", "GO\n", "GO\r" }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var cmdText in commands)
                {
                    if (!string.IsNullOrWhiteSpace(cmdText))
                    {
                        using (SqlCommand seederCmd = new SqlCommand(cmdText, connection))
                        {
                            seederCmd.ExecuteNonQuery();
                        }
                    }
                }
            }
        }
    }

}


