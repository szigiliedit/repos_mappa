using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Server.DatabaseManager
{
    public class BaseDatabaseManager
    {
        public static string hibaUzenet = "";
        protected BaseDatabaseManager()
        {

        }
        public static MySqlConnection connenction
        {
            get
            {
                MySqlConnection connection = new MySqlConnection();
                string connectionString = "SERVER=localhost;" + "DATABASE=madarak;" + "UID=root;" + "PASSWORD=;" + "SSL MODE=none;"; // szerver ip cime, db neve, felhasznalo neve, jelszo
                connection.ConnectionString = connectionString;
                return connection;
            }
        }

    }
}