using System.Data.SqlClient;
using StudentHouseDashboard.Models;

namespace StudentHouseDashboard.Repositories;

public class CommentRepository
{
    public CommentRepository()
    {
        
    }

    public List<Comment> GetAllCommentsOnAnnouncement(int announcementID)
    {
        List<Comment> comments = new List<Comment>();
        using (SqlConnection connection = SqlConnectionHelper.CreateConnection())
        {
            string sql = "SELECT c.ID, c.Author, c.Description, c.Title, c.PublishDate, " +
                         "u.ID UserID, u.Name UserName, u.Password, u.Role FROM AnnouncementsComments ac " +
                         "INNER JOIN Comments c ON c.ID = ac.CommentID " +
                         "INNER JOIN Users u ON u.ID = c.Author " +
                         "WHERE ac.AnnouncementID = @announcementID";
            SqlCommand sqlCommand = new SqlCommand(sql, connection);
            sqlCommand.Parameters.AddWithValue("@announcementID", announcementID);
            var reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                comments.Add(new Comment((int)reader["ID"], 
                    new User((int)reader["UserID"], reader["UserName"].ToString(), 
                        reader["Password"].ToString(), (UserRole)reader["Role"]), 
                    reader["Description"].ToString(), reader["Title"].ToString(), 
                    (DateTime)reader["PublishDate"]));
            }
        }

        return comments;
    }
}