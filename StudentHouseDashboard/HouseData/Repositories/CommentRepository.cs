using System.ComponentModel.Design;
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

    public Comment GetCommentById(int id)
    {
        using (SqlConnection connection = SqlConnectionHelper.CreateConnection())
        {
            string sql = "SELECT c.ID, c.Author, c.Description, c.Title, c.PublishDate, " +
                         "u.ID UserID, u.Name UserName, u.Password, u.Role FROM Comments c " +
                         "INNER JOIN Users u ON u.ID = c.Author " +
                         "WHERE c.ID = @commentID;";
            SqlCommand sqlCommand = new SqlCommand(sql, connection);
            sqlCommand.Parameters.AddWithValue("@commentID", id);
            var reader = sqlCommand.ExecuteReader();
            reader.Read();
            Comment newComment = new Comment((int)reader["ID"],
                new User((int)reader["UserID"], reader["UserName"].ToString(),
                    reader["Password"].ToString(), (UserRole)reader["Role"]),
                reader["Description"].ToString(), reader["Title"].ToString(),
                (DateTime)reader["PublishDate"]);
            newComment.Responses = GetAllCommentResponses(newComment.ID);
            return newComment;
        }
    }

    public void UpdateComment(int id, string description)
    {
        using (SqlConnection connection = SqlConnectionHelper.CreateConnection())
        {
            string sql = "UPDATE Comments " +
                "SET Description = @desc " +
                "WHERE Id = @id;";
            SqlCommand cmd = new SqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@desc", description);
            cmd.Parameters.AddWithValue("@id", id);
            int writer = cmd.ExecuteNonQuery();
        }
    }

    private Comment CreateComment(User author, string description, string title, DateTime publishDate)
    {
        using (SqlConnection connection = SqlConnectionHelper.CreateConnection())
        {
            string sql = "INSERT INTO Comments (Author, Description, Title, PublishDate) " +
                "VALUES (@author, @desc, @title, @date); " +
                "SELECT SCOPE_IDENTITY();";
            SqlCommand cmd = new SqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@author", author.ID);
            cmd.Parameters.AddWithValue("@desc", description);
            cmd.Parameters.AddWithValue("@title", title);
            cmd.Parameters.AddWithValue("@date", publishDate);
            return GetCommentById(Convert.ToInt32(cmd.ExecuteScalar()));
        }
    }
    public void CreateCommentOnAnnouncement(User author, string description, string title, DateTime publishDate, int announcementId)
    {
        Comment comment = CreateComment(author, description, title, publishDate);
        using (SqlConnection connection = SqlConnectionHelper.CreateConnection())
        {
            string sql = "INSERT INTO AnnouncementsComments (AnnouncementID, CommentID) VALUES (@announcementID, @commentID);";
            SqlCommand cmd = new SqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@announcementID", announcementId);
            cmd.Parameters.AddWithValue("@commentID", comment.ID);
            int writer = cmd.ExecuteNonQuery();
        }
    }
    public void CreateResponseOnComment(User author, string description, string title, DateTime publishDate, int commentId)
    {
        Comment response = CreateComment(author, description, title, publishDate);
        using (SqlConnection connection = SqlConnectionHelper.CreateConnection())
        {
            string sql = "INSERT INTO CommentsResponses (CommentID, ResponseID) VALUES (@commentID, @responseID);";
            SqlCommand cmd = new SqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@commentID", commentId);
            cmd.Parameters.AddWithValue("@responseID", response.ID);
            int writer = cmd.ExecuteNonQuery();
        }
    }

    private void DeleteComment(int id)
    {
        using (SqlConnection connection = SqlConnectionHelper.CreateConnection())
        {
            string sql = "DELETE FROM Comments " +
                "WHERE Id = @id;";
            SqlCommand cmd = new SqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@id", id);
            int writer = cmd.ExecuteNonQuery();
        }
    }

    public void DeleteCommentOnAnnouncement(int commentId, int announcementId)
    {
        using (SqlConnection connection = SqlConnectionHelper.CreateConnection())
        {
            string sql = "DELETE FROM AnnouncementsComments " +
                "WHERE CommentID = @commentId AND AnnouncementID = @announcementId";
            SqlCommand cmd = new SqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@commentId", commentId);
            cmd.Parameters.AddWithValue("@announcementId", announcementId);
            int writer = cmd.ExecuteNonQuery();
        }
        DeleteComment(commentId);
    }
    public void DeleteResponseOnComment(int responseId, int commentId)
    {
        using (SqlConnection connection = SqlConnectionHelper.CreateConnection())
        {
            string sql = "DELETE FROM AnnouncementsComments " +
                "WHERE CommentID = @commentId AND ResponseID = @responseId";
            SqlCommand cmd = new SqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@commentId", commentId);
            cmd.Parameters.AddWithValue("@responseId", responseId);
            int writer = cmd.ExecuteNonQuery();
        }
        DeleteComment(commentId);
    }
}