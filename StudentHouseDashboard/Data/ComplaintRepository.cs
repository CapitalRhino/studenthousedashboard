using Logic;
using Logic.Exceptions;
using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class ComplaintRepository : IComplaintRepository
    {
        public ComplaintRepository()
        {
                
        }
        public List<Complaint> GetAllComplaints()
        {
            List<Complaint> complaints = new List<Complaint>();
            UserRepository userRepository = new UserRepository();
            using (SqlConnection conn = SqlConnectionHelper.CreateConnection())
            {
                string sql = "SELECT * FROM Complaints;";
                SqlCommand cmd = new SqlCommand(sql, conn);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Complaint complaint = new Complaint(Convert.ToInt32(reader["ID"]),
                        userRepository.GetUserById(Convert.ToInt32(reader["Author"])),
                        reader["Description"].ToString(), reader["Title"].ToString(),
                        (DateTime)reader["PublishDate"], (ComplaintStatus)reader["Status"],
                        (ComplaintSeverity)reader["Severity"]);
                    CommentRepository commentRepository = new CommentRepository();
                    complaint.Responses = commentRepository.GetAllCommentsOnComplaint(complaint.ID);
                    // ID, Name, Password, Role
                    complaints.Add(complaint);
                }
                conn.Close();
            }
            return complaints;
        }
        public Complaint GetComplaintById(int id)
        {
            UserRepository userRepository = new UserRepository();
            using (SqlConnection conn = SqlConnectionHelper.CreateConnection())
            {
                string sql = "SELECT * FROM Complaints WHERE ID = @id;";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("id", id);
                var reader = cmd.ExecuteReader();
                reader.Read();
                Complaint complaint = new Complaint(Convert.ToInt32(reader["ID"]),
                    userRepository.GetUserById(Convert.ToInt32(reader["Author"])),
                    reader["Description"].ToString(), reader["Title"].ToString(),
                    (DateTime)reader["PublishDate"], (ComplaintStatus)reader["Status"],
                    (ComplaintSeverity)reader["Severity"]);
                CommentRepository commentRepository = new CommentRepository();
                complaint.Responses = commentRepository.GetAllCommentsOnComplaint(complaint.ID);
                conn.Close();
                return complaint;
            }
        }
        public List<Complaint> GetComplaintsByPage(int userId, int p, int c)
        {
            List<Complaint> complaints = new List<Complaint>();
            UserRepository userRepository = new UserRepository();
            User user = userRepository.GetUserById(userId);
            string sql = "SELECT * FROM Complaints ORDER BY ID DESC OFFSET @start ROWS FETCH NEXT @count ROWS ONLY;";
            if (user.Role == UserRole.TENANT)
            {
                sql = $"SELECT * FROM Complaints WHERE Author = {userId} ORDER BY ID DESC OFFSET @start ROWS FETCH NEXT @count ROWS ONLY;";
            }
            if (c == null)
            {
                throw new DatabaseOperationException("Get complaints: Invalid item count");
            }
            if (p == null)
            {
                throw new DatabaseOperationException("Get complaints: Invalid page number");
            }
            using (SqlConnection conn = SqlConnectionHelper.CreateConnection())
            {
                
                SqlCommand sqlCommand = new SqlCommand(sql, conn);
                sqlCommand.Parameters.AddWithValue("@start", p * c);
                sqlCommand.Parameters.AddWithValue("@count", c);
                var reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    complaints.Add(new Complaint(Convert.ToInt32(reader["ID"]),
                        userRepository.GetUserById(Convert.ToInt32(reader["Author"])),
                        reader["Description"].ToString(), reader["Title"].ToString(),
                        (DateTime)reader["PublishDate"], (ComplaintStatus)reader["Status"],
                        (ComplaintSeverity)reader["Severity"]));
                }

            }
            return complaints;
        }
        public Complaint CreateComplaint(string title, string description, User author, DateTime publishDate, ComplaintStatus status, ComplaintSeverity severity)
        {
            using (SqlConnection conn = SqlConnectionHelper.CreateConnection())
            {
                string sql = "INSERT INTO Complaints (Author, Description, Title, PublishDate, Status, Severity) VALUES (@author, @desc, @title, @date, @status, @severity) " +
                    "SELECT SCOPE_IDENTITY();";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@author", author.ID);
                cmd.Parameters.AddWithValue("@desc", description);
                cmd.Parameters.AddWithValue("@title", title);
                cmd.Parameters.AddWithValue("@date", publishDate);
                cmd.Parameters.AddWithValue("@status", (int)status);
                cmd.Parameters.AddWithValue("@severity", (int)severity);
                int newId = Convert.ToInt32(cmd.ExecuteScalar());
                if (newId == 0)
                {
                    throw new DatabaseOperationException("Database error: Complaint not created");
                }
                else
                {
                    return GetComplaintById(newId);
                }
            }
        }
        public void UpdateComplaint(int id, string title, string description, ComplaintStatus status, ComplaintSeverity severity)
        {
            using (SqlConnection conn = SqlConnectionHelper.CreateConnection())
            {
                string sql = "UPDATE Complaints " +
                    "SET Description = @desc, Title = @title, Status = @status, Severity = @severity " +
                    "WHERE ID = @id " +
                    "SELECT SCOPE_IDENTITY();";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@desc", description);
                cmd.Parameters.AddWithValue("@title", title);
                cmd.Parameters.AddWithValue("@status", (int)status);
                cmd.Parameters.AddWithValue("@severity", (int)severity);
                var writer = cmd.ExecuteNonQuery();
                if (writer == -1)
                {
                    throw new DatabaseOperationException("Database error: Complaint not created");
                }
            }
        }

        public List<Complaint> SearchComplaint(string query)
        {
            if (string.IsNullOrEmpty(query))
            {
                throw new DatabaseOperationException("Search complaints error: Search query is empty");
            }
            List<Complaint> complaints = new List<Complaint>();
            UserRepository userRepository = new UserRepository();
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT * FROM Complaints ");
            string[] searchStrings = query.Split(' ');
            for (int i = 0; i < searchStrings.Length; i++)
            {
                if (i == 0)
                {
                    sql.Append($"WHERE Title LIKE @query{i} OR Description LIKE @query{i} ");
                }
                else
                {
                    sql.Append($"OR Title LIKE @query{i} OR Description LIKE @query{i} ");
                }
            }
            sql.Append(';');
            using (SqlConnection conn = SqlConnectionHelper.CreateConnection())
            {
                SqlCommand sqlCommand = new SqlCommand(sql.ToString(), conn);
                for (int i = 0; i < searchStrings.Length; i++)
                {
                    sqlCommand.Parameters.AddWithValue($"@query{i}", $"%{searchStrings[i]}%");
                }
                var reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    complaints.Add(new Complaint(Convert.ToInt32(reader["ID"]),
                        userRepository.GetUserById(Convert.ToInt32(reader["Author"])),
                        reader["Description"].ToString(), reader["Title"].ToString(),
                        (DateTime)reader["PublishDate"], (ComplaintStatus)reader["Status"],
                        (ComplaintSeverity)reader["Severity"]));
                }
            }
            return complaints;
        }
    }
}
