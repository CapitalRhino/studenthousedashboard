﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentHouseDashboard.Repositories
{
    public static class SqlConnectionHelper
    {
        private static string connectionString = "Server=mssqlstud.fhict.local;Database=dbi509645;User Id=dbi509645;Password=sNPNBm*BX!6z8RM;";
        public static SqlConnection CreateConnection()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
            }
            catch (Exception)
            {
                Console.WriteLine("Database connection error. Are you connected to the VDI VPN?");
            }

            return connection;
        }
    }
}
