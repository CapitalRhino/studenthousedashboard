using Logic;
using Logic.Exceptions;
using Models;
using System.Data.SqlClient;

namespace Data
{
    public class EventRepository : IEventRepository
    {
        public Event CreateEvent(string title, string description, User author, DateTime publishDate, DateTime startDate, DateTime endDate)
        {
            using (SqlConnection conn = SqlConnectionHelper.CreateConnection())
            {
                string sql = "INSERT INTO Events (Author, Description, Title, PublishDate, StartDate, EndDate) VALUES (@author, @desc, @title, @date, @start, @end) " +
                    "SELECT SCOPE_IDENTITY();";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@author", author.ID);
                cmd.Parameters.AddWithValue("@desc", description);
                cmd.Parameters.AddWithValue("@title", title);
                cmd.Parameters.AddWithValue("@date", publishDate);
                cmd.Parameters.AddWithValue("@start", startDate);
                cmd.Parameters.AddWithValue("@end", endDate);
                int newId = Convert.ToInt32(cmd.ExecuteScalar());
                if (newId == 0)
                {
                    throw new DatabaseOperationException("Database error: Event not created");
                }
                else
                {
                    return GetEventById(newId);
                }
            }
        }

        public void DeleteEvent(int id)
        {
            using (SqlConnection conn = SqlConnectionHelper.CreateConnection())
            {
                string sql = "DELETE FROM Events WHERE Id = @id;";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", id);
                int writer = cmd.ExecuteNonQuery();
                if (writer != 1)
                {
                    throw new DatabaseOperationException("Database error: Event not deleted");
                }
            }
        }

        public List<Event> GetAllCurrentEvents()
        {
            List<Event> events = new List<Event>();
            UserRepository userRepository = new UserRepository();
            using (SqlConnection conn = SqlConnectionHelper.CreateConnection())
            {
                string sql = "SELECT * FROM Events WHERE StartDate >= CURRENT_TIMESTAMP;";
                SqlCommand cmd = new SqlCommand(sql, conn);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Event @event = new Event(Convert.ToInt32(reader["ID"]),
                        userRepository.GetUserById(Convert.ToInt32(reader["Author"])),
                        reader["Description"].ToString(), reader["Title"].ToString(),
                        (DateTime)reader["PublishDate"], (DateTime)reader["StartDate"],
                        (DateTime)reader["EndDate"]);
                    // ID, Name, Password, Role
                    events.Add(@event);
                }
                conn.Close();
            }
            return events;
        }

        public List<Event> GetAllEvents()
        {
            List<Event> events = new List<Event>();
            UserRepository userRepository = new UserRepository();
            using (SqlConnection conn = SqlConnectionHelper.CreateConnection())
            {
                string sql = "SELECT * FROM Events;";
                SqlCommand cmd = new SqlCommand(sql, conn);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Event @event = new Event(Convert.ToInt32(reader["ID"]),
                        userRepository.GetUserById(Convert.ToInt32(reader["Author"])),
                        reader["Description"].ToString(), reader["Title"].ToString(),
                        (DateTime)reader["PublishDate"], (DateTime)reader["StartDate"],
                        (DateTime)reader["EndDate"]);
                    // ID, Name, Password, Role
                    events.Add(@event);
                }
                conn.Close();
            }
            return events;
        }

        public Event GetEventById(int id)
        {
            UserRepository userRepository = new UserRepository();
            using (SqlConnection conn = SqlConnectionHelper.CreateConnection())
            {
                string sql = "SELECT * FROM Events WHERE ID = @id;";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("id", id);
                var reader = cmd.ExecuteReader();
                reader.Read();
                Event @event = new Event(Convert.ToInt32(reader["ID"]),
                    userRepository.GetUserById(Convert.ToInt32(reader["Author"])),
                    reader["Description"].ToString(), reader["Title"].ToString(),
                    (DateTime)reader["PublishDate"], (DateTime)reader["StartDate"],
                    (DateTime)reader["EndDate"]);
                conn.Close();
                return @event;
            }
        }

        public void UpdateEvent(int id, string title, string description, DateTime startDate, DateTime endDate)
        {
            using (SqlConnection conn = SqlConnectionHelper.CreateConnection())
            {
                string sql = "UPDATE Events " +
                    "SET Description = @desc, Title = @title, StartDate = @start, EndDate = @end " +
                    "WHERE ID = @id " +
                    "SELECT SCOPE_IDENTITY();";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@desc", description);
                cmd.Parameters.AddWithValue("@title", title);
                cmd.Parameters.AddWithValue("@start", startDate);
                cmd.Parameters.AddWithValue("@end", endDate);
                var writer = cmd.ExecuteNonQuery();
                if (writer == -1)
                {
                    throw new DatabaseOperationException("Database error: Event not updated");
                }
            }
        }
    }
}
