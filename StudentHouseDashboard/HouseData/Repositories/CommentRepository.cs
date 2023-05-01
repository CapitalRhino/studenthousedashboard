using System.Data.SqlClient;
using StudentHouseDashboard.Models;

namespace StudentHouseDashboard.Repositories;

public class CommentRepository
{
    public CommentRepository()
    {
        
    }

    public List<Comment> GetAllCommentsOnAnnouncement(int announcementId)
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
            sqlCommand.Parameters.AddWithValue("@announcementID", announcementId);
            var reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                Comment newComment = new Comment((int)reader["ID"],
                    new User((int)reader["UserID"], reader["UserName"].ToString(),
                        reader["Password"].ToString(), (UserRole)reader["Role"]),
                    reader["Description"].ToString(), reader["Title"].ToString(),
                    (DateTime)reader["PublishDate"]);
                newComment.Responses = GetAllCommentResponses(newComment.ID);
                comments.Add(newComment);
            }
        }

        return comments;
    }

    public List<Comment> GetAllCommentResponses(int commentId)
    {
        List<Comment> responses = new List<Comment>();
        using (SqlConnection connection = SqlConnectionHelper.CreateConnection())
        {
            string sql = "SELECT c.ID, c.Author, c.Description, c.Title, c.PublishDate, " +
                         "u.ID UserID, u.Name UserName, u.Password, u.Role FROM CommentsResponses cr " +
                         "INNER JOIN Comments c ON c.ID = cr.ResponseID " +
                         "INNER JOIN Users u ON u.ID = c.Author " +
                         "WHERE cr.CommentID = @commentID";
            SqlCommand sqlCommand = new SqlCommand(sql, connection);
            sqlCommand.Parameters.AddWithValue("@commentID", commentId);
            var reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                Comment newComment = new Comment((int)reader["ID"],
                    new User((int)reader["UserID"], reader["UserName"].ToString(),
                        reader["Password"].ToString(), (UserRole)reader["Role"]),
                    reader["Description"].ToString(), reader["Title"].ToString(),
                    (DateTime)reader["PublishDate"]);
                newComment.Responses = GetAllCommentResponses(newComment.ID);
                responses.Add(newComment);
            }
        }

        return responses;
    }
}