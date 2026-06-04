using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace GENTECH_PROJECTPUPSIS
{

    public class DbConnection
    {
        private static string connectionString = "server=127.0.0.1;port=3306;database=gentechdb;uid=root;pwd=;";
        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }

        public static void TestConnection(string connectionString)
        {
            // Traditional explicit blocks for older C# versions
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    Console.WriteLine("Backend successfully connected to gentechdb! Let's build.");

                    string query = "SELECT COUNT(*) FROM information_schema.tables WHERE table_schema = 'gentechdb';";
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        var tableCount = command.ExecuteScalar();
                        Console.WriteLine($"Database reports: {tableCount} active tables.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Connection failed: {ex.Message}");
                }
            }
        }
    }
}
