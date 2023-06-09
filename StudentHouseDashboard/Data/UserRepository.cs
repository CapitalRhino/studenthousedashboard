using Logic;
using Models;
using System.Data.SqlClient;

namespace Data
{
    public class UserRepository : IUserRepository
    {
        public UserRepository() { }
        public List<User> GetAllUsers()
        {
            var users = new List<User>();

            using (SqlConnection conn = SqlConnectionHelper.CreateConnection())
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
            using (SqlConnection conn = SqlConnectionHelper.CreateConnection())
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
        public List<User> GetUsersByPage(int p, int c)
        {
            List<User> users = new List<User>();
            using (SqlConnection conn = SqlConnectionHelper.CreateConnection())
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
        public User CreateUser(string name, string password, UserRole role)
        {
            using (SqlConnection conn = SqlConnectionHelper.CreateConnection())
            {
                string sql = "INSERT INTO Users (Name, Password, Role) VALUES (@name, @pass, @role) " +
                    "SELECT SCOPE_IDENTITY();";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@pass", password);
                cmd.Parameters.AddWithValue("@role", (int)role);
                return GetUserById(Convert.ToInt32(cmd.ExecuteScalar()));
            }
        }
        public void UpdateUser(int id, string name, string password, UserRole role)
        {
            using (SqlConnection conn = SqlConnectionHelper.CreateConnection())
            {
                string sql = "UPDATE Users " +
                    "SET Name = @name, Password = @pass, Role = @role " +
                    "WHERE ID = @id;";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@pass", password);
                cmd.Parameters.AddWithValue("@role", (int)role);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }
        public void DisableUser(int id)
        {
            using (SqlConnection conn = SqlConnectionHelper.CreateConnection())
            {
                string sql = "UPDATE Users " +
                    "SET Name = 'Deleted User ' + @id, Password = '0'" +
                    "WHERE ID = @id;";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", id.ToString());
                cmd.ExecuteNonQuery();
            }
        }

        public User? GetUserByName(string userName)
        {
            using (SqlConnection conn = SqlConnectionHelper.CreateConnection())
            {
                string sql = "SELECT * FROM Users WHERE Name = @userName;";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@userName", userName);
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    return new User(Convert.ToInt32(reader["ID"]), reader["Name"].ToString(),
                        reader["Password"].ToString(), (UserRole)reader["Role"]);
                }
                else { return null; }
                
            }
        }
    }
}
