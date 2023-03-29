using StudentHouseDashboard.Managers;
using StudentHouseDashboard.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentHouseDashboard.Repositories
{
    public class AnnouncementRepository
    {
        private string connectionString = "Server=mssqlstud.fhict.local;Database=dbi509645;User Id=dbi509645;Password=sNPNBm*BX!6z8RM;";
        public AnnouncementRepository() { }
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
        public List<Announcement> GetAllAnnouncements()
        {
            List<Announcement> announcements = new List<Announcement>();
            UserManager userManager = new UserManager();
            using (SqlConnection conn = CreateConnection())
            {
                string sql = "SELECT * FROM Announcements;";
                SqlCommand cmd = new SqlCommand(sql, conn);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    // ID, Name, Password, Role
                    announcements.Add(new Announcement(Convert.ToInt32(reader["ID"]),
                        userManager.GetUserById(Convert.ToInt32(reader["Author"])), 
                        reader["Description"].ToString(), reader["Title"].ToString(), 
                        (DateTime)reader["PublishDate"], (bool)reader["IsImportant"],
                        (bool)reader["IsSticky"]));
                }
                conn.Close();
            }
            return announcements;
        }
        public List<Announcement> GetAnnouncementsByPage(int? p, int? c)
        {
            List<Announcement> announcements = new List<Announcement>();
            UserManager userManager = new UserManager();
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
                string sql = "SELECT * FROM Announcements ORDER BY ID OFFSET @start ROWS FETCH NEXT @count ROWS ONLY;";
                SqlCommand sqlCommand = new SqlCommand(sql, conn);
                sqlCommand.Parameters.AddWithValue("@start", p * c);
                sqlCommand.Parameters.AddWithValue("@count", c);
                var reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    announcements.Add(new Announcement(Convert.ToInt32(reader["ID"]),
                        userManager.GetUserById(Convert.ToInt32(reader["Author"])),
                        reader["Description"].ToString(), reader["Title"].ToString(),
                        (DateTime)reader["PublishDate"], (bool)reader["IsImportant"],
                        (bool)reader["IsSticky"]));
                }

            }
            return announcements;
        }
    }
}
