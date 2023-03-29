using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using StudentHouseDashboard.Models;
using System.Data;
using System.Xml.Linq;

namespace StudentHouseDashboard.Repositories
{
    public class UserRepository
    {
        private string connectionString = "Server=mssqlstud.fhict.local;Database=dbi509645;User Id=dbi509645;Password=sNPNBm*BX!6z8RM;";

        public UserRepository() { }
        private SqlConnection CreateConnection()
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
        public List<User> GetAllUsers()
        {
            var users = new List<User>();

            using (SqlConnection conn = CreateConnection())
            {
                string sql = "SELECT * FROM Users;";
                SqlCommand cmd = new SqlCommand(sql, conn);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    // ID, Name, Password, Role
                    users.Add(new User(Convert.ToInt32(reader["ID"]),
                        reader["Name"].ToString(),
                        reader["Password"].ToString(),
                        (UserRole)reader["Role"])
                        );
                }

            }
            return users;
        }
        public User GetUserById(int id)
        {
            using (SqlConnection conn = CreateConnection())
            {
                string sql = "SELECT * FROM Users WHERE ID = @id;";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", id);
                var reader = cmd.ExecuteReader();

                reader.Read();

                // ID, Name, Password, Role
                return new User(Convert.ToInt32(reader["ID"]),
                        reader["Name"].ToString(),
                        reader["Password"].ToString(),
                        (UserRole)reader["Role"]);
            }
        }
        public List<User> GetUsersByPage(int? p, int? c)
        {
            List<User> users = new List<User>();
            if (c == null || c < 0)
            {
                c = 10;
            }
            if (p == null || p < 0)
            {
                p = 0;
            }
            using (SqlConnection conn = CreateConnection())
            {
                string sql = "SELECT * FROM Users ORDER BY ID OFFSET @start ROWS FETCH NEXT @count ROWS ONLY;";
                SqlCommand sqlCommand = new SqlCommand(sql, conn);
                sqlCommand.Parameters.AddWithValue("@start", p * c);
                sqlCommand.Parameters.AddWithValue("@count", c);
                var reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    users.Add(new User(Convert.ToInt32(reader["ID"]), reader["Name"].ToString(),
                        reader["Password"].ToString(), (UserRole)reader["Role"]));
                }

            }
            return users;
        }
        public bool CreateUser(string name, string password, UserRole role)
        {
            using (SqlConnection conn = CreateConnection())
            {
                string sql = "INSERT INTO Users (Name, Password, Role) VALUES (@name, @pass, @role);";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@pass", password);
                cmd.Parameters.AddWithValue("@role", (int)role);
                int writer = cmd.ExecuteNonQuery();

                if (writer == 1)
                {
                    return true;
                }
                else return false;
            }
        }
        public bool UpdateUser(int id, string name, string password, UserRole role)
        {
            using (SqlConnection conn = CreateConnection())
            {
                string sql = "UPDATE Users " +
                    "SET Name = @name, Password = @pass, Role = @role " +
                    "WHERE ID = @id;";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@pass", password);
                cmd.Parameters.AddWithValue("@role", (int)role);
                cmd.Parameters.AddWithValue("@id", id);
                int writer = cmd.ExecuteNonQuery();

                if (writer == 1)
                {
                    return true;
                }
                else return false;
            }
        }
        public bool DisableUser(int id)
        {
            using (SqlConnection conn = CreateConnection())
            {
                string sql = "UPDATE Users " +
                    "SET Name = 'Deleted User @id', Password = '0', Role = @role " +
                    "WHERE ID = @id;";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", id);
                int writer = cmd.ExecuteNonQuery();

                if (writer == 1)
                {
                    return true;
                }
                else return false;
            }
        }
    }
}
