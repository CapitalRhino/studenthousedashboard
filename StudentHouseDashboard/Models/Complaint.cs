namespace Models
{
    public class Complaint : GenericMessage
    {
        public Complaint()
        {

        }
        public Complaint(int id, User author, string description, string title, DateTime publishDate, ComplaintStatus status, ComplaintSeverity severity) : base(id, author, description, title, publishDate)
        {
            Status = status;
            Severity = severity;
        }

        public ComplaintStatus Status
        {
            get; set;
        }

        public ComplaintSeverity Severity
        {
            get; set;
        }

        public List<Comment> Responses
        {
            get; set;
        }
        public override string ToString()
        {
            return $"({PublishDate.ToString("d")} - {Author.Name}) {Title}";
        }
    }
}